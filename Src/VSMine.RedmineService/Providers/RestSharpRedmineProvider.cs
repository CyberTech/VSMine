﻿using RestSharp;
using System;
using System.Collections.Generic;
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

        private bool _isInitialized;

        public void Init(string baseUrl)
        {
            this._baseUrl = baseUrl;
            _isInitialized = true;
        }

        public void Init(string baseUrl, string userName, string password)
        {
            this._baseUrl = baseUrl.StartsWith("http://") ? baseUrl : "http://" + baseUrl;
            this._userName = userName;
            this._password = password;

            _isInitialized = true;
        }

        public Task<IList<Issue>> GetIssues(Project project)
        {
            CheckIfInitialized();

            return Task.Run<IList<Issue>>(() =>
            {
                var client = new RestClient(_baseUrl);
                if (!String.IsNullOrEmpty(_userName))
                {
                    client.Authenticator = new HttpBasicAuthenticator(_userName, _password);
                }

                var request = new RestRequest("issues.json?project_id={projectId}&limit={limit}");
                request.AddUrlSegment("projectId", project.Id);
                request.AddUrlSegment("limit", "100");

                var response = client.Execute<GetIssuesResponse>(request);
                return response.Data.Issues;
            });
        }

        public Task<IList<Project>> GetProjects()
        {
            CheckIfInitialized();

            return Task.Run<IList<Project>>(() =>
            {
                var client = new RestClient(_baseUrl);
                if (!String.IsNullOrEmpty(_userName))
                {
                    client.Authenticator = new HttpBasicAuthenticator(_userName, _password);
                }

                var request = new RestRequest("projects.json");
                var response = client.Execute<GetProjectsResponse>(request);
                return response.Data.Projects;
            });
        }

        private void CheckIfInitialized()
        {
            if (!_isInitialized)
            {
                throw new InvalidOperationException("Redmine Service wasn't initialized yet!");
            }
        }
    }
}
