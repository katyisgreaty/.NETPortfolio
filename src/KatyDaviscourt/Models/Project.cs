﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace KatyDaviscourt.Models
{
    [Table("Projects")]
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Language { get; set; }

        public static List<Project> GetProjects(string project)
        {
            var client = new RestClient("https://api.github.com/users/katyisgreaty/starred");
            var request = new RestRequest("", Method.GET);
            Console.WriteLine(request);
            var response= new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            Console.WriteLine(jsonResponse);
            string jsonOutput = jsonResponse.ToString();
            var projectList = JsonConvert.DeserializeObject<List<Project>>(jsonOutput);
            Console.WriteLine(projectList[0]);
            return projectList;
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}