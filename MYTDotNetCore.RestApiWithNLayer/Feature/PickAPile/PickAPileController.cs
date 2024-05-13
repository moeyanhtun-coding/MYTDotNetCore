using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYTDotNetCore.RestApiWithNLayer.Models;
using Newtonsoft.Json;


namespace MYTDotNetCore.RestApiWithNLayer.Feature.PickAPile
{
    [Route("api/[controller]")]
    [ApiController]
    public class PickAPileController : ControllerBase
    {
        private async Task<Models.PickAPile.MainDto> GetDataAsync()
        {
            string jsonStr = await System.IO.File.ReadAllTextAsync("PickAPileData.json");
            var model = JsonConvert.DeserializeObject<Models.PickAPile.MainDto>(jsonStr);
            return model;
        }

        [HttpGet("PickAPile/Question")]
        public async Task<IActionResult> GetQuestions()
        {
            var model = await GetDataAsync();
            return Ok(model.Questions);
        }

        [HttpGet("PickAPile/Cards/{questionId}")]
        public async Task<IActionResult> GetCards(int questionId)
        {
            var model = await GetDataAsync();
            var lst = model.Answers.Where(x => x.QuestionId == questionId);
            return Ok(lst);
        }

        [HttpGet("PickAPile/Answer/{questionId}/{answerId}")]
        public async Task<IActionResult> GetAnswer(int questionId, int answerId)
        {
            var model = await GetDataAsync();
            return Ok(model.Answers.FirstOrDefault(x => x.QuestionId == questionId && x.AnswerId == answerId));
        }
    }
}
