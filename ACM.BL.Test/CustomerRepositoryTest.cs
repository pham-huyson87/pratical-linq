﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ACM.BL.Test
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void FindTestExistingCustomer()
        {
            // Arrange
            CustomerRepository repository = new CustomerRepository();
            var customerList = repository.Retrieve();

            // Act
            var result = repository.Find(customerList, 2);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.CustomerId);
            Assert.AreEqual("Baggins", result.LastName);
            Assert.AreEqual("Bilbo", result.FirstName);
        }

        [TestMethod]
        public void FindTestNotFound()
        {
            // Arrange
            CustomerRepository repository = new CustomerRepository();
            var customerList = repository.Retrieve();

            // Act
            var result = repository.Find(customerList, 42);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SortByNameTest()
        {
            // Arrange
            CustomerRepository repository = new CustomerRepository();
            var customerList = repository.Retrieve();

            // Act
            var result = repository.SortByName(customerList);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.First().CustomerId);
            Assert.AreEqual("Baggins", result.First().LastName);
            Assert.AreEqual("Bilbo", result.First().FirstName);
        }

        [TestMethod]
        public void SortByNameInReverseTest()
        {
            // Arrange
            CustomerRepository repository = new CustomerRepository();
            var customerList = repository.Retrieve();

            // Act
            var result = repository.SortByNameInReverse(customerList);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Last().CustomerId);
            Assert.AreEqual("Baggins", result.Last().LastName);
            Assert.AreEqual("Bilbo", result.Last().FirstName);
        }

        [TestMethod]
        public void SortByNameInReverseShorterTest()
        {
            // Arrange
            CustomerRepository repository = new CustomerRepository();
            var customerList = repository.Retrieve();

            // Act
            var result = repository.SortByNameInReverse2(customerList);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Last().CustomerId);
            Assert.AreEqual("Baggins", result.Last().LastName);
            Assert.AreEqual("Bilbo", result.Last().FirstName);
        }

        [TestMethod]
        public void SortByTypeTest()
        {
            // Arrange
            CustomerRepository repository = new CustomerRepository();
            var customerList = repository.Retrieve();

            // Act
            var result = repository.SortByType(customerList);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(null, result.First().CustomerTypeId);
        }

        [TestMethod]
        public void SortByTypeNullAtBottom()
        {
            // Arrange
            CustomerRepository repository = new CustomerRepository();
            var customerList = repository.Retrieve();

            // Act
            var result = repository.SortByTypeNullAtBottom(customerList);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(null, result.Last().CustomerTypeId);
        }

        [TestMethod]
        public void GetNamesTest()
        {
            // Arrange
            CustomerRepository customerRepository = new CustomerRepository();
            var customerList = customerRepository.Retrieve();

            // Act
            var query = customerRepository.GetNames(customerList);

            // Analyze
            foreach (var item in query)
            {
                TestContext.WriteLine(item);
            }

            // Assert
            Assert.IsNotNull(query);
        }

        [TestMethod]
        public void GetNamesAndEmailsTest()
        {
            // Arrange
            CustomerRepository repository = new CustomerRepository();
            var customerList = repository.Retrieve();

            // Act
            var query = repository.GetNamesAndEmails(customerList);
        }

        [TestMethod]
        public void GetNamesAndTypesTest()
        {
            // Arrange
            CustomerRepository customerRepository = new CustomerRepository();
            CustomerTypeRepository customerTypeRepository = new CustomerTypeRepository();
            var customerList = customerRepository.Retrieve();
            var customerTypeList = customerTypeRepository.Retrieve();

            // Act
            var query = customerRepository.GetNamesAndTypes(customerList, customerTypeList);
        }

        [TestMethod]
        public void GetOverdueCustomers()
        {
            // Arrange
            CustomerRepository repository = new CustomerRepository();
            var customerList = repository.Retrieve();

            // Act
            var query = repository.GetOverdueCustomers(customerList);

            // Analyze
            foreach (var parent in query)
            {
                foreach (var child in parent)
                {
                    TestContext.WriteLine(child.DueDate.ToString());
                }
            }

            // Assert
            Assert.IsNotNull(query);
        }

        [TestMethod]
        public void  GetOverdueCustomers2Test()
        {
            // Arrange
            CustomerRepository repository = new CustomerRepository();
            var customerList = repository.Retrieve();

            // Act
            var query = repository.GetOverdueCustomers2(customerList);

            // Analyze
            foreach (var invoice in query)
            {
                TestContext.WriteLine(invoice.DueDate.ToString());
            }

            // Assert
            Assert.IsNotNull(query);
        }

        [TestMethod]
        public void GetOverdueCustomersFinalTest()
        {
            // Arrange
            CustomerRepository repository = new CustomerRepository();
            var customerList = repository.Retrieve();

            // Act
            var query = repository.GetOverdueCustomersFinal(customerList);

            // Analyze
            foreach (var customer in query)
            {
                TestContext.WriteLine(customer.LastName + ", " + customer.FirstName);
            }

            // Assert
            Assert.IsNotNull(query);
        }

        [TestMethod]
        public void GetInvoiceTotalByCustomerTypeTest()
        {
            // Arrange
            var repository = new CustomerRepository();
            var customerList = repository.Retrieve();

            var typeRepository = new CustomerTypeRepository();
            var customerTypeList = typeRepository.Retrieve();

            // Act
            var query = repository.GetInvoiceTotalByCustomerType(customerList, customerTypeList);
        }
    }
}
