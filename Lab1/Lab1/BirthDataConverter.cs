using System;
using System.Diagnostics;

namespace Lab1
{
    static class BirthDataConverter
    {
        public static bool IsBirthday(DateTime birthDate)
        {
            if(IsValidBirthDate(birthDate) == false)
            {
                throw new ArgumentException("not valid birthDate");
            }
            return DateTime.Now.DayOfYear == birthDate.DayOfYear;
        }

        public static int CalculateAge(DateTime birthDate)
        {
            return DateTime.Now.Year - birthDate.Year;
        }

        public static bool IsValidBirthDate(DateTime birthDate)
        {
            return IsValidAge(CalculateAge(birthDate));
        }

        private static bool IsValidAge(int age)
        {
            return age > 0 && age <= 130;
        }
    }
}
