using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatastructuresOOP;

namespace CSharpLooksAtFSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new DatastructuresOOP.Stack<int>();
            var y = x.Push(1);
            var z = y.Push(2);
            var two = z.Pop();
            Console.WriteLine("two: {0}", two.Item1);
            var one = two.Item2.Pop();
            Console.WriteLine("one: {0}", one.Item1);
        }
    }
}
