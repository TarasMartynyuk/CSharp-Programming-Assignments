using System;
using System.Windows;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab1
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                //MessageBox.Show("prev: " + _birthDate.ToShortDateString() + " new: " + value.ToShortDateString());
                if(_birthDate != value)
                {
                    _birthDate = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string AgeText
        {
            get => _ageText;
            set
            {
                //MessageBox.Show("prev: " + _ageText + " new: " + value);
                if(_ageText != value)
                {
                    _ageText = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public ICommand DateSubmitCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private DateTime _birthDate = new DateTime(2017, 2, 11);
        private string _ageText = "18";

        public MainWindowViewModel()
        {
            DateSubmitCommand = new DelegateCommandAsync(DateSubmitExecuteAsync);


        }

        private async Task DateSubmitExecuteAsync(object o)
        {
            if(IsValidBirthDate(BirthDate) == false)
            {
                MessageBox.Show("Enter a valid date!", "error", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }

            if(IsBirthday(BirthDate))
            {
                MessageBox.Show("Wow, it's your birthday! Go enjoy yourself.", "your only invite today",
                    MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }

            await Task.Factory.StartNew(() => {
                 ShowAgeAndZodiacsTask(BirthDate);
            });
            await Task.Delay(2000);
            Console.WriteLine("async end");
        }

        private void ShowAgeAndZodiacsTask(DateTime birthDate)
        {
            AgeText = AgeFromBirthDate(birthDate).ToString();
        }

        private static bool IsValidBirthDate(DateTime birthDate)
        {
            return IsValidAge(AgeFromBirthDate(birthDate));
        }

        private static bool IsBirthday(DateTime birthDate)
        {
            Debug.Assert(IsValidBirthDate(birthDate));
            Console.WriteLine("Now.DayOfYear" + DateTime.Now.DayOfYear);
            Console.WriteLine("birthDate.DayOfYear" + birthDate.DayOfYear);
            return DateTime.Now.DayOfYear == birthDate.DayOfYear;
        }

        private static bool IsValidAge(int age)
        {
            return age > 0 && age <= 130;
        }

        private static int AgeFromBirthDate(DateTime birthDate)
        {
            return DateTime.Now.Year - birthDate.Year;
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
