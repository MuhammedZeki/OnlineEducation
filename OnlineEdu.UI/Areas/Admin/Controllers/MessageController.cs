using Microsoft.AspNetCore.Mvc;
using OnlineEdu.UI.DTOs.MessageDTOs;

namespace OnlineEdu.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/message")]
    public class MessageController(IHttpClientFactory httpClientFactory) : Controller
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient("OnlineEduApi");

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultMessageDto>>("messages");
            return View(values);
        }

        [HttpPost("delete-message/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _httpClient.DeleteAsync($"messages/{id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("create-message")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create-message")]
        public async Task<IActionResult> Create(CreateMessageDto messageDto)
        {
            await _httpClient.PostAsJsonAsync("messages", messageDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("update-message/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var value = await _httpClient.GetFromJsonAsync<UpdateMessageDto>($"messages/{id}");
            return View(value);
        }


        [HttpPost("update-message/{id}")]
        public async Task<IActionResult> Update( UpdateMessageDto messageDto)
        {
            await _httpClient.PutAsJsonAsync("messages", messageDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
