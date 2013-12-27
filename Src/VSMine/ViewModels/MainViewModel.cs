using KoiSoft.VSMine.Common;
using KoiSoft.VSMine.Services;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using VSMine.Model;
using VSMine.RedmineService;
using VSMine.RedmineService.Exceptions;
using VSMine.RedmineService.Providers;

namespace KoiSoft.VSMine.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public IRedmine RedmineService { get; protected set; }
        public ISettingsService SettingsService { get; protected set; }

        /// <summary>
        /// List of available projects
        /// </summary>
        public FastObservableCollection<Project> Projects { get; set; }

        /// <summary>
        /// List of retrieved issues
        /// </summary>
        public FastObservableCollection<Issue> Issues { get; set; }

        public FastObservableCollection<string> Errors { get; set; }

        public ICollectionView IssuesView { get; set; }

        private Project _selectedProject;
        /// <summary>
        /// SelectedProject
        /// </summary>
        public Project SelectedProject
        {
            get { return _selectedProject; }
            set
            {
                _selectedProject = value;
                RaisePropertyChanged("SelectedProject");

                if (SettingsService != null)
                {
                    if (_selectedProject == null)
                    {
                        SettingsService.LastSelectedProject = null;
                    }
                    else
                    {
                        SettingsService.LastSelectedProject = _selectedProject.Identifier;
                    }
                }
            }
        }

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

        private bool _isInitialised;

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
                    _refreshCommand = new RelayCommand(p => Refresh(), p => this.SelectedProject != null);
                }
                return _refreshCommand;
            }
        }

        #endregion

        public MainViewModel()
        {
            Projects = new FastObservableCollection<Project>();

            Issues = new FastObservableCollection<Issue>();
            IssuesView = CollectionViewSource.GetDefaultView(Issues);
            IssuesView.GroupDescriptions.Add(new PropertyGroupDescription("AssignedTo"));
            IssuesView.SortDescriptions.Add(new SortDescription("AssignedTo", ListSortDirection.Ascending));

            Errors = new FastObservableCollection<string>();

            SettingsService = new KoiSoft.VSMine.Services.Providers.SettingsService();
            RedmineService = new RestSharpRedmineProvider();

            if (!String.IsNullOrEmpty(VSMinePackage.Options.RedmineBaseURL))
            {
                RedmineService.Init(VSMinePackage.Options.RedmineBaseURL,
                                    VSMinePackage.Options.RedmineUsername,
                                    VSMinePackage.Options.RedminePassword);
            }
        }

        public async void OnLoaded()
        {
            try
            {
                if (!_isInitialised)
                {
                    await LoadProjects();
                    _isInitialised = true;
                }
                Refresh();
            }
            catch (NotInitializedException notInitializedException)
            {

            }
            catch (Exception exp)
            {
                System.Windows.MessageBox.Show(exp.ToString());
            }
        }

        private async Task LoadProjects()
        {
            IsLoading = true;

            var projects = await RedmineService.GetProjects();

            Projects.Clear();
            Projects.AddRange(projects);

            if (Projects.Count > 0)
            {
                if (!String.IsNullOrEmpty(SettingsService.LastSelectedProject))
                {
                    SelectedProject = Projects.FirstOrDefault(p => p.Identifier == SettingsService.LastSelectedProject);
                }

                if (SelectedProject == null)
                {
                    SelectedProject = Projects[0];
                }
            }

            IsLoading = false;
        }

        private async void Refresh()
        {
            try
            {
                if (this.SelectedProject != null)
                {
                    IsLoading = true;

                    var issues = await RedmineService.GetIssues(this.SelectedProject);

                    Issues.Clear();
                    Issues.AddRange(issues);

                    IsLoading = false;
                }
            }
            catch (Exception exp)
            {
                System.Windows.MessageBox.Show(exp.ToString());
            }
        }
    }
}
