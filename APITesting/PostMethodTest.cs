using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharpAPI;
using RestSharpAPI.Models.Request;
using RestSharpAPI.Models.Response;
using System;
using System.Net;

namespace APITesting
{
    [TestClass]

    public class PostMethodTest
    {
        public TestContext TestContext { get; set; }
        public HttpStatusCode statusCode;
        [DeploymentItem("TestData\\CreateuserData.csv"),
      DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "CreateuserData.csv", "CreateuserData#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TestMethod1()
        {
            var g = TestContext.DataRow["Title"].ToString();
            var user = new UserRequestData
            {
                title = TestContext.DataRow["Title"].ToString(),
                body = TestContext.DataRow["Body"].ToString(),
                userId = TestContext.DataRow["userId"].ToString()
            };

            var api = new APIExecutor();
            var response = api.createNewUser(user);
            statusCode = response.StatusCode;
            var code = (int)statusCode;
            Assert.AreEqual(201, code);

            var usercontent = ContentHandler.GetContent<UserResponseData>(response);
            Assert.AreEqual(user.title, usercontent.title,user.title + "is not matched");
            Assert.AreEqual(user.body, usercontent.body, user.body + "is not matched");
            Assert.AreEqual(user.userId, usercontent.userId.ToString(), user.userId + "is not matched");         
        }
    }
}
