using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShiftArrayElements.Test
{
    [TestClass]
    public class EnumShifterTests
    {
        [TestMethod]
        public void Shift_SourceIsNull_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => EnumShifter.Shift(null, Array.Empty<Direction>()));
        }

        [TestMethod]
        public void Shift_DirectionsIsNull_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => EnumShifter.Shift(Array.Empty<int>(), null));
        }

        [DataRow(new int[] { })]
        [DataRow(new int[] { 1 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5})]
        [TestMethod]
        public void Shift_SourceIsNotNull_SourceEqualsResult(int[] source)
        {
            int[] result = EnumShifter.Shift(source, Array.Empty<Direction>());

            Assert.AreSame(source, result);
        }

        [DataRow(new object[] { -1 })]
        [DataRow(new object[] { Direction.Left, 2})]
        [DataRow(new object[] { Direction.Left, Direction.Right, 3})]
        [TestMethod]
        public void Shift_DirectionsContainsWrongValues_ThrowsInvalidOperationException(object[] objects)
        {
            var directions = objects.Cast<Direction>().ToArray();

            Assert.ThrowsException<InvalidOperationException>(() => EnumShifter.Shift(new[] { 1, 2, 3, 4, 5 }, directions));
        }

        [DataRow(new[] { 1 }, new Direction[] { }, new[] { 1 })]
        [DataRow(new[] { 1 }, new[] { Direction.Left }, new[] { 1 })]
        [DataRow(new[] { 1 }, new[] { Direction.Right }, new[] { 1 })]
        [DataRow(new[] { 1, 2 }, new Direction[] { }, new[] { 1, 2 })]
        [DataRow(new[] { 1, 2 }, new[] { Direction.Left }, new[] { 2, 1 })]
        [DataRow(new[] { 1, 2 }, new[] { Direction.Right }, new[] { 2, 1 })]
        [DataRow(new[] { 1, 2 }, new[] { Direction.Left, Direction.Left, Direction.Right }, new[] { 2, 1 })]
        [DataRow(new[] { 1, 2 }, new[] { Direction.Right, Direction.Right, Direction.Left }, new[] { 2, 1 })]
        [DataRow(new[] { 1, 2, 3 }, new Direction[] { }, new[] { 1, 2, 3 })]
        [DataRow(new[] { 1, 2, 3 }, new[] { Direction.Left, Direction.Right, Direction.Left, Direction.Right }, new[] { 1, 2, 3 })]
        [DataRow(new[] { 1, 2, 3 }, new[] { Direction.Right, Direction.Left, Direction.Right, Direction.Left }, new[] { 1, 2, 3 })]
        [DataRow(new[] { 1, 2, 3 }, new[] { Direction.Left, Direction.Left, Direction.Right, Direction.Right }, new[] { 1, 2, 3 })]
        [DataRow(new[] { 1, 2, 3 }, new[] { Direction.Right, Direction.Right, Direction.Left, Direction.Left }, new[] { 1, 2, 3 })]
        [DataRow(new[] { 1, 2, 3, 4, 5 }, new[] { Direction.Left }, new[] { 2, 3, 4, 5, 1 })]
        [DataRow(new[] { 1, 2, 3, 4, 5 }, new[] { Direction.Right }, new[] { 5, 1, 2, 3, 4 })]
        [DataRow(new[] { 1, 2, 3, 4, 5 }, new[] { Direction.Left, Direction.Left, Direction.Left, Direction.Left, Direction.Left }, new[] { 1, 2, 3, 4, 5 })]
        [DataRow(new[] { 1, 2, 3, 4, 5 }, new[] { Direction.Right, Direction.Right, Direction.Right, Direction.Right, Direction.Right }, new[] { 1, 2, 3, 4, 5 })]
        [DataRow(new[] { 1, 2, 3, 4, 5 }, new[] { Direction.Left, Direction.Left, Direction.Left, Direction.Left, Direction.Left }, new[] { 1, 2, 3, 4, 5 })]
        [DataRow(new[] { 1, 2, 3, 4, 5 }, new[] { Direction.Right, Direction.Right, Direction.Right, Direction.Right, Direction.Right }, new[] { 1, 2, 3, 4, 5 })]
        [TestMethod]
        public void Shift_SourceAndDirectionsAreNotNull_ReturnsArrayWithShiftedElements(int[] source, Direction[] directions, int[] expected)
        {
            var actual = EnumShifter.Shift(source, directions);

            Assert.IsTrue(expected.SequenceEqual(actual));
        }
    }
}