using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("Today is " + DateTime.Today.DayOfWeek + " the " + DateTime.Today.Day + " of " + DateTime.Now.ToString("MMMM"));
        }
    }
}
