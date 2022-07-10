using System;

namespace ShiftArrayElements
{
    public static class EnumShifter
    {
        /// <summary>
        /// Shifts elements in a <see cref="source"/> array using directions from <see cref="directions"/> array, one element shift per each direction array element.
        /// </summary>
        /// <param name="source">A source array.</param>
        /// <param name="directions">An array with directions.</param>
        /// <returns>An array with shifted elements.</returns>
        /// <exception cref="ArgumentNullException">source array is null.</exception>
        /// <exception cref="ArgumentNullException">directions array is null.</exception>
        /// <exception cref="InvalidOperationException">direction array contains an element that is not <see cref="Direction.Left"/> or <see cref="Direction.Right"/>.</exception>
        public static int[] Shift(int[] source, Direction[] directions)
        {
            Validate(source, directions);

            for (var i = 0; i < directions.Length; i++)
            {
                switch (directions[i])
                {
                    case Direction.Left:
                        {
                            var firstElement = source[0];
                            for (var j = 0; j < source.Length - 1; j++)
                            {
                                source[j] = source[j + 1];
                            }

                            source[source.Length - 1] = firstElement;
                            break;
                        }

                    case Direction.Right:
                        {
                            int lastElement = source[source.Length - 1];
                            for (int j = 0; j < source.Length - 1; j++)
                            {
                                source[source.Length - 1 - j] = source[source.Length - 2 - j];
                            }

                            source[0] = lastElement;
                            break;
                        }

                    default:
                        {
                            throw new InvalidOperationException($"Incorrect {directions[i]} enum value.");
                        }
                }
            }
            return source;
        }

        public static void Validate(int[] source, Direction[] directions)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (directions is null)
            {
                throw new ArgumentNullException(nameof(directions));
            }
        }
    }
}
