using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FibonacciSequence.Models
{
    public class FibonacciRepository : IFibonacciRepository
    {
        static ConcurrentDictionary<int, FibonacciNumber> fibonacciSequence = new ConcurrentDictionary<int, FibonacciNumber>();
        public FibonacciRepository()
        {
            var numbers = 90;
            long preprevious = 0;
            long previous = 0;
            FibonacciNumber number;

            for (int i = 0; i < numbers; i++)
            {
                if (i == 0)
                {
                    fibonacciSequence.TryAdd(i, new FibonacciNumber { Index = i, Value = 0 });
                }
                else if (i == 1)
                {
                    fibonacciSequence.TryAdd(i, new FibonacciNumber { Index = i, Value = 1 });

                    preprevious = previous;
                    fibonacciSequence.TryGetValue(i, out number);
                    previous = number.Value;
                }
                else
                {
                    fibonacciSequence.TryAdd(i, new FibonacciNumber { Index = i, Value = preprevious + previous });

                    preprevious = previous;
                    fibonacciSequence.TryGetValue(i, out number);
                    previous = number.Value;
                }
            }
        }
        public IEnumerable<FibonacciNumber> GetFibonacciSequence()
        {
            return fibonacciSequence.Values;
        }

        public FibonacciNumber GetFibonucciNumberByindex(int index)
        {
            FibonacciNumber number;

            fibonacciSequence.TryGetValue(index, out number);

            return number;
        }
    }
}
