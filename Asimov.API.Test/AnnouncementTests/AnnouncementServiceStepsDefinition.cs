using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Asimov.API.Announcements.Resources;
using Asimov.API.Directors.Resources;
using Asimov.API.Security.Domain.Services.Communication;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace Asimov.API.Test.AnnouncementTests
{
    [Binding]
    public class AnnouncementServiceStepsDefinition
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient Client { get; set; }
        private Uri BaseUri { get; set; }
        private Task<HttpResponseMessage> Response { get; set; }
        
        private AnnouncementResource Announcement { get; set; }
        private DirectorResource Director { get; set; }
        
        public AnnouncementServiceStepsDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        
        [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/announcements is available")]
        public void GivenTheEndpointHttpsLocalhostApiVAnnouncementsIsAvailable(int port, int version)
        {
            BaseUri = new Uri($"https://localhost:{port}/api/{version}/announcements");
            Client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = BaseUri});
        }
        
        [Given(@"A Director is already stored")]
        public async void GivenADirectorIsAlreadyStored(Table existingDirectorResource)
        {
            var categoryUri = new Uri("https://localhost:5001/auth/sign-up/director");
            var resource = existingDirectorResource.CreateSet<RegisterRequestDirector>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Console.WriteLine("hello");
            var directorResponse = Client.PostAsync(categoryUri, content);
            if (directorResponse.Result.IsSuccessStatusCode)
            {
                var directorAux = await Client.GetAsync(new Uri("https://localhost:5001/api/v1/directors/1"));
                var directorResponseData = directorAux.Content.ReadAsStringAsync().Result;
                var existingDirector = JsonConvert.DeserializeObject<DirectorResource>(directorResponseData);
                Director = existingDirector;
            }
        }

        [When(@"A Post Request to Announcement is sent")]
        public void WhenAPostRequestToAnnouncementIsSent(Table saveAnnouncementResource)
        {
            var resource = saveAnnouncementResource.CreateSet<SaveAnnouncementResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = Client.PostAsync(BaseUri, content);
        }

        [Then(@"A Announcement Resource is included in Response Body")]
        public async void ThenAAnnouncementResourceIsIncludedInResponseBody(Table expectedAnnouncementResource)
        {
            var expectedResource = expectedAnnouncementResource.CreateSet<AnnouncementResource>().First();
            var responseData = await Response.Result.Content.ReadAsStringAsync();
            var resource = JsonConvert.DeserializeObject<AnnouncementResource>(responseData);
            expectedResource.Id = resource.Id;
            var jsonExpectedResource = expectedResource.ToJson();
            var jsonActualResource = resource.ToJson();
            Assert.Equal(jsonExpectedResource, jsonActualResource);
        }

        [Then(@"A Response with Status (.*) is received in Announcement")]
        public void ThenAResponseWithStatusIsReceivedInAnnouncement(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode = Response.Result.StatusCode.ToString();
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Then(@"A Message of ""(.*)"" is included in Response Body of Announcement")]
        public async void ThenAMessageOfIsIncludedInResponseBodyOfAnnouncement(string expectedMessage)
        {
            var actualMessage = await Response.Result.Content.ReadAsStringAsync();
            var jsonExpectedMessage = expectedMessage.ToJson();
            var jsonActualMessage = actualMessage.ToJson();
            Assert.Equal(jsonExpectedMessage, jsonActualMessage);
        }
    }
}