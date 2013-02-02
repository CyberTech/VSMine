using KoiSoft.VSMine.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace KoiSoft.VSMine.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            this.DataContext = new MainViewModel();

            InitializeComponent();
        }

        private void MainView_Loaded(object sender, RoutedEventArgs e)
        {
            MainViewModel viewModel = (MainViewModel)this.DataContext;
            viewModel.OnLoaded();
        }
    }
}