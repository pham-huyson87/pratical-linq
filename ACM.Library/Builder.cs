
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
    }
}
