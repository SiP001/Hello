namespace Hello
{
    using System;
    using System.Globalization;
    class AgeCalculator
    {
        public void AgeCalc()
        {
            Start:
            Console.Clear();
            NoClear:
            Console.Write("Enter DoB (dd/mm/yyyy) or \"Exit\": ");
            string babyBorn = Console.ReadLine();
            string loop = "";
            if (babyBorn.ToLower() == "exit")
            {
                goto End;
            }
            DateTime babyDoB;
            if (checkDoB(babyBorn))
            {
                babyDoB = DateTime.ParseExact(babyBorn, "d/M/yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please enter a valid date");
                goto NoClear;
            }
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
            loop = Console.ReadLine();
            End:
            if (loop.ToLower() == "yes")
                goto Start;   
        }
        private bool checkDoB(string born)
        {
            try
            {
                DateTime dobTest = DateTime.ParseExact(born, "d/M/yyyy", CultureInfo.InvariantCulture);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
