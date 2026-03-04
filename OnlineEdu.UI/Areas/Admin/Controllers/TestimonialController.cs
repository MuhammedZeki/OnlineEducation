using Microsoft.AspNetCore.Mvc;
using OnlineEdu.UI.DTOs.TestimonialDTOs;

namespace OnlineEdu.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController(IHttpClientFactory httpClientFactory) : Controller
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient("OnlineEduApi");

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultTestimonialDto>>("testimonials");
            return View(values);
        }



        [HttpGet]
        public async Task<IActionResult> Delete(int id) {
            await _httpClient.DeleteAsync($"testimonials/{id}");
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateTestimonialDto dto)
        {
            await _httpClient.PostAsJsonAsync("testimonials", dto);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var value = await _httpClient.GetFromJsonAsync<UpdateTestimonialDto>($"testimonials/{id}");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateTestimonialDto dto)
        {
            await _httpClient.PutAsJsonAsync("testimonials", dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
