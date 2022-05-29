using NUnit.Framework;
using System;

using System.Linq;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        [TestCase(1, 6)]
        [TestCase(5, 10)]
        [TestCase(1, 16)]
        public void DatebaseShouldAddElementsWhileSizeIsSmallerThanSixteen(int start, int count)
        {
            int[] elements = Enumerable.Range(start, count).ToArray();
            Database.Database test = new Database.Database(elements);

            Assert.AreEqual(count, test.Count);
        }
        [Test]
        [TestCase(18)]
        [TestCase(20)]
        [TestCase(100)]
        public void DatabaseShouldThrowsExceptionIfHaveMoreElementsThanSixteen(int size)
        {
            int[] elements = Enumerable.Range(0, size).ToArray();
            Assert.Throws<InvalidOperationException>(() => new Database.Database(elements));
        }
        [Test]
        [TestCase(16)]
        public void DataBaseShouldThrowsExceptionIfAddElementsMoreThanSixteen(int count)
        {
            Database.Database test = new Database.Database();
            for (int i = 0; i < count; i++)
            {
                test.Add(i);
            }
            Assert.Throws<InvalidOperationException>(() => test.Add(1));
        }
        [Test]
        [TestCase(1, 6)]
        [TestCase(5, 10)]
        [TestCase(1, 16)]
        public void DataBaseShouldRemoveOnlyOneElements(int start, int count)
        {
            int[] elements = Enumerable.Range(start, count).ToArray();
            Database.Database test = new Database.Database(elements);
            for (int i = count - 1; i >= 0; i--)
            {
                test.Remove();
                Assert.AreEqual(i, test.Count);
            }           
        }

        [Test]
        public void DataBaseShouldThrowsExceptionIfTryRemoveEmptyArray()
        {
            Database.Database test = new Database.Database();
            Assert.Throws<InvalidOperationException>(() => test.Remove());
        }
        [Test]
        [TestCase(1, 10)]
        public void DataBaseFetchShouldReturnElementsAsArray(int start, int count)
        {
            int[] elements = Enumerable.Range(start, count).ToArray();
            Database.Database test = new Database.Database(elements);           
            Assert.AreEqual(elements, test.Fetch());
        }
      
    }
}
