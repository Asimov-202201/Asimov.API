using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Asimov.API.Courses.Resources;
using Asimov.API.Items.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace Asimov.API.Tests.ItemTests
{
    [Binding]
    public class ItemServiceStepDefinition
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient Client { get; set; }
        private Uri BaseUri { get; set; }
        private Task<HttpResponseMessage> Response { get; set; }
        private CourseResource Course { get; set; }
        private ItemResource Item { get; set; }
        
        public ItemServiceStepDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/items is available")]
        public void GivenTheEndpointHttpsLocalhostApiVItemsIsAvailable(int port, int version)
        {
            BaseUri = new Uri($"https://localhost:{port}/api/v{version}/items");
            Client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = BaseUri});
        }

        [When(@"A Course is already stored")]
        public async void GivenACourseIsAlreadyStored(Table existingCourseResource)
        {
            var courseUri = new Uri("https://localhost:5001/api/v1/courses");
            var resource = existingCourseResource.CreateSet<SaveCourseResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            var courseResponse = Client.PostAsync(courseUri, content);
            var courseResponseData = await courseResponse.Result.Content.ReadAsStringAsync();
            var existingCourse = JsonConvert.DeserializeObject<CourseResource>(courseResponseData);
            Course = existingCourse;
        }
        //Scenario Add Item
        [When(@"A Post Request is sent to Item")]
        public void WhenAPostRequestIsSentToItem(Table saveItemResource)
        {
            var resource = saveItemResource.CreateSet<SaveItemResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = Client.PostAsync(BaseUri, content);
        }

        [Then(@"A Response with Status (.*) is received in Item")]
        public void ThenAResponseWithStatusIsReceivedInItem(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode = Response.Result.StatusCode.ToString();
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Then(@"A Item Resource is included in Response Body")]
        public async void ThenAItemResourceIsIncludedInResponseBody(Table expectedItemResource)
        {
            var expectedResource = expectedItemResource.CreateSet<ItemResource>().First();
            var responseData = await Response.Result.Content.ReadAsStringAsync();
            var resource = JsonConvert.DeserializeObject<ItemResource>(responseData);
            expectedResource.Id = resource.Id;
            var jsonExpectedResource = expectedResource.ToJson();
            var jsonActualResource = resource.ToJson();
            Assert.Equal(jsonExpectedResource, jsonActualResource);
        }
        //Scenario Add Item with Invalid Course
        [Then(@"A message of (.*) is included in Response Body")]
        public async void ThenAMessageOfIsIncludedInResponseBody(string expectedMessage)
        {
            var actualMessage = await Response.Result.Content.ReadAsStringAsync();
            var jsonExpectedMessage = expectedMessage.ToJson();
            var jsonActualMessage = actualMessage.ToJson();
            Assert.Equal(jsonExpectedMessage, jsonActualMessage);
        }
    }
}