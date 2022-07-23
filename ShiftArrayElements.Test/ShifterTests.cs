using System;
using System.Linq;
using NUnit.Framework;

namespace ShiftArrayElements.Test
{
    [TestFixture]
    public class ShifterTests
    {
        [Test]
        public void Shift_SourceIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Shifter.Shift(null, Array.Empty<int>()));
        }

        [Test]
        public void Shift_IterationsIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Shifter.Shift(Array.Empty<int>(), null));
        }
        
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void Shift_SourceIsNotNull_SourceEqualsResult(int[] source)
        {
            int[] result = Shifter.Shift(source, Array.Empty<int>());

            Assert.AreSame(source, result);
        }
        
        [TestCase(new int[] { }, new int[] { 0 }, new int[] { })]
        [TestCase(new int[] { }, new int[] { }, new int[] { })]
        [TestCase(new[] { 1 }, new[] { 0 }, new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { 1 }, new[] { 1 })]
        [TestCase(new[] { 1, 2 }, new[] { 1 }, new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { 2 }, new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { 1, 1 }, new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { 1, 2 }, new[] { 2, 1 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3 }, new[] { 3, 4, 5, 1, 2 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3, 4 }, new[] { 4, 5, 1, 2, 3 })]
        public void Shift_SourceAndIterationsAreNotNull_ReturnArraysWithShiftedElements(int[] source, int[] iterations, int[] expected)
        {
            var actual = Shifter.Shift(source, iterations);
            
            Assert.IsTrue(expected.SequenceEqual(actual));
        }
    }
}