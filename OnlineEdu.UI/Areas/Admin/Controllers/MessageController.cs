using Microsoft.AspNetCore.Mvc;
using OnlineEdu.UI.DTOs.MessageDTOs;

namespace OnlineEdu.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController(IHttpClientFactory httpClientFactory) : Controller
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient("OnlineEduApi");

        public async Task<IActionResult> Index()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultMessageDto>>("messages");
            return View(values);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _httpClient.DeleteAsync($"messages/{id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMessageDto messageDto)
        {
            await _httpClient.PostAsJsonAsync("messages", messageDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var value = await _httpClient.GetFromJsonAsync<UpdateMessageDto>($"messages/{id}");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update( UpdateMessageDto updateMessageDto)
        {
            await _httpClient.PutAsJsonAsync($"messages/{updateMessageDto.MessageId}", updateMessageDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
