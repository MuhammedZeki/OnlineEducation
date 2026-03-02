using Microsoft.AspNetCore.Mvc;
using OnlineEdu.UI.DTOs.AboutDTOs;

namespace OnlineEdu.UI.Areas.Admin.Controllers
{


    [Area("Admin")]
    public class AboutController : Controller
    {   
        private readonly HttpClient _httpClient;

        public AboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("OnlineEduApi");
        }

        public async Task<IActionResult> Index()
        {
            var values =await _httpClient.GetFromJsonAsync<List<ResultAboutDto>>("abouts");
            return View(values);
        }
    }
}
