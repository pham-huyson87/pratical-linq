using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.Library.Test
{
    [TestClass]
    public class BuilderTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void BuildIntegerSequenceTest()
        {
            // Arrange
            Builder listBuilder = new Builder();

            // Act
            var result = listBuilder.BuildIntegerSequence();

            // Analyze
            foreach (var item in result)
            {
                TestContext.WriteLine(item.ToString());
            }

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuildStringSequenceTest()
        {
            // Arrange
            Builder listBuilder = new Builder();

            // Act
            var result = listBuilder.BuildStringSequence();

            // Analyze
            foreach (var item in result)
            {
                TestContext.WriteLine(item);
            }

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuildRandomStringSequenceTest()
        {
            // Arrange
            Builder listBuilder = new Builder();

            // Act
            var result = listBuilder.BuildRandomStringSequence();

            // Analyze
            foreach (var item in result)
            {
                TestContext.WriteLine(item);
            }

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuilderIntegerSequenceWithRepeatTest()
        {
            // Arrange
            Builder listBuilder = new Builder();

            // Act
            var result = listBuilder.BuilderIntegerSequenceWithRepeat();

            // Analyze
            foreach (var item in result)
            {
                TestContext.WriteLine(item.ToString());
            }

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuildStringSequenceWithRepeatTest()
        {
            // Arrange
            Builder listBuilder = new Builder();

            // Act
            var result = listBuilder.BuildStringSequenceWithRepeat();

            // Analyze
            foreach (var item in result)
            {
                TestContext.WriteLine(item);
            }

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IntersectSequencesTest()
        {
            // Arrange
            Builder builder = new Builder();

            // Act
            var result = builder.IntersectSequences();

            // Analyze
            foreach (var item in result)
            {
                TestContext.WriteLine(item.ToString());
            }

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ExceptSequencesTest()
        {
            // Arrange
            Builder builder = new Builder();

            // Act
            var result = builder.ExceptSequences();

            // Analyze
            foreach (var item in result)
            {
                TestContext.WriteLine(item.ToString());
            }

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ConcatSequencesTest()
        {
            // Arrange
            Builder builder = new Builder();

            // Act
            var result = builder.ConcatSequences();

            // Analyze
            foreach (var item in result)
            {
                TestContext.WriteLine(item.ToString());
            }

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void UnionSequencesTest()
        {
            // Arrange
            Builder builder = new Builder();

            // Act
            var result = builder.UnionSequences();

            // Analyze
            foreach (var item in result)
            {
                TestContext.WriteLine(item.ToString());
            }

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
