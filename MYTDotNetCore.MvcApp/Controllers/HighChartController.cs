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
                new int[] { 51, 50, 73 },
                new int[] { 41, 22, 14 },
                new int[] { 58, 24, 20 },
                new int[] { 78, 37, 34 },
                new int[] { 55, 56, 53 },
                new int[] { 18, 45, 70 },
                new int[] { 42, 44, 28 },
                new int[] { 3, 52, 59 },
                new int[] { 31, 18, 97 },
                new int[] { 79, 91, 63 },
                new int[] { 93, 23, 23 },
                new int[] { 44, 83, 22 }
            },
            data2 = new int[][]
            {
                new int[] { 42, 38, 20 },
                new int[] { 6, 18, 1 },
                new int[] { 1, 93, 55 },
                new int[] { 57, 2, 90 },
                new int[] { 80, 76, 22 },
                new int[] { 11, 74, 96 },
                new int[] { 88, 56, 10 },
                new int[] { 30, 47, 49 },
                new int[] { 57, 62, 98 },
                new int[] { 4, 16, 16 },
                new int[] { 46, 10, 11 },
                new int[] { 22, 87, 89 },
                new int[] { 57, 91, 82 },
                new int[] { 45, 15, 98 }
            }
        };
        return View(model);
    }
}
