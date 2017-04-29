//This is a play area as I learn to write in C#
//Dev Branch
using System;

namespace Hello
{
    class Program
    {
        static void Main()
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
            string GetGreating(int hour)
            {
                if ((hour >= 0) && (hour <12))
                {
                    return "Good Morning";
                }
                else if ((hour >= 12) && (hour < 17))
                {
                    return "Good Afternoon";
                }
                else if ((hour >= 17) && (hour < 20))
                {
                    return "Good Evening";
                }
                else
                {
                    return "Goodnight";
                }
            }
            Console.Title = "Hello, World!";
            Console.WriteLine(GetGreating(DateTime.Now.Hour) + ", " + Environment.UserName + "!");
            Console.WriteLine("Today is " + DateTime.Now.DayOfWeek + " the " + DateTime.Now.Day + GetDaySuffix(DateTime.Now.Day) + " of " + DateTime.Now.ToString("MMMM") + " " + DateTime.Now.Year);
            Console.Write("Press any key to exit... ");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
