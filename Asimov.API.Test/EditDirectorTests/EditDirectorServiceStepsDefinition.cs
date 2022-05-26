using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Asimov.API.Security.Domain.Services.Communication;
using Microsoft.AspNetCore.Mvc.Testing;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace Asimov.API.Tests.EditDirectorTests
{
    [Binding]
    public class EditDirectorServiceStepsDefinition
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient Client { get; set; }
        private HttpClient ClientDirector { get; set; }
        private Uri BaseUri { get; set; }
        private Task<HttpResponseMessage> Response { get; set; }
        
        public EditDirectorServiceStepsDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        
        [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/directors is available")]
        public void GivenTheEndpointHttpsLocalhostApiVDirectorsIsAvailable(int port, int version)
        {
            BaseUri = new Uri($"https://localhost:{port}/api/v{version}/directors");
            Client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = BaseUri});
            ClientDirector = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("https://localhost:5001/auth/sign-up/director")
                    
            });
        }

        [Given(@"A Director is already stored in Director's Data Base")]
        public async void GivenADirectorIsAlreadyStoredInDirectorsDataBase(Table existingDirectorResource)
        {
            var directorUri = new Uri("https://localhost:5001/auth/sign-up/director");
            var resource = existingDirectorResource.CreateSet<RegisterRequestDirector>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            await ClientDirector.PostAsync(directorUri, content);
        }

        [When(@"A Update Request to Director (.*) profile is sent")]
        public void WhenAUpdateRequestToDirectorProfileIsSent(int idDirector, Table updateDirectorResource)
        {
            var resource = updateDirectorResource.CreateSet<UpdateRequestDirector>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = Client.PutAsync(idDirector.ToString(), content);
        }

        [Then(@"A Response with Status (.*) is received a Director")]
        public void ThenAResponseWithStatusIsReceivedADirector(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode = Response.Result.StatusCode.ToString();
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Then(@"A Message of ""(.*)"" is included in Response Body of Director")]
        public void ThenAMessageOfIsIncludedInResponseBodyOfDirector(string expectedMessage)
        {
            var jsonExpectedMessage = expectedMessage.ToJson();
            var actualMessage = Response.Result.Content.ReadAsStringAsync().Result;
            var validMessage = actualMessage.Contains(jsonExpectedMessage);
            Assert.True(validMessage);
        }
    }
}