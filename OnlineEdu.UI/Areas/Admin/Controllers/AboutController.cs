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
            var values = await _httpClient.GetFromJsonAsync<List<ResultAboutDto>>("abouts");
            return View(values);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _httpClient.DeleteAsync($"abouts/{id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet] //Default Get zaten
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutDto createAboutDto)
        {
            await _httpClient.PostAsJsonAsync("abouts", createAboutDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var value = await _httpClient.GetFromJsonAsync<UpdateAboutDto>($"abouts/{id}");
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateAboutDto updateAboutDto)
        {
            await _httpClient.PutAsJsonAsync("abouts", updateAboutDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
