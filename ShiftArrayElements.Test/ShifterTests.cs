using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace ShiftArrayElements.Test
{
    [TestClass]
    public class ShifterTests
    {
        [TestMethod]
        public void Shift_SourceIsNull_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Shifter.Shift(null, Array.Empty<int>()));
        }

        [TestMethod]
        public void Shift_IterationsIsNull_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Shifter.Shift(Array.Empty<int>(), null));
        }

        [TestMethod]
        [DataRow(new int[] { })]
        [DataRow(new int[] { 1 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5 })]
        public void Shift_SourceIsNotNull_SourceEqualsResult(int[] source)
        {
            int[] result = Shifter.Shift(source, Array.Empty<int>());

            Assert.AreSame(source, result);
        }


        [DataRow(new int[] { }, new int[] { 0 }, new int[] { })]
        [DataRow(new int[] { }, new int[] { }, new int[] { })]
        [DataRow(new[] { 1 }, new[] { 0 }, new[] { 1 })]
        [DataRow(new[] { 1 }, new[] { 1 }, new[] { 1 })]
        [DataRow(new[] { 1, 2 }, new[] { 1 }, new[] { 2, 1 })]
        [DataRow(new[] { 1, 2 }, new[] { 2 }, new[] { 1, 2 })]
        [DataRow(new[] { 1, 2 }, new[] { 1, 1 }, new[] { 1, 2 })]
        [DataRow(new[] { 1, 2 }, new[] { 1, 2 }, new[] { 2, 1 })]
        [DataRow(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3 }, new[] { 3, 4, 5, 1, 2 })]
        [DataRow(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3, 4 }, new[] { 4, 5, 1, 2, 3 })]
        [TestMethod]
        public void Shift_SourceAndIterationsAreNotNull_ReturnArraysWithShiftedElements(int[] source, int[] iterations, int[] expected)
        {
            var actual = Shifter.Shift(source, iterations);
            
            Assert.IsTrue(expected.SequenceEqual(actual));
        }
    }
}