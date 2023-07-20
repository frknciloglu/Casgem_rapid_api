using Casgem_rapid_api.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Casgem_rapid_api.Controllers
{
    public class CityLocationController : Controller
    {
        public async Task< IActionResult> Index(string cityname="İstanbul")
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityname}&locale=tr"),
                Headers =
    {
        { "X-RapidAPI-Key", "a4948724afmshaa9c5b71825be50p1025dcjsn90ee7c95d604" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<List<LocationCityNameViewModel>>(body);
                return View(value.Take(1).ToList());
            }
        }
    }
}
