using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Lab1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            
        }

        //private async Task ExecuteTestAsync()
        //{
        //    int x = await DateSubmitExecuteAsync(1);
        //    MessageBox.Show("ExecuteTest method last line, x = " + x);
        //}

        //private async Task<int> DateSubmitExecuteAsync(object o)
        //{
        //    int x = await Task.Run(() => SyncLongRunningMethod());
        //    return x;
        //}

        //private int SyncLongRunningMethod()
        //{
        //    Thread.Sleep(4000);
        //    MessageBox.Show("ShowAgeAndZodiacsTask last line");
        //    return 19;
        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    ExecuteTestAsync();
        //    MessageBox.Show("Button_Click last line");
        //}
    }
}
