# pinewood_interview_refractor
This readme.md will be used as a log to demostrate the thought process in the refactoring exercise.

## Step 0 Introduction
I need to know what is the project doing before writing anything.
I found the project has high similarity with a .net mvc style architecture.
Without second thought I ordered the class files with this .net mvc style file tree.

It now make sense with the following data path:

Entry Point `PinnacleClient.cs`

Workflow for "Create Part Invoice"  
(Invocation) `PinnacleClient::CreatePartInvoice`  
-> (Controller) `PartInvoiceController::CreatePartInvoice`  
-> (dependent repository/services) `CustomerRepositoryDB` / `PartAvailabilityServiceClient` / `PartInvoiceRepositoryDB`  
-> (result)
`CreatePartInvoiceResult`

From this architecutre pattern (MVC),
it suffices to perform unit tests on `PartInvoiceController`  

It is clear that the dependency to a concrete database at `CustomerRepositoryDB` / `PartInvoiceRepositoryDB` and current status on `PartAvailabilityServiceClient` are the main reasons of failing to unit test.

## Step 1 - DB-bound repositories
In order to tackle the issue, I would like to have the ability to inject these dependency while doing tests.

For `CustomerRepositoryDB` / `PartInvoiceRepositoryDB`, 
I would like to inject behaviour of certain methods when the test is carried out.
For a task with expected effort of around an hour, 
and to avoid pollute the code base with more implementation of repositories,
using Mocking Frameworks [MOQ](#moq) could be a better choice.
To override method behavior,
they need to be virtual.
For the sake of simplicity,
I created Interfaces `ICustomerRepository` / `IInvoiceRepository`  for them.
Then I updated `PartInvoiceController` so I can inject an implementation at construction time on this controller.  

In reality one may choose to have a proper local database injected so subsequent CRUD could also be unit tested.


## References
[Moq](https://github.com/Moq/moq4/wiki/Quickstart)
