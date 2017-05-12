using RestSharp;
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
        public string Html_Url { get; set; }
        public string Language { get; set; }

        public static List<Project> GetProjects(string project)
        {
            var client = new RestClient("https://api.github.com/users");
            var request = new RestRequest("katyisgreaty/starred", Method.GET);
            request.AddHeader("Accept", "application/vnd.github.v3+json");
            request.AddHeader("User-Agent", "katyisgreaty");
            var response= new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            var jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
            Console.WriteLine("JSON RESPONSE: " + jsonResponse);
            string jsonOutput = jsonResponse.ToString();
            var projectList = JsonConvert.DeserializeObject<List<Project>>(jsonOutput);
            //Console.WriteLine(projectList[0]);
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
