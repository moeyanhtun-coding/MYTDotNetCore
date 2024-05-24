using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYTDotNetCore.RestApiWithNLayer.Models;
using Newtonsoft.Json;
using static MYTDotNetCore.RestApiWithNLayer.Models.MyanmarProverbModel;

namespace MYTDotNetCore.RestApiWithNLayer.Feature.MyanmarProverb
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyanmarProverbsController : ControllerBase
    {
        private async Task<MainDto> GetDataFromApi()
        {
            var jsonStr = await System.IO.File.ReadAllTextAsync("MyanmarProverb.json");
            var model = JsonConvert.DeserializeObject<MainDto>(jsonStr);
            return model!;
        }

        [HttpGet("MyanmarProverb")]
        public async Task<IActionResult> Get()
        {
            var model = await GetDataFromApi();
            return Ok(model.Tbl_MMProverbsTitle);
        }

        [HttpGet("MyanmarProverb{titleName}")]
        public async Task<IActionResult> Get(string titleName)
        {
            var model = await GetDataFromApi();
            var item = model.Tbl_MMProverbsTitle.FirstOrDefault(x => x.TitleName == titleName);
            if (item is null)
                return NotFound();

            var titleId = item.TitleId;
            var result = model.Tbl_MMProverbs.Where(x => x.TitleId == titleId);
            List<Tbl_MmproverbsHead> lst = result
                .Select(x => new Tbl_MmproverbsHead
                {
                    TitleId = x.TitleId,
                    ProverbId = x.ProverbId,
                    ProverbName = x.ProverbName
                })
                .ToList();
            return Ok(lst);
        }

        [HttpGet("MyanmarProverb/{titleId}/{proverbId}")]
        public async Task<IActionResult> Get(int titleId, int proverbId)
        {
            var model = await GetDataFromApi();
            var item = model.Tbl_MMProverbs.Where(x => x.TitleId == titleId && x.ProverbId == proverbId);
            if (item is null)
                return NotFound("No Data Found");
            return Ok(item);
        }
    }
}
