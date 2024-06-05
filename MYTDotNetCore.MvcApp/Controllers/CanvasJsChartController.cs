using Microsoft.AspNetCore.Mvc;
using MYTDotNetCore.MvcApp.Db;
using MYTDotNetCore.MvcApp.Models;

namespace MYTDotNetCore.MvcApp.Controllers
{
    public class CanvasJsChartController : Controller
    {
        private readonly AppDbContext _db = new AppDbContext();

        public IActionResult BarChart()
        {
            var lst = _db
                .CanvasBarChartModels.Select(x => new BarChartData
                {
                    y = x.Series,
                    label = x.Labels
                })
                .ToList();

            CanvasBarChartResponseModel model = new CanvasBarChartResponseModel()
            {
                DataList = lst
            };

            return View(model);
        }

        public IActionResult RangeBarChart()
        {
            var lst = _db.CanvasRangeBarChartModels.Select(x => new CanvasRangeBarChartData
             {
                 x = x.SeriesX,
                 y = new int[] { x.SeriesY1, x.SeriesY2 },
                 Label = x.Labels
             })
            .ToList();
            CanvasRangeBarChartResponseModel model = new CanvasRangeBarChartResponseModel()
            {
                DataList = lst
            };
            return View(model);
        }
    }
}
