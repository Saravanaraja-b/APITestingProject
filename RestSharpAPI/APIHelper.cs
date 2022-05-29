using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPI
{
    public class APIHelper
    {
        private RestClient client;
        private RestRequest request;
        private const string baseUrl = @"https://jsonplaceholder.typicode.com/";

        public RestClient SetUrl(string endpoint)
        {
            var uri = Path.Combine(baseUrl, endpoint);
            client = new RestClient(uri);
            return client;
        }
        public RestRequest CreateGetRequest()
        {
            request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            return request;
        }

        public RestRequest CreatePostRequest(string payload)
        {
            request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", payload, ParameterType.RequestBody);
            return request;
        }

        public IRestResponse GetResponse(RestClient client, RestRequest restRequest)
        {
            return client.Execute(restRequest);
        }
    }
}
