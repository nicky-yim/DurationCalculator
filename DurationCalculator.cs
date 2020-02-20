using System;

namespace DurationCalculator
{
    public class DurationCalculator
    {
        public static void Main()
        {
            DateTime startDate = new DateTime(2020, 02, 19);
            DateTime endDate = new DateTime(2084, 02, 14);
            
            Tuple<int, int, int> duration = GetDuration(startDate, endDate);
            Console.WriteLine(String.Format("{0} is {1} year(s), {2} month(s) and {3} day(s) from {4}.", 
                endDate.ToShortDateString(), duration.Item1, duration.Item2, duration.Item3, startDate.ToShortDateString()));
        }

        protected static Tuple<int, int, int> GetDuration(DateTime? startDate, DateTime? endDate)
        {
            if (startDate == null || endDate == null)
                return null;
            
            int years = 0, months = 0;
            int daysInYear = 0, daysInMonth = 0;
            int days = Math.Abs((startDate.Value - endDate.Value).Days);
            
            bool backdated = startDate.Value > endDate.Value;
            DateTime tempDate = backdated ? endDate.Value : startDate.Value;
            
            daysInYear = GetDaysInYear(tempDate.Year);
            while (days >= daysInYear)
            {
                days -= daysInYear;
                tempDate = tempDate.AddYears(1);
                years++;
                daysInYear = GetDaysInYear(tempDate.Year);
            }

            daysInMonth = DateTime.DaysInMonth(tempDate.Year, tempDate.Month);
            while (days >= daysInMonth)
            {
                days -= daysInMonth;
                tempDate = tempDate.AddMonths(1);
                months++;
                daysInMonth = DateTime.DaysInMonth(tempDate.Year, tempDate.Month);
            }

            if (backdated)
            {
                years *= -1;
                months *= -1;
                days *= -1;
            }

            return new Tuple<int, int, int>(years, months, days);
        }

        protected static int GetDaysInYear(int year)
        {
            return DateTime.IsLeapYear(year) ? 366 : 365;
        }
    }
}