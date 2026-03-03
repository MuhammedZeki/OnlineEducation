using Microsoft.AspNetCore.Mvc;
using OnlineEdu.UI.DTOs.ContactDTOs;

namespace OnlineEdu.UI.Areas.Admin.Controllers
{   
    [Area("Admin")]
    public class ContactController(IHttpClientFactory httpClientFactory) : Controller
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient("OnlineEduApi");
        public async Task<IActionResult> Index()
        {
            var results =await _httpClient.GetFromJsonAsync<List<ResultContactDto>>("contacts");
            return View(results);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _httpClient.DeleteAsync($"contacts/{id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContactDto createContactDto)
        {
            await _httpClient.PostAsJsonAsync("contacts", createContactDto);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id) {
            var value = await _httpClient.GetFromJsonAsync<UpdateContactDto>($"contacts/{id}");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateContactDto updateContactDto) {
            await _httpClient.PutAsJsonAsync("contacts", updateContactDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
