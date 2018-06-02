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
