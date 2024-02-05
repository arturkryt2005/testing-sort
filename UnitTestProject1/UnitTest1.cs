using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using _10_lr;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] unsortedArray = new int[] { 3, 7, 1, 6, 9, 12 };
            int[] expectedArray = new int[] { 1, 3, 6, 7, 9, 12 };
            var bubble = new Bubble();

            // Act
            bubble.AAlgorithm(unsortedArray);

            // Assert
            CollectionAssert.AreEqual(expectedArray, unsortedArray);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int[] unsortedArray = { 3, 7, 1, 6, 9, 12 };
            int[] expectedArray = { 1, 3, 6, 7, 9, 12 };

            // Act
            buble.MergeSort(unsortedArray);

            // Assert
            CollectionAssert.AreEqual(expectedArray, unsortedArray);
        }

        [TestMethod]
        public void TestMethod3()
        {
            int[] unsortedArray = new int[] { 6, 2, 3, 1, 4, 5 };
            int[] expectedArray = new int[] { 1, 2, 3, 4, 5, 6 };
            Bubble.ViborSort(unsortedArray);
            CollectionAssert.AreEqual(unsortedArray, expectedArray);
        }

    }
}
