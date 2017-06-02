namespace Hello
{
    using System;
    using System.Globalization;
    class DateTimeMethod
    {
        public int MonthsSince(DateTime date)
        {
            int months = (((DateTime.Now.Year - date.Year) * 12) + (DateTime.Now.Month - date.Month));
            return months;
        }
        public int YearsSince(DateTime date)
        {
            int years;
            if ((DateTime.Now.Month == date.Month) && (DateTime.Now.Day == date.Day))
            {
                Console.WriteLine("It's your birthday!");
                years = (DateTime.Now.Year - date.Year);
            }
            else if (((DateTime.Now.Month == date.Month) && (DateTime.Now.Day < date.Day)) || (DateTime.Now.Month < date.Month))
            {
                years = (DateTime.Now.Year - date.Year - 1);
            }
            else
            {
                years = (DateTime.Now.Year - date.Year);
            }
            return years;
        }
        public bool CheckDate(string strDate)
        {
            try
            {
                DateTime.ParseExact(strDate, "d/M/yyyy", CultureInfo.InvariantCulture);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public TimeSpan TimeSince(DateTime date)
        {
            return DateTime.Now.Subtract(date);
        }
        public string GetDaySuffix(int day)
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
        public string GetGreating(int hour)
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
        public string DayOfDate(DateTime date)
        {
            string day = date.DayOfWeek.ToString();
            return day;
        }
    }
}
