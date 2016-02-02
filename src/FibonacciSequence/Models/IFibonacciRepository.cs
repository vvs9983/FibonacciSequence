using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FibonacciSequence.Models
{
    public interface IFibonacciRepository
    {
        IEnumerable<FibonacciNumber> GetFibonacciSequence();
        FibonacciNumber GetFibonucciNumberByindex(int index);
    }
}
