using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using FibonacciSequence.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FibonacciSequence.Controllers
{
    [Route("api/[controller]")]
    public class FibonacciNumberController : Controller
    {
        [FromServices]
        public IFibonacciRepository FibonacciSequence { get; set; }

        [HttpGet]
        public IEnumerable<FibonacciNumber> GetFibonacciSequence()
        {
            return FibonacciSequence.GetFibonacciSequence();
        }

        [HttpGet("{index}", Name = "GetFibonaccinumber")]
        public IActionResult GetFibonacciNumberByIndex(int index)
        {
            FibonacciNumber number = FibonacciSequence.GetFibonucciNumberByindex(index);

            if (number == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(number);
        }
    }
}
