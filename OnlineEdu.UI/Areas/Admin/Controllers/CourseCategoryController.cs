using Microsoft.AspNetCore.Mvc;
using OnlineEdu.UI.DTOs.CourseCategoryDTOs;

namespace OnlineEdu.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseCategoryController(IHttpClientFactory httpClientFactory) : Controller
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient("OnlineEduApi");


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var results =await _httpClient.GetFromJsonAsync<List<ResultCourseCategoryDto>>("coursecategories");
            return View(results);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _httpClient.DeleteAsync($"coursecategories/{id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseCategoryDto createCourseCategoryDto)
        {
            await _httpClient.PostAsJsonAsync("coursecategories", createCourseCategoryDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var value = await _httpClient.GetFromJsonAsync<UpdateCourseCategoryDto>($"coursecategories/{id}");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCourseCategoryDto updateCourseCategoryDto)
        {
            await _httpClient.PutAsJsonAsync("coursecategories", updateCourseCategoryDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
