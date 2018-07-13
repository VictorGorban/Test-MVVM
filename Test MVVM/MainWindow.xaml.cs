using System.Windows;

namespace Test_MVVM
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new ApplicationViewModel();

        }
        
        public void MyMethod()
        {

        }

        
    }
}