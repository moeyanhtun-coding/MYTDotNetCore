using Microsoft.AspNetCore.Mvc;

namespace MYTDotNetCore.MvcApp.Controllers
{
    public class ApaxChartController : Controller
    {
        public IActionResult PieChart()
        {
            return View("PieChart");
        }
    }
}
