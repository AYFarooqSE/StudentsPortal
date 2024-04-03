using Microsoft.AspNetCore.Mvc;
using StudentPortal_Web.Models;
namespace StudentPortal_Web.Controllers
{
    public class StudentPortalController : Controller
    {
        private IHttpClientFactory _clientFactory;
        public string BaseUrl = "https://localhost:7001/api/Students";
        public StudentPortalController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<IActionResult> Index()
        {
            string Error=string.Empty;

            var url = BaseUrl;
            StudentsModel studentsInfo;
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            HttpResponseMessage respone = await client.SendAsync(request);
            if (respone.IsSuccessStatusCode)
            {
                studentsInfo = await respone.Content.ReadFromJsonAsync<StudentsModel>();
                return Json(studentsInfo);
            }
            else
            {
                Error = $"Error: {respone.ReasonPhrase}";
                return Json(Error);
            }
        }
    }
}
