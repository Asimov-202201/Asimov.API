using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Asimov.API.Directors.Resources;
using Asimov.API.Security.Domain.Services.Communication;
using Asimov.API.Teachers.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace Asimov.API.Tests.TeacherTests
{
    [Binding]
    public class TeacherServiceStepsDefinition
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient Client { get; set; }
        private Uri BaseUri { get; set; }
        private Task<HttpResponseMessage> Response { get; set; }
        private TeacherResource Teacher { get; set; }
        private DirectorResource Director { get; set; }
        
        public TeacherServiceStepsDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        
        [Given(@"the Endpoint https://localhost:(.*)/auth/sign-up/teacher is available")]
        public void GivenTheEndpointHttpsLocalhostAuthSignUpTeacherIsAvailable(int port)
        {
            BaseUri = new Uri($"https://localhost:{port}/auth/sign-up/teacher");
            Client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = BaseUri});
        }
        
        [Given(@"A Director is already registered")]
        public async void GivenADirectorIsAlreadyRegistered(Table existingDirectorResource)
        {
            var directorUri = new Uri("https://localhost:5001/auth/sign-up/director");
            var resource = existingDirectorResource.CreateSet<RegisterRequestDirector>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            await Client.PostAsync(directorUri, content);
        }
        
        [When(@"A Post Request is sent to Teacher")]
        public void WhenAPostRequestIsSentToTeacher(Table saveTeacherResource)
        {
            var resource = saveTeacherResource.CreateSet<RegisterRequestTeacher>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = Client.PostAsync(BaseUri, content);
        }

        [Then(@"A Response with Status (.*) is received in Teacher")]
        public void ThenAResponseWithStatusIsReceivedInTeacher(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode = Response.Result.StatusCode.ToString();
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Then(@"A Message of ""(.*)"" is included in Response Body of Teacher")]
        public void ThenAMessageOfIsIncludedInResponseBodyOfTeacher(string expectedMessage)
        {
            var jsonExpectedMessage = expectedMessage.ToJson();
            var actualMessage = Response.Result.Content.ReadAsStringAsync().Result;
            var validMessage = actualMessage.Contains(jsonExpectedMessage);
            Assert.True(validMessage);
        }
    }
}