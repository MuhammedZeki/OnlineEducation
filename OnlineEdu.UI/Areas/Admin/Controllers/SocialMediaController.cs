using Microsoft.AspNetCore.Mvc;
using OnlineEdu.UI.DTOs.SocialMediaDTOs;

namespace OnlineEdu.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SocialMediaController(IHttpClientFactory httpClientFactory) : Controller
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient("OnlineEduApi");

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values =await _httpClient.GetFromJsonAsync<List<ResultSocialMediaDto>>("socialMedias");
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _httpClient.DeleteAsync($"socialMedias/{id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSocialMediaDto dto)
        {
            await _httpClient.PostAsJsonAsync("socialMedias", dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(int id)
        {
            var value = await _httpClient.GetFromJsonAsync<UpdateSocialMediaDto>($"socialMedias/{id}");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(UpdateSocialMediaDto dto)
        {
            await _httpClient.PutAsJsonAsync($"socialMedias/{dto.SocialMediaId}", dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
