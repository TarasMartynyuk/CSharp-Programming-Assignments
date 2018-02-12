using System.Windows;

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
            var infoPanelViewModel = new BirthDateInfoViewModel();
            InfoShowGrid.DataContext = 
            //DataContext = InfoShowGrid.DataContext;
            DataContext = new MainWindowViewModel(infoPanelViewModel);
            InfoShowGrid.DataContext = infoPanelViewModel;
        }
    }
}
