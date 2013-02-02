namespace KoiSoft.VSMine.Services.Providers
{
    public class SettingsService : ISettingsService
    {
        public string LastSelectedProject
        {
            get
            {
                return KoiSoft.VSMine.Properties.Settings.Default.LastSelectedProject;
            }
            set
            {
                KoiSoft.VSMine.Properties.Settings.Default.LastSelectedProject = value;
                KoiSoft.VSMine.Properties.Settings.Default.Save();
            }
        }
    }
}
