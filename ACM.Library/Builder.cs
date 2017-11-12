
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACM.Library
{
    public class Builder
    {
        public IEnumerable<int> BuildIntegerSequence()
        {
            var integers = Enumerable.Range(0, 10)                      // 0 .. 10
                                        .Select(i => 5 + (10 * i));     // Projection with Arithmetic expression
            return integers;
        }

        public IEnumerable<string> BuildStringSequence()
        {
            var strings = Enumerable.Range(0, 10)
                                        .Select(i => ((char)('A' + i)).ToString());     // Projection to string
            return strings;
        }

        public IEnumerable<string> BuildRandomStringSequence()
        {
            Random random = new Random();
            var randomStrings = Enumerable.Range(0, 10)
                                        .Select(i => ((char) ('A' + random.Next(0, 26))).ToString());

            return randomStrings;
        }

        public IEnumerable<int> BuilderIntegerSequenceWithRepeat()
        {
            var integers = Enumerable.Repeat(-1, 10);       // -1 x 10
            return integers;
        }

        public IEnumerable<string> BuildStringSequenceWithRepeat()
        {
            var strings = Enumerable.Repeat("A", 10);
            return strings;
        }

        public IEnumerable<int> IntersectSequences()
        {
            var sequence1 = Enumerable.Range(0, 10);            // 0 .. 99
            var sequence2 = Enumerable.Range(0, 10)
                                        .Select(i => i * i);    // 0 .. 81 (Projection here)

            return sequence1.Intersect(sequence2);              // In sequence1 AND in sequence2
                                                                //      0, 1, 4, 9
        }

        public IEnumerable<int> ExceptSequences()
        {
            var sequence1 = Enumerable.Range(0, 10);            // 0 .. 99
            var sequence2 = Enumerable.Range(0, 10)
                                        .Select(i => i * i);    // 0 .. 81 (Projection here)

            return sequence1.Except(sequence2);                 // sequence1 - sequence 2
                                                                //      0, 2, 3, 5, 6, 7, 8
        }

        public IEnumerable<int> ConcatSequences()
        {
            var sequence1 = Enumerable.Range(0, 10);            // 0 .. 99
            var sequence2 = Enumerable.Range(0, 10)
                                        .Select(i => i * i);    // 0 .. 81 (Projection here)

            return sequence1.Concat(sequence2);                 // sequence1 + sequence2
                                                                //      0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
                                                                //      0, 1, 4, 9, 16, 25, 36, 49, 64, 81
        }

        public IEnumerable<int> UnionSequences()
        {
            var sequence1 = Enumerable.Range(0, 10);            // 0 .. 99
            var sequence2 = Enumerable.Range(0, 10)
                                        .Select(i => i * i);    // 0 .. 81 (Projection here)

            sequence1.Concat(sequence2)
                                .Distinct();                    // sequence1 + sequence2 - (Duplicate values)
                                                                //      0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
                                                                //      16, 25, 36, 49, 64, 81

            return sequence1.Union(sequence2);                  // Equivalent and best expression for this case
        }
    }
}
