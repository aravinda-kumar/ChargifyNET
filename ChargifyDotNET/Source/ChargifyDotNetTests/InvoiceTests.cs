using System;
using System.Collections.Generic;
using System.Linq;
using ChargifyNET;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChargifyDotNetTests.Base;

namespace ChargifyDotNetTests
{
    [TestClass]
    public class InvoiceTests : ChargifyTestBase
    {
        [TestMethod]
        public void Invoices_Can_Get_List()
        {
            // Act
            var result = Chargify.GetInvoiceList();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Dictionary<int, Invoice>));
            Assert.IsTrue(result.Count > 0);
            var anInvoice = result.FirstOrDefault().Value;
            Assert.IsTrue(result.FirstOrDefault().Key == anInvoice.ID);
            Assert.AreNotEqual(int.MinValue, anInvoice.ID);
        }
    }
}
