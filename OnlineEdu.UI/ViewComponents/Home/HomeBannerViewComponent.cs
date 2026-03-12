using Microsoft.AspNetCore.Mvc;
using OnlineEdu.UI.DTOs.BannerDTOs;

namespace OnlineEdu.UI.ViewComponents.Home
{
    public class HomeBannerViewComponent(IHttpClientFactory httpClientFactory) : ViewComponent
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient("OnlineEduApi");
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var results = await _httpClient.GetFromJsonAsync<List<ResultBannerDto>>("banners");
            return View(results);
        }
    }
}
