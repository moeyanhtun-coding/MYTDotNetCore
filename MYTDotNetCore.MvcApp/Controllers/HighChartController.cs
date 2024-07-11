using Microsoft.AspNetCore.Mvc;
using MYTDotNetCore.MvcApp.Models;

namespace MYTDotNetCore.MvcApp.Controllers;

public class HighChartController : Controller
{
    public IActionResult StackedBarChart()
    {
        HighChartStackedBarChartModel model = new HighChartStackedBarChartModel()
        {
            Category = new List<MonthData>
            {
                new MonthData
                {
                    categories = new List<string>
                    {
                        "January",
                        "February",
                        "March",
                        "April",
                        "May"
                    },
                }
            },
            Serires = new List<VehicleData>
            {
                new VehicleData
                {
                    name = "Motorcycles",
                    data = new List<int> { 74, 27, 52, 93, 1272 }
                },
                new VehicleData
                {
                    name = "Null-emission vehicles",
                    data = new List<int> { 2106, 2398, 3046, 3195, 4916 }
                },
                new VehicleData
                {
                    name = "Conventional vehicles",
                    data = new List<int> { 12213, 12721, 15242, 16518, 25037 }
                }
            }
        };

        return View(model);
    }

    public IActionResult HighChart3DBubbleChart()
    {
        HighChart3DBubbleChartModel model = new HighChart3DBubbleChartModel()
        {
            data1 = new int[][]
            {
                new int[] { 9, 81, 63 },
                new int[] { 98, 5, 89 },
                new int[] { 51, 50, 73 }
            },
            data2 = new int[][]
            {
                new int[] { 42, 38, 20 },
                new int[] { 6, 18, 1 },
                new int[] { 57, 2, 90 }
            }
        };
        return View(model);
    }
}
