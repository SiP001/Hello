namespace Hello
{
    using System;
    using System.Globalization;
    class AgeCalculator
    {
        public void AgeCalc()
        {
            Console.Title = "Age Calculator";
            DateTimeMethod dm = new DateTimeMethod();
            Start:
            Console.Clear();
            NoClear:
            Console.Write("Enter Date (dd/mm/yyyy) or \"Exit\": ");
            string userDateString = Console.ReadLine();
            if (userDateString.ToLower() == "exit")
            {
                goto End;
            }
            DateTime userDoB;
            if (dm.CheckDate(userDateString))
            {
                userDoB = DateTime.ParseExact(userDateString, "d/M/yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please enter a valid date");
                goto NoClear;
            }
            CalculateAge(userDoB, dm);
            Console.Write("Would you like to do another?(Yes/No): ");
            string loop = Console.ReadLine();
            if (loop.ToLower() == "yes")
                goto Start;
            End:;
        }
        private void CalculateAge(DateTime date, DateTimeMethod dm)
        {
            TimeSpan timeSince = dm.TimeSince(date);
            Console.WriteLine("Age is:");
            Console.WriteLine($"       {dm.YearsSince(date)} years old.");
            Console.WriteLine($"       {dm.MonthsSince(date)} months old.");
            Console.WriteLine($"       {timeSince.Days / 7} weeks old.");
            Console.WriteLine($"       {timeSince.Days} days old.");
            Console.WriteLine($"       {(int)timeSince.TotalHours} hours old.");
            Console.WriteLine($"       {(int)timeSince.TotalMinutes} minutes old.");
            Console.WriteLine($"       You were born on a {dm.DayOfDate(date)}");
        }
    }
}
