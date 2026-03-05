using Microsoft.AspNetCore.Mvc;
using OnlineEdu.UI.DTOs.BlogCategoryDTOs;
using OnlineEdu.UI.Validators.BlogCategoryValidators;

namespace OnlineEdu.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogCategoryController(IHttpClientFactory httpClientFactory) : Controller
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient("OnlineEduApi");
        public async Task<IActionResult> Index()
        {
            var results =await _httpClient.GetFromJsonAsync<List<ResultBlogCategoryDto>>("blogcategories");
            return View(results);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"blogCategories/{id}");
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogCategoryDto createBlogCategoryDto)
        {
            var validate = new CreateBlogCategoryValidator();
            var result = await validate.ValidateAsync(createBlogCategoryDto);
            if(!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(createBlogCategoryDto);
            }
            var response = await _httpClient.PostAsJsonAsync("blogCategories", createBlogCategoryDto);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Kategori oluşturulamadı.");
                return View(createBlogCategoryDto);
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

            var response = await _httpClient.GetFromJsonAsync<UpdateBlogCategoryDto>($"blogCategories/{id}");

            if (response == null)
                return RedirectToAction(nameof(Index));


            return View(response);
        }


        [HttpPost]
        public async Task<IActionResult> Update(UpdateBlogCategoryDto updateBlogCategoryDto)
        {
            var validate = new UpdateBlogCategoryValidator();
            var result = await validate.ValidateAsync(updateBlogCategoryDto);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(updateBlogCategoryDto);
            }
            var res = await _httpClient.PutAsJsonAsync($"blogCategories", updateBlogCategoryDto);
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(res);

        }
    }
}
