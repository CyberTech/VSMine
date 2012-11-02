using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KoiSoft.VSMine.OptionScreens
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [Guid("FB726633-127C-4D72-B974-3DB121115035")]
    public class VSMineOptions : Microsoft.VisualStudio.Shell.DialogPage
    {
        private string _redmineBaseUrl;
        /// <summary>
        /// Base URL for redmine instance
        /// </summary>
        [Category("VSMine")]
        [DisplayName("Redmine Base URL")]
        [Description("Redmine Base URL")]
        public string RedmineBaseURL
        {
            get { return _redmineBaseUrl; }
            set { _redmineBaseUrl = value; }
        }

        private string _redmineUsername;
        /// <summary>
        /// Base URL for redmine instance
        /// </summary>
        [Category("VSMine")]
        [DisplayName("Redmine Username")]
        [Description("Username to use when connecting with Redmine")]
        public string RedmineUsername
        {
            get { return _redmineUsername; }
            set { _redmineUsername = value; }
        }

        private string _redminePassword;
        /// <summary>
        /// Base URL for redmine instance
        /// </summary>
        [Category("VSMine")]
        [DisplayName("Redmine Password")]
        [Description("User password to use when connecting with Redmine")]
        [PasswordPropertyText(true)]
        public string RedminePassword
        {
            get { return _redminePassword; }
            set { _redminePassword = value; }
        }
    }
}
