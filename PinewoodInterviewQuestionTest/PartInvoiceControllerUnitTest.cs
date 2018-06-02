﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PinnacleSample;

namespace PinewoodInterviewQuestionTest
{
    [TestClass]
    public class PartInvocieControllerUnitTest
    {
        PartInvoiceController PartInvoiceController;

        [TestInitialize]
        public void TestInitialize()
        {
            this.PartInvoiceController = new PartInvoiceController();
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