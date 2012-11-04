using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSMine.Model;

namespace VSMine.RedmineService
{
    public interface IRedmine
    {
        void Init(string baseUrl);

        void Init(string baseUrl, string userName, string password);

        Task<IList<Issue>> GetIssues(Project project);

        Task<IList<Project>> GetProjects();
    }
}
