namespace Hello
{
    using System;
    class Menu
    {
        public void WelcomeMessage()
        {
            DateTimeMethod dm = new DateTimeMethod();
            Console.WriteLine(dm.GetGreating(DateTime.Now.Hour) + ", " + Environment.UserName + "!");
            Console.WriteLine("Today is " + DateTime.Now.DayOfWeek + " the " + DateTime.Now.Day + dm.GetDaySuffix(DateTime.Now.Day) + " of " + DateTime.Now.ToString("MMMM") + " " + DateTime.Now.Year);
        }
        public void OptionMenu()
        {
            AgeCalculator ac = new AgeCalculator();
            TextReader tr = new TextReader();
            Start:
            Console.WriteLine("Select an Option: ");
            Console.WriteLine("[1]Age calculator.");
            Console.WriteLine("[2]Read File");
            Console.WriteLine("[3]TBC");
            Console.WriteLine("[4]Exit");
            string stringOption = Console.ReadLine();
            try
            {
                Convert.ToInt32(stringOption);
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Invlaid option selected, please try again");
                goto Start;
            }
            int option = Convert.ToInt32(stringOption);
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
    }
}
