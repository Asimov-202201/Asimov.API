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

namespace Asimov.API.Tests.FinishedItem
{
    [Binding]
    public class FinishedItemStepDefinition
    {
        private readonly WebApplicationFactory<Startup> _factory;
        
        private HttpClient Client { get; set; }
        private Uri BaseUri { get; set; }
        private Task<HttpResponseMessage> Response { get; set; }
        private CourseResource Course { get; set; }
        private ItemResource Item { get; set; }
        
        public FinishedItemStepDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        
        [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/items is available for FinishedItemServiceTests")]
        public void GivenTheEndpointHttpsLocalhostApiVItemsIsAvailable(int port, int version)
        {
            BaseUri = new Uri($"https://localhost:{port}/api/v{version}/items");
            Client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = BaseUri});
        }

        [Then(@"A Course is already stored in the table courses")]
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
        
        [Then(@"A Item is already stored in the table items")]
        public async void GivenAItemIsAlreadyStoredInTheTableItems(Table existingItemResource)
        {
            var itemUri = new Uri("https://localhost:5001/api/v1/items");
            var resource = existingItemResource.CreateSet<SaveItemResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            var itemResponse = Client.PostAsync(itemUri, content);
            var itemResponseData = await itemResponse.Result.Content.ReadAsStringAsync();
            var existingItem = JsonConvert.DeserializeObject<ItemResource>(itemResponseData);
            Item = existingItem;
        }
        
        [When(@"he clicks the complete button of an item (.*)")]
        public void WhenHeClicksTheCompleteButtonOfAnItem(int idItem, Table updateItemResource)
        {
            var resource = updateItemResource.CreateSet<SaveItemResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = Client.PutAsync(new Uri($"https://localhost:5001/api/v1/items/{idItem}"), content);
        }
        
        [Then(@"A Response with Status (.*) is received in Items")]
        public void ThenAResponseWithStatusIsReceivedInItems(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode = Response.Result.StatusCode.ToString();
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }
        
        [Then(@"the item will be completed and the progress of a course increases")]
        public async void ThenTheItemWillBeCompletedAndTheProgressOfACourseIncreases(Table expectedItemResource)
        {
            var expectedResource = expectedItemResource.CreateSet<ItemResource>().First();
            var responseData = await Response.Result.Content.ReadAsStringAsync();
            var resource = JsonConvert.DeserializeObject<ItemResource>(responseData);
            expectedResource.Id = resource.Id;
            var jsonExpectedResource = expectedResource.ToJson();
            var jsonActualResource = resource.ToJson();
            Assert.Equal(jsonExpectedResource, jsonActualResource);
        }
    }
}