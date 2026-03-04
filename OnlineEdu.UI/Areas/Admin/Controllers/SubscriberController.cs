using Microsoft.AspNetCore.Mvc;
using OnlineEdu.UI.DTOs.SubscriberDTOs;

namespace OnlineEdu.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubscriberController(IHttpClientFactory httpClientFactory) : Controller
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient("OnlineEduApi");

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var results = await _httpClient.GetFromJsonAsync<List<ResultSubscriberDto>>("subscribers");
            return View(results);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _httpClient.DeleteAsync($"subscribers/{id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSubscriberDto dto)
        {
            await _httpClient.PostAsJsonAsync("subscribers", dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var value = await _httpClient.GetFromJsonAsync<UpdateSubscriberDto>($"subscribers/{id}");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateSubscriberDto dto)
        {
            await _httpClient.PutAsJsonAsync($"subscribers/{dto.SubscriberId}", dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
