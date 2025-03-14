using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MLNetWebApp.Models;
using MLNetWebApp.Services;

namespace MLNetWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {

        [HttpPost("predict")]
        public IActionResult Predict([FromBody] ModelInput input, [FromServices] PredictionService predictionService)
        {
            var prediction = predictionService.Predict(input); // Returns bool
            float scores = prediction.Score; // Error if Predict returns bool
            return Ok(new { Prediction = prediction , Score = scores });
        }
    }
}
