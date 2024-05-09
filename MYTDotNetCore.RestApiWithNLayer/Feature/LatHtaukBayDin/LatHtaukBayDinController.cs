using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using MYTDotNetCore.RestApiWithNLayer.Models;
using Newtonsoft.Json;

namespace MYTDotNetCore.RestApiWithNLayer.Feature.LatHtaukBayDin
{


    [Route("api/[controller]")]
    [ApiController]
    public class LatHtaukBayDinController : ControllerBase
    {
        private async Task<Models.LatHtaukBayDin> GetDataAsync()
        {
            string jsonStr = await System.IO.File.ReadAllTextAsync("data.json");
            var model = JsonConvert.DeserializeObject<Models.LatHtaukBayDin>(jsonStr);
            return model;
        }

        [HttpGet("questions")]
        public async Task<IActionResult> Question()
        {
            var model = await GetDataAsync();
            return Ok(model.questions);
        }
        
        [HttpGet("numberList")]
        public async Task<IActionResult> NumberLists()
        {
            var model = await GetDataAsync();
            return Ok(model.numberList);
        }

        [HttpGet("answer/{questionNo}/{no}")]
        public async Task<IActionResult> Answer(int questionNo, int no)
        {
            var model = await GetDataAsync();
            if (!questionNo.Equals(model.questions.Length) && no > 10)
            {
                return NotFound("Question or Number Not Found");
            }
            return Ok(model.answers.FirstOrDefault(x => x.questionNo == questionNo && x.answerNo == no));
        }

    }


}
