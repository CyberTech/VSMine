using EnvDTE;
using KoiSoft.VSMine.OptionScreens;
using KoiSoft.VSMine.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VSMine.RedmineService;
using VSMine.RedmineService.Providers;

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