using System;
//unused using

namespace Lab1
{
    internal static class BirthDataConverter
    {
        internal static bool IsBirthday(DateTime birthDate)
        {
            if(IsValidBirthDate(birthDate) == false)
            {
                throw new ArgumentException("not valid birthDate");
            }
            return DateTime.Now.DayOfYear == birthDate.DayOfYear;
        }

        internal static int CalculateAge(DateTime birthDate)
        {
            return DateTime.Now.Year - birthDate.Year;
        }

        internal static bool IsValidBirthDate(DateTime birthDate)
        {
            return IsValidAge(CalculateAge(birthDate));
        }

        private static bool IsValidAge(int age)
        {
            return age > 0 && age <= 130;
        }
    }
}
