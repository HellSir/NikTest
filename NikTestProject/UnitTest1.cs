using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static NikTest.Program;

namespace NikTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] mass = { 12, 55, 45, 78 };
            int[] massCurr = { 12, 45, 55, 78 };

            IntComparer myComparer = new IntComparer();
            Heap<int> heap = new Heap<int>(mass, myComparer);
            heap.HeapSort();

            int[] massEnd = heap._array;

            bool equal_Curr = massCurr.SequenceEqual(massEnd);

            Assert.AreEqual(true, equal_Curr);
        }
    }
}
