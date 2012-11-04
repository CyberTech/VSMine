using KoiSoft.VSMine.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using VSMine.Model;
using VSMine.RedmineService;
using VSMine.RedmineService.Providers;

namespace KoiSoft.VSMine.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public IRedmine RedmineService { get; protected set; }

        /// <summary>
        /// List of retrieved issues
        /// </summary>
        public FastObservableCollection<Issue> Issues { get; set; }

        public ICollectionView IssuesView { get; set; }

        private bool _isLoading;
        /// <summary>
        /// Is loading sth in background
        /// </summary>
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                RaisePropertyChanged("IsLoading");
            }
        }

        #region Commands

        private ICommand _refreshCommand;
        /// <summary>
        /// Refresh viewed data
        /// </summary>
        public ICommand RefreshCommand
        {
            get
            {
                if (_refreshCommand == null)
                {
                    _refreshCommand = new RelayCommand(p => Refresh());
                }
                return _refreshCommand;
            }
        }

        #endregion

        public MainViewModel()
        {
            Issues = new FastObservableCollection<Issue>();
            IssuesView = CollectionViewSource.GetDefaultView(Issues);
            IssuesView.GroupDescriptions.Add(new PropertyGroupDescription("AssignedTo"));

            RedmineService = new RestSharpRedmineProvider();
            RedmineService.Init(VSMinePackage.Options.RedmineBaseURL,
                                VSMinePackage.Options.RedmineUsername,
                                VSMinePackage.Options.RedminePassword);
        }

        public void OnLoaded()
        {

        }

        private async void Refresh()
        {
            IsLoading = true;

            var issues = await RedmineService.GetIssues();

            Issues.Clear();
            Issues.AddRange(issues);

            IsLoading = false;
        }
    }
}
