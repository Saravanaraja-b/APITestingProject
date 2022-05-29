using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPI
{
    public class APIExecutor
    {
        private APIHelper helper;

        public APIExecutor()
        {
            helper = new APIHelper();
        }
        public IRestResponse GetUser()
        {
            var client = helper.SetUrl("users");
            var request = helper.CreateGetRequest();
            request.RequestFormat = DataFormat.Json;
            var response = helper.GetResponse(client, request);
            var test = response.StatusCode;
            // var users = HandleContent.GetContent<Users>(response);
            return response;

        }

        public IRestResponse createNewUser(dynamic payload)
        {
            var client = helper.SetUrl("posts");
            var jsonstring = ContentHandler.SerializeJsonString(payload);
            var request = helper.CreatePostRequest(jsonstring);
            var response = helper.GetResponse(client, request);
            // var createuser = HandleContent.GetContent<CreateUserResponse>(response);
            return response;
        }
    }
}
