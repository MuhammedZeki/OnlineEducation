using Microsoft.AspNetCore.Mvc;
using OnlineEdu.UI.DTOs.CourseDTOs;

namespace OnlineEdu.UI.ViewComponents.Home
{
    public class HomeCourseViewComponent(IHttpClientFactory httpClientFactory) :ViewComponent
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient("OnlineEduApi");

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var results = await _httpClient.GetFromJsonAsync<List<ResultCourseDto>>("courses/getActiveCourse");
            return View(results);
        }
    }
}
