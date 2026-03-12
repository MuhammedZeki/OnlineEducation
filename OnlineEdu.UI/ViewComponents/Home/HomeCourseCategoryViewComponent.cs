using Microsoft.AspNetCore.Mvc;
using OnlineEdu.UI.DTOs.CourseCategoryDTOs;

namespace OnlineEdu.UI.ViewComponents.Home
{
    public class HomeCourseCategoryViewComponent(IHttpClientFactory httpClientFactory) : ViewComponent
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient("OnlineEduApi");


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var results = await _httpClient.GetFromJsonAsync<List<ResultCourseCategoryDto>>("coursecategories/getActiveList");
            return View(results);
        }
    }
}
