namespace Hello
{
    using System;
    class Menu
    {
        public void WelcomeMessage()
        {
            Console.Title = "Hello, World!";
            Console.WriteLine(GetGreating(DateTime.Now.Hour) + ", " + Environment.UserName + "!");
            Console.WriteLine("Today is " + DateTime.Now.DayOfWeek + " the " + DateTime.Now.Day + GetDaySuffix(DateTime.Now.Day) + " of " + DateTime.Now.ToString("MMMM") + " " + DateTime.Now.Year);
            OptionMenu();
        }

        private void OptionMenu()
        {
            AgeCalculator ac = new AgeCalculator();
            TextReader tr = new TextReader();

            Console.WriteLine("Select an Option: ");
            Console.WriteLine("[1]Age calculator.");
            Console.WriteLine("[2]Read File");
            Console.WriteLine("[3]TBC");
            Console.WriteLine("[4]Exit");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    ac.AgeCalc();
                    break;
                case 2:
                    tr.ReadFile();
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

        private string GetGreating(int hour)
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

        private string GetDaySuffix(int day)
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
    }
}
