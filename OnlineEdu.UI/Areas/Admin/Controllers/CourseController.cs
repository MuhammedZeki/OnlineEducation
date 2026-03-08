using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdu.UI.DTOs.BlogCategoryDTOs;
using OnlineEdu.UI.DTOs.ContactDTOs;
using OnlineEdu.UI.DTOs.CourseCategoryDTOs;
using OnlineEdu.UI.DTOs.CourseDTOs;

namespace OnlineEdu.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController(IHttpClientFactory httpClientFactory) : Controller
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient("OnlineEduApi");

        public async Task CategoryList()
        {
            var categories = await _httpClient.GetFromJsonAsync<List<ResultCourseCategoryDto>>("coursecategories");

            if (categories == null)
                categories = new List<ResultCourseCategoryDto>();

            List<SelectListItem> categorySelectList = categories.Select(c => new SelectListItem
            {
                Text = c.Name,                
                Value = c.CourseCategoryId.ToString()
            }).ToList();

            ViewBag.Categories = categorySelectList;
        }


        public async Task<IActionResult> Index()
        {
            var results = await _httpClient.GetFromJsonAsync<List<ResultCourseDto>>("courses");
            return View(results);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _httpClient.DeleteAsync($"courses/{id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await CategoryList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseDto createCourseDto)
        {
            await CategoryList();
            await _httpClient.PostAsJsonAsync("courses", createCourseDto);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            await CategoryList();
            var value = await _httpClient.GetFromJsonAsync<UpdateCourseDto>($"courses/{id}");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCourseDto updateCourseDto)
        {
            await CategoryList();
            await _httpClient.PutAsJsonAsync("courses", updateCourseDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
