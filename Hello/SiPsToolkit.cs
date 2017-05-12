//This is a play area as I learn to write in C#
namespace Hello
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Text;
    class Toolkit
    {
        static void ReadIt(string args)
        {
            if (args.Length == 0)
                throw new ArgumentNullException("File Name", "you must supply a file name as an argument");

            string fileName = args;

        Start:

            try
            {
                using (StreamReader reader = new StreamReader(new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
                {
                    //start at the end of the file
                    long lastMaxOffset = reader.BaseStream.Length;

                    while (true) //needs an escape
                    {
                        System.Threading.Thread.Sleep(100);

                        //if the file size has not changed, idle
                        if (reader.BaseStream.Length == lastMaxOffset)
                            continue;

                        //seek to the last max offset
                        reader.BaseStream.Seek(lastMaxOffset, SeekOrigin.Begin);

                        //read out of the file until the EOF
                        string line = "";
                        while ((line = reader.ReadLine()) != null)
                            Console.WriteLine(line);

                        //update the last max offset
                        lastMaxOffset = reader.BaseStream.Position;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                //prompt user to restart
                Console.Write("Would you like to try re-opening the file? Y/N:");
                if (Console.ReadLine().ToUpper() == "Y")
                    goto Start;
            }

        }

        static void ReadFile()
        {
            Start:
            Console.Clear();
            Console.WriteLine("Please give me a path to a txt file!");
            string location = @Console.ReadLine();
            //need to add a section to print the last few lines
            ReadIt(location);

            Console.Write("Would you like to do another?(Yes/No): ");
            string loop = Console.ReadLine();
            if (loop.ToLower() == "yes")
                goto Start;
        }
        static void AgeCalc()
        {
            Start:
            Console.Clear();
            Console.Write("Enter DoB (dd/mm/yyyy): ");
            string babyBorn = Console.ReadLine();
            DateTime babyDoB = DateTime.ParseExact(babyBorn, "d/M/yyyy", CultureInfo.InvariantCulture);
            TimeSpan timeSince = DateTime.Now.Subtract(babyDoB);
            int yearsSince = (DateTime.Now.Year - babyDoB.Year);
            int monthsSince = ((yearsSince * 12) + (DateTime.Now.Month - babyDoB.Month));
            Console.WriteLine("Your Age is:");
            Console.WriteLine($"             {yearsSince} years old.");
            Console.WriteLine($"             {monthsSince} months old.");
            Console.WriteLine($"             {timeSince.Days / 7} weeks old.");
            Console.WriteLine($"             {timeSince.Days} days old.");
            Console.WriteLine($"             {(int)timeSince.TotalHours} hours old.");
            Console.WriteLine($"             {(int)timeSince.TotalMinutes} minutes old.");          
            Console.Write("Would you like to do another?(Yes/No): ");
            string loop = Console.ReadLine();
            if (loop.ToLower() == "yes")
                goto Start;
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
            Console.WriteLine("[2]Read File");
            Console.WriteLine("[3]TBC");
            Console.WriteLine("[4]Exit");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    AgeCalc();
                    break;
                case 2:
                    ReadFile();
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
        static void Welcome()
        {
            Console.Title = "Hello, World!";
            Console.WriteLine(GetGreating(DateTime.Now.Hour) + ", " + Environment.UserName + "!");
            Console.WriteLine("Today is " + DateTime.Now.DayOfWeek + " the " + DateTime.Now.Day + GetDaySuffix(DateTime.Now.Day) + " of " + DateTime.Now.ToString("MMMM") + " " + DateTime.Now.Year);
        }
        static void Main()
        {
            while (true)
            {
                Welcome();
                OptionMenu();
                Console.Clear();               
            }
        }
    }
}