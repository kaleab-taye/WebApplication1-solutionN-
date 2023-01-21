using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1_project_.Data;
using WebApplication1_project_.Models;

namespace WebApplication1_project_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Weather([FromQuery] string latitude, [FromQuery] string longitude, [FromQuery] string? altitude)
        {
            // call get api
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.met.no/weatherapi/locationforecast/2.0/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                //added to bypass 403 error
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.3");


                var getAsyncText = "compact?lat=" + latitude+ "&lon=" + longitude;
                if(altitude != null)
                {
                    getAsyncText = "https://api.met.no/weatherapi/locationforecast/2.0/complete?lat="+latitude+"&lon=" +longitude+"&altitude=" + altitude;
                }

                using (HttpResponseMessage response = await client.GetAsync(getAsyncText))
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    response.EnsureSuccessStatusCode();
                    
                    return Ok(responseContent);
                }   
             }
        }

    }
}
