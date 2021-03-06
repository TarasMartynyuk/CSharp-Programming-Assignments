﻿using System;
using System.Windows;

namespace Lab1
{
    //Looks like this should be a model, not a viewModel
    /// <summary>
    /// represents the panel that shows age, zodiac and astrological sign
    /// </summary>
    internal class BirthDateInfoViewModel : BaseViewModel
    {
        public Visibility Visibility
        {
            get => _visibility;
            private set
            {
                if(_visibility != value)
                {
                    _visibility = value;
                    NotifyPropertyChanged();
                }
            }
        
        }

        public string AgeText
        {
            get => _ageText;
            private set
            {
                if(_ageText != value)
                {
                    _ageText = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public AstrologicalSign AstrologicalSign
        {
            get => _astrologicalSign;
            private set
            {
                if(_astrologicalSign != value)
                {
                    _astrologicalSign = value;
                    NotifyPropertyChanged();
                }

            }
        }

        public ZodiacSign ZodiacSign
        {
            get => _zodiacSign;
            private set
            {
                if(_zodiacSign != value)
                {
                    _zodiacSign = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _ageText;
        private AstrologicalSign _astrologicalSign;
        private ZodiacSign _zodiacSign;
        private Visibility _visibility;

        internal BirthDateInfoViewModel()
        {
            Visibility = Visibility.Collapsed;
        }

        internal void ShowBirthDateInfo(DateTime birthDate)
        {
            if(BirthDataConverter.IsValidBirthDate(birthDate) == false)
            {
                throw new ArgumentException("not valid birthDate");
            }
            Visibility = Visibility.Visible;
            AgeText = BirthDataConverter.CalculateAge(birthDate).ToString();
            AstrologicalSign = GetAstrologicalSignForDate(birthDate);
            ZodiacSign = CalculateZodiacSign(birthDate);
        }

        private static AstrologicalSign GetAstrologicalSignForDate(DateTime birthDate)
        {
            const int astrologicalYearStartMonth = 3;

            //Console.WriteLine("birthDate.DayOfYear: {0}", birthDate.DayOfYear);
            int monthOrdinalFromMarch = birthDate.DayOfYear / 31 - astrologicalYearStartMonth;

            //Console.WriteLine("monthOrdinalFromMarch" + monthOrdinalFromMarch);
            if(monthOrdinalFromMarch < 0)
            {
                monthOrdinalFromMarch += 12;
            }
            return (AstrologicalSign) monthOrdinalFromMarch;
        }

        private static ZodiacSign CalculateZodiacSign(DateTime birthDate)
        {
            // the first year when the cycle would start after 0th yearAD
            const int firstCycleStartAD = 4;
            int inCycleYear = (birthDate.Year - firstCycleStartAD) % 12;
            return (ZodiacSign) inCycleYear;
        }
    }
}