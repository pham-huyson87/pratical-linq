using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
