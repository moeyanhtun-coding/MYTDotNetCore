using Microsoft.AspNetCore.Mvc;
using MYTDotNetCore.MvcApp.Models;

namespace MYTDotNetCore.MvcApp.Controllers
{
    public class ApexChartController : Controller
    {
        public IActionResult PieChart()
        {
            ApexChartPieChartResponseModel model = new ApexChartPieChartResponseModel()
            {
                Series = new List<int> { 44, 55, 13, 43, 22 },
                Lables = new List<string> { "Team A", "Team B", "Team C", "Team D", "Team E" },
            }; 
            return View("PieChart",model);
        }
        public IActionResult DashedLineChart() 
        {
            return View();
        }
    }
}
