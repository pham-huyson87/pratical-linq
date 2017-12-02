using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ACM.BL.Test
{
    [TestClass]
    public class InvoiceRepositoryTest
    {
        public TestContext TextContext { get; set; }

        [TestMethod]
        public void CalculateTotalAmountInvoicedTest()
        {
            // Arrange
            InvoiceRepository repository = new InvoiceRepository();
            List<Invoice> invoiceList = repository.Retrieve();
            
            // Act
            var actual = repository.CalculateTotalAmountInvoiced(invoiceList);

            // Assert
            Assert.AreEqual(1333.14M, actual);
        }

        [TestMethod]
        public void CalculateTotalUnitsSoldTest()
        {
            // Arrange
            InvoiceRepository repository = new InvoiceRepository();
            List<Invoice> invoiceList = repository.Retrieve();

            // Act
            var actual = repository.CalculateTotalUnitsSold(invoiceList);

            // Assert
            Assert.AreEqual(136, actual);
        }

        [TestMethod]
        public void GetInvoiceTotalByIsPaidTest()
        {
            // Arrange
            InvoiceRepository repository = new InvoiceRepository();
            List<Invoice> invoiceList = repository.Retrieve();

            // Act
            repository.GetInvoiceTotalByIsPaid(invoiceList);
        }

        [TestMethod]
        public void GetInvoiceTotalByIsPaidAndMonthTest()
        {
            // Arrange
            InvoiceRepository repository = new InvoiceRepository();
            List<Invoice> invoiceList = repository.Retrieve();

            // Act
            repository.GetInvoiceTotalByIsPaidAndMonth(invoiceList);
        }
    }
}
