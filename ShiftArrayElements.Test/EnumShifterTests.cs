using System;
using System.Linq;
using NUnit.Framework;

namespace ShiftArrayElements.Test
{
    [TestFixture]
    public class EnumShifterTests
    {
        [Test]
        public void Shift_SourceIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => EnumShifter.Shift(null, Array.Empty<Direction>()));
        }

        [Test]
        public void Shift_DirectionsIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => EnumShifter.Shift(Array.Empty<int>(), null));
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5})]
        public void Shift_SourceIsNotNull_SourceEqualsResult(int[] source)
        {
            int[] result = EnumShifter.Shift(source, Array.Empty<Direction>());

            Assert.AreSame(source, result);
        }

        [TestCase(new object[] { -1 })]
        [TestCase(new object[] { Direction.Left, 2})]
        [TestCase(new object[] { Direction.Left, Direction.Right, 3})]
        public void Shift_DirectionsContainsWrongValues_ThrowsInvalidOperationException(object[] objects)
        {
            var directions = objects.Cast<Direction>().ToArray();

            Assert.Throws<InvalidOperationException>(() => EnumShifter.Shift(new[] { 1, 2, 3, 4, 5 }, directions));
        }

        [TestCase(new[] { 1 }, new Direction[] { }, new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { Direction.Left }, new[] { 1 })]
        [TestCase(new[] { 1 }, new[] { Direction.Right }, new[] { 1 })]
        [TestCase(new[] { 1, 2 }, new Direction[] { }, new[] { 1, 2 })]
        [TestCase(new[] { 1, 2 }, new[] { Direction.Left }, new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { Direction.Right }, new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { Direction.Left, Direction.Left, Direction.Right }, new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 }, new[] { Direction.Right, Direction.Right, Direction.Left }, new[] { 2, 1 })]
        [TestCase(new[] { 1, 2, 3 }, new Direction[] { }, new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3 }, new[] { Direction.Left, Direction.Right, Direction.Left, Direction.Right }, new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3 }, new[] { Direction.Right, Direction.Left, Direction.Right, Direction.Left }, new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3 }, new[] { Direction.Left, Direction.Left, Direction.Right, Direction.Right }, new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3 }, new[] { Direction.Right, Direction.Right, Direction.Left, Direction.Left }, new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { Direction.Left }, new[] { 2, 3, 4, 5, 1 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { Direction.Right }, new[] { 5, 1, 2, 3, 4 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { Direction.Left, Direction.Left, Direction.Left, Direction.Left, Direction.Left }, new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { Direction.Right, Direction.Right, Direction.Right, Direction.Right, Direction.Right }, new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { Direction.Left, Direction.Left, Direction.Left, Direction.Left, Direction.Left }, new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { Direction.Right, Direction.Right, Direction.Right, Direction.Right, Direction.Right }, new[] { 1, 2, 3, 4, 5 })]
        public void Shift_SourceAndDirectionsAreNotNull_ReturnsArrayWithShiftedElements(int[] source, Direction[] directions, int[] expected)
        {
            var actual = EnumShifter.Shift(source, directions);

            Assert.IsTrue(expected.SequenceEqual(actual));
        }
    }
}