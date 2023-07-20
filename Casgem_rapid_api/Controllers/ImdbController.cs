using Casgem_rapid_api.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Casgem_rapid_api.Controllers
{
    public class ImdbController : Controller
    {
        public async Task<IActionResult> Index()
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
            {
                { "X-RapidAPI-Key", "a4948724afmshaa9c5b71825be50p1025dcjsn90ee7c95d604" },
                { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
            },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var model=JsonConvert.DeserializeObject<List<ImdbMovieListViewModel>>(body);
                return View(model.ToList());
            }
            
        }
    }
}
