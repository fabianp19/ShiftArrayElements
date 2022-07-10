using System;

namespace ShiftArrayElements
{
    public static class Shifter
    {
        /// <summary>
        /// Shifts elements in a <see cref="source"/> array using <see cref="iterations"/> array for getting directions and iterations.
        /// </summary>
        /// <param name="source">A source array.</param>
        /// <param name="iterations">An array with iterations.</param>
        /// <returns>An array with shifted elements.</returns>
        /// <exception cref="ArgumentNullException">source array is null.</exception>
        /// <exception cref="ArgumentNullException">iterations array is null.</exception>
        public static int[] Shift(int[] source, int[] iterations)
        {
            Validate(source, iterations);

            if (source.Length == 1)
            {
                return source;
            }

            for (var i = 0; i < iterations.Length; i++)
            {
                if (i % 2 != 0 && iterations[i] != 0)
                {
                    for (var j = 0; j < iterations[i]; j++)
                    {
                        var lastElement = source[source.Length - 1];
                        for (var l = 0; l < source.Length - 1; l++)
                        {
                            Array.Copy(source, source.Length - 2 - l, source, source.Length - 1 - l, 1);
                        }

                        source[0] = lastElement;
                    }
                }
                else if (iterations[i] != 0)
                {
                    for (var j = 0; j < iterations[i]; j++)
                    {
                        var firstElement = source[0];
                        for (var l = 0; l < source.Length - 1; l++)
                        {
                            Array.Copy(source, l + 1, source, l, 1);
                        }

                        source[source.Length - 1] = firstElement;
                    }
                }
            }

            return source;
        }
        
        private static void Validate(int[] source, int[] iterations)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (iterations is null)
            {
                throw new ArgumentNullException(nameof(iterations));
            }
        }
    }
}