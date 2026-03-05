using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdu.UI.DTOs.BlogCategoryDTOs;
using OnlineEdu.UI.DTOs.BlogDTOs;

namespace OnlineEdu.UI.Areas.Admin.Controllers
{   
    [Area("Admin")]
    public class BlogController(IHttpClientFactory httpClientFactory) : Controller
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient("OnlineEduApi");

        public async Task CategoryList()
        {
            var categories = await _httpClient.GetFromJsonAsync<List<ResultBlogCategoryDto>>("blogcategories");
            
            if (categories == null)
                categories = new List<ResultBlogCategoryDto>();

            List<SelectListItem> categorySelectList = categories.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.BlogCategoryId.ToString()
            }).ToList();

            ViewBag.Categories = categorySelectList;
        }

        public async Task<IActionResult> Index()
        {
            var results = await _httpClient.GetFromJsonAsync<List<ResultBlogDto>>("blogs");
            return View(results);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"blogs/{id}");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await CategoryList();
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogDto createBlogDto)
        {
            var response = await _httpClient.PostAsJsonAsync("blogs", createBlogDto);
            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Blog oluşturulamadı.");
                return View(createBlogDto);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }
            await CategoryList();
            var result = await _httpClient.GetFromJsonAsync<UpdateBlogDto>($"blogs/{id}");
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBlogDto updateBlogDto)
        {
            var response = await _httpClient.PutAsJsonAsync("blogs", updateBlogDto);
            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Blog güncellenemedi.");
                return View(updateBlogDto);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
