using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSMine.Model;
using VSMine.Model.Response;

namespace VSMine.RedmineService.Providers
{
    public class RestSharpRedmineProvider : IRedmine
    {
        private string _baseUrl;
        private string _userName;
        private string _password;

        public void Init(string baseUrl)
        {
            this._baseUrl = baseUrl;
        }

        public void Init(string baseUrl, string userName, string password)
        {
            this._baseUrl = baseUrl.StartsWith("http://") ? baseUrl : "http://" + baseUrl;
            this._userName = userName;
            this._password = password;
        }

        public Task<IList<Issue>> GetIssues()
        {
            return Task.Run<IList<Issue>>(() =>
            {
                var client = new RestClient(_baseUrl);
                if (!String.IsNullOrEmpty(_userName))
                {
                    client.Authenticator = new HttpBasicAuthenticator(_userName, _password);
                }

                var request = new RestRequest("issues.json");
                var response = client.Execute<GetIssuesResponse>(request);
                return response.Data.Issues;
            });
        }
    }
}
