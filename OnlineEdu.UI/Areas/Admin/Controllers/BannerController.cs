using Microsoft.AspNetCore.Mvc;
using OnlineEdu.UI.DTOs.BannerDTOs;

namespace OnlineEdu.UI.Areas.Admin.Controllers
{   
    [Area("Admin")]
    public class BannerController(IHttpClientFactory httpClientFactory) : Controller
    {

        private readonly HttpClient _httpClient = httpClientFactory.CreateClient("OnlineEduApi");

        public async Task<IActionResult> Index()
        {
            var results = await _httpClient.GetFromJsonAsync<List<ResultBannerDto>>("banners");
            return View(results);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _httpClient.DeleteAsync($"banners/{id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBannerDto createBannerDto)
        {
            await _httpClient.PostAsJsonAsync("banners", createBannerDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var value = await _httpClient.GetFromJsonAsync<UpdateBannerDto>($"banners/{id}");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBannerDto updateBannerDto)
        {
            await _httpClient.PutAsJsonAsync("banners", updateBannerDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
