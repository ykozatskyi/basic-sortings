using BasicSortingTester.Sortings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;

namespace BasicSortingTester_Tests
{
    [TestClass]
    public class MergeSorterTests
    {
        [TestMethod]
        public void Sort_ValidArray_Success()
        {
            var sorter = new MergeSorter<int>();
            var array = new int[10] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };

            sorter.Sort(array);

            Assert.IsTrue(sorter.Ensure(array));
        }

        [TestMethod]
        public void Sort_EmptyArray_Success()
        {
            var sorter = new MergeSorter<int>();
            var array = new int[0];

            sorter.Sort(array);

            Assert.IsTrue(sorter.Ensure(array));
        }

        [TestMethod]
        public void Sort_SingleElementArray_Success()
        {
            var sorter = new MergeSorter<int>();
            var array = new int[1] { 0 };

            sorter.Sort(array);

            Assert.IsTrue(sorter.Ensure(array));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Sort_NullParameter_ThrowsException()
        {
            var sorter = new MergeSorter<int>();
            sorter.Sort(null);
        }

        [TestMethod]
        public void DivideAndRule_ValidArray_Success()
        {
            var sorter = new MergeSorter<int>();
            var inputArray = new int[10] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            var outputArray = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            MethodInfo methodInfo = typeof(MergeSorter<int>).GetMethod("DivideAndRule", BindingFlags.NonPublic | BindingFlags.Instance);

            inputArray = (int[])methodInfo.Invoke(sorter, new object[] { inputArray });

            Assert.IsTrue(sorter.Ensure(inputArray));
            Assert.IsTrue(inputArray.SequenceEqual(outputArray));
        }

        [TestMethod]
        public void Merge_ValidArray_Success()
        {
            var sorter = new MergeSorter<int>();
            var leftArray = new int[3] { 7, 8, 9 };
            var rightArray = new int[3] { 0, 1, 2 };
            var outputArray = new int[6] { 0, 1, 2, 7, 8, 9 };
            MethodInfo methodInfo = typeof(MergeSorter<int>).GetMethod("CompairingMerge", BindingFlags.NonPublic | BindingFlags.Instance);

            var result = (int[])methodInfo.Invoke(sorter, new object[] { leftArray, rightArray });

            Assert.IsTrue(outputArray.SequenceEqual(result));
        }
    }
}
