using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace riat_l2
{
    class Program
    {
       static void Main(string[] args)
        {
            var handler = new RequestHandler(int.Parse(Console.ReadLine()));
            handler.Ping();
            var input = handler.GetInputData();
            handler.WriteAnswer(input.CreateOutput());
        }
    }
}
