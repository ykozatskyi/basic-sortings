using BasicSortingTester.Sortings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BasicSortingTester_Tests
{
    [TestClass]
    public class BubbleSorterTests
    {
        [TestMethod]
        public void Sort_ValidArray_Success()
        {
            var sorter = new BubbleSorter<int>();
            var array = new int[10] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };

            sorter.Sort(array);

            Assert.IsTrue(sorter.Ensure(array));
        }

        [TestMethod]
        public void Sort_EmptyArray_Success()
        {
            var sorter = new BubbleSorter<int>();
            var array = new int[0];

            sorter.Sort(array);

            Assert.IsTrue(sorter.Ensure(array));
        }

        [TestMethod]
        public void Sort_SingleElementArray_Success()
        {
            var sorter = new BubbleSorter<int>();
            var array = new int[1] { 0 };

            sorter.Sort(array);

            Assert.IsTrue(sorter.Ensure(array));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Sort_NullParameter_ThrowsException()
        {
            var sorter = new BubbleSorter<int>();
            sorter.Sort(null);
        }
    }
}
