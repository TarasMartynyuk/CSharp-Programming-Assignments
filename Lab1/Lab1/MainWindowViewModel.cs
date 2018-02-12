using System;
using System.Windows;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab1
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Binding Properties
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

        public ICommand DateSubmitCommand { get; set; }
        #endregion

        private DateTime _birthDate = DateTime.Now;
        private readonly BirthDateInfoViewModel _birthDateInfo;

        public MainWindowViewModel()
        {
            DateSubmitCommand = new DelegateCommandAsync(DateSubmitExecuteAsync);

        }
        public MainWindowViewModel(BirthDateInfoViewModel birthDateInfo) : this()
        {
            _birthDateInfo = birthDateInfo ?? throw new ArgumentNullException(nameof(birthDateInfo));
        }

        private async Task DateSubmitExecuteAsync(object o)
        {
            if(BirthDataConverter.IsValidBirthDate(BirthDate) == false)
            {
                MessageBox.Show("Enter a valid date!", "error", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }
            if(BirthDataConverter.IsBirthday(BirthDate))
            {
                MessageBox.Show("Wow, it's your birthday! Go enjoy yourself.", "your only invite today",
                    MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }

            // make pause noticeable
            await Task.Delay(2000);
            await Task.Factory.StartNew(() => {
                _birthDateInfo.ShowBirthDateInfo(BirthDate);
            });
            
        }
    }
}
