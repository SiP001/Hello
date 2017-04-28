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
            string GetDaySuffix(int day)
            {
                switch (day)
                {
                    case 1:
                    case 21:
                    case 31:
                        return "st";
                    case 2:
                    case 22:
                        return "nd";
                    case 3:
                    case 23:
                        return "rd";
                    default:
                        return "th";
                }
            }
            Console.WriteLine("Hello, World!");
            
            Console.WriteLine("Today is " + DateTime.Today.DayOfWeek + " the " + DateTime.Today.Day + GetDaySuffix(DateTime.Today.Day) + " of " + DateTime.Now.ToString("MMMM"));
        }
    }
}
