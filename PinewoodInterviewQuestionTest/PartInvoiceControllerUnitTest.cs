using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PinnacleSample;
using Moq;

namespace PinewoodInterviewQuestionTest
{
    [TestClass]
    public class PartInvocieControllerUnitTest
    {
        PartInvoiceController PartInvoiceController;

        [TestInitialize]
        public void TestInitialize()
        {
            var mockCustomerRepository = SetupCustomerRepositoryMock();
            var mockPartInvoiceRepository = SetupPartInvoiceRepositoryMock();
            var mockPartAvailablityServiceClientFactory = SetupPartAvailabilityServiceClientFactory();
            this.PartInvoiceController = new PartInvoiceController(mockCustomerRepository, mockPartInvoiceRepository,mockPartAvailablityServiceClientFactory);
        }

        private ICustomerRepository SetupCustomerRepositoryMock()
        {
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            mockCustomerRepository.Setup(r => r.GetByName("Alice")).Returns(new Customer()
            {
                ID = 1,
                Address = "Hello Wrold",
                Name = "Alice"
            });
            return mockCustomerRepository.Object;
        }
        private IPartInvoiceRepository SetupPartInvoiceRepositoryMock()
        {
            var mockPartInvoiceRepository = new Mock<IPartInvoiceRepository>();
            mockPartInvoiceRepository.Setup(r => r.Add(It.IsAny<PartInvoice>()));
            return mockPartInvoiceRepository.Object;
        }

        private PartAvailabilityServiceClientFactory SetupPartAvailabilityServiceClientFactory()
        {
            var mockIPartAvailabilityService = new Mock<IPartAvailabilityServiceClient>();
            mockIPartAvailabilityService.Setup(c => c.GetAvailability(It.IsAny<string>())).Returns(10);
            var mockPartAvailabilityServiceClientFactory = new Mock<PartAvailabilityServiceClientFactory>();
            mockPartAvailabilityServiceClientFactory.Setup(f => f.GetClient()).Returns(mockIPartAvailabilityService.Object);
            return mockPartAvailabilityServiceClientFactory.Object;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // let's pretend I can actually clean this up
            this.PartInvoiceController = null;
        }

        [TestMethod]
        public void TestCreatePartInvoiceNoExceptionOnDefaultArguments()
        {
            try {
                string stockCode = null;
                int quantity = 0;
                string customerName = null;
                var result = PartInvoiceController.CreatePartInvoice(stockCode, quantity, customerName);
            }catch(Exception e)
            {
                Assert.Fail("Exception was thrown", e);
            }
        }


        [TestMethod]
        public void TestCreatePartInvoiceStockNotFound()
        {
            string stockCode = null;
            int quantity = 0;
            string customerName = null;
            var result = PartInvoiceController.CreatePartInvoice(stockCode, quantity, customerName);
            Assert.AreEqual(result,new CreatePartInvoiceResult(false));
        }

        [TestMethod]
        public void TestCreatePartInvoiceInvalidQuantity()
        {
            string stockCode = "test";
            int quantity = -1;
            string customerName = null;
            var result = PartInvoiceController.CreatePartInvoice(stockCode, quantity, customerName);
            Assert.AreEqual(result, new CreatePartInvoiceResult(false));
        }

        [TestMethod]
        public void TestCreatePartInvoiceInvalidCustomer()
        {
            string stockCode = "test";
            int quantity = 10;
            string customerName = "--Drop Database;"; // don't judge this one ;)
            var result = PartInvoiceController.CreatePartInvoice(stockCode, quantity, customerName);
            Assert.AreEqual(result, new CreatePartInvoiceResult(false));
        }

        [TestMethod]
        public void TestCreatePartInvoiceSuccess()
        {
            string stockCode = "test";
            int quantity = 10;
            string customerName = "Alice"; // don't judge this one ;)
            var result = PartInvoiceController.CreatePartInvoice(stockCode, quantity, customerName);
            Assert.AreEqual(result, new CreatePartInvoiceResult(true));
        }

    }
}
