//This is a play area as I learn to write in C#

using System;
using System.Globalization;
namespace Hello
{
    class Program
    {
        static void AgeCalc()
        {
            Console.Write("Enter DoB (dd/mm/yyyy): ");
            string babyBorn = Console.ReadLine();
            DateTime babyDoB = DateTime.ParseExact(babyBorn, "d/M/yyyy", CultureInfo.InvariantCulture);
            TimeSpan timeSince = DateTime.Now.Subtract(babyDoB);
            int yearsSince = (DateTime.Now.Year - babyDoB.Year);
            int monthsSince = ((yearsSince * 12) + (DateTime.Now.Month - babyDoB.Month));
            Console.WriteLine("Your Age is:");
            Console.WriteLine("             " + yearsSince + " years old.");
            Console.WriteLine("             " + monthsSince + " months old.");
            Console.WriteLine("             " + timeSince.Days / 7 + " weeks old.");
            Console.WriteLine("             " + timeSince.Days + " days old.");
            Console.WriteLine("             " + (int)timeSince.TotalHours + " hours old.");
            Console.WriteLine("             " + (int)timeSince.TotalMinutes + " minutes old.");
            Console.Write("Would you like to do another?(Yes/No): ");
            string loop = Console.ReadLine();
            if ( loop.ToLower() == "yes")
            {
                AgeCalc();
            }
        }
        static string GetDaySuffix(int day)
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
        static string GetGreating(int hour)
        {
            if ((hour >= 0) && (hour < 12))
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
        static void OptionMenu()
        {
            Console.WriteLine("Select an Option: ");
            Console.WriteLine("[1]Age calculator.");
            Console.WriteLine("[2]TBC");
            Console.WriteLine("[3]TBC");
            Console.WriteLine("[4]Exit");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    AgeCalc();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }   
        static void Main()
        {
            Console.Title = "Hello, World!";
            Console.WriteLine(GetGreating(DateTime.Now.Hour) + ", " + Environment.UserName + "!");
            Console.WriteLine("Today is " + DateTime.Now.DayOfWeek + " the " + DateTime.Now.Day + GetDaySuffix(DateTime.Now.Day) + " of " + DateTime.Now.ToString("MMMM") + " " + DateTime.Now.Year);
            while (true)
            {
                OptionMenu();
            }
        }
    }
}