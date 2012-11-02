using EnvDTE;
using KoiSoft.VSMine.OptionScreens;
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

namespace KoiSoft.VSMine.Controls
{
    /// <summary>
    /// Interaction logic for MyControl.xaml
    /// </summary>
    public partial class MyControl : UserControl
    {
        public MyControl()
        {
            InitializeComponent();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions")]
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(string.Format(System.Globalization.CultureInfo.CurrentUICulture, "We are inside {0}.button1_Click()", this.ToString()),
                            "Redmine Tasks");

            IRedmine redmineService = new RestSharpRedmineProvider();
            redmineService.Init(VSMinePackage.Options.RedmineBaseURL,
                                VSMinePackage.Options.RedmineUsername,
                                VSMinePackage.Options.RedminePassword);
            redmineService.GetIssues();

        }
    }
}