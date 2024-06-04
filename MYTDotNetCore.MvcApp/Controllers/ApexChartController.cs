using Microsoft.AspNetCore.Mvc;
using MYTDotNetCore.MvcApp.Db;
using MYTDotNetCore.MvcApp.Models;

namespace MYTDotNetCore.MvcApp.Controllers;

public class ApexChartController : Controller
{
    private readonly AppDbContext _db = new AppDbContext();

    public IActionResult PieChart()
    {
        ApexChartPieChartResponseModel model = new ApexChartPieChartResponseModel()
        {
            Series = new List<int> { 44, 55, 13, 43, 22 },
            Lables = new List<string> { "Team A", "Team B", "Team C", "Team D", "Team E" },
        };
        return View(model);
    }

    public IActionResult DashedLineChart()
    {
        List<DashedLineChartModel> lst = _db.PageStatistics.ToList();
        ApexChartDashedLineChartResponseModel model = new ApexChartDashedLineChartResponseModel();
        List<ApexChartDashedLineChartModel> lstSeries = new List<ApexChartDashedLineChartModel>();

        var lstSessionDuration = lst.Select(x => x.SessionDuration).ToList();
        var lstPageViews = lst.Select(x => x.PageViews).ToList();
        var lstTotalVisits = lst.Select(x => x.TotalVisits).ToList();
        var lstDate = lst.Select(x => x.CreatedDate).ToList();

        lstSeries.Add(
            new ApexChartDashedLineChartModel
            {
                name = "Session Duration",
                data = lstSessionDuration
            }
        );
        lstSeries.Add(
            new ApexChartDashedLineChartModel
            {
                name = "Page Views",
                data = lstPageViews,
            }
        );
        lstSeries.Add(
            new ApexChartDashedLineChartModel
            {
                name = "Total Visits",
                data = lstTotalVisits
            }
        );

        model.Series = lstSeries;
        model.Lables = lstDate;

        return View(model);
    }

    public IActionResult RadarChart()
    {
        var lst = _db.ApexChartRadarChart.ToList();

        ApexChartRadarResponseModel model = new ApexChartRadarResponseModel();

        model.Series = lst.Select(x => x.Series).ToList();
        model.Lables = lst.Select(x => x.Month).ToList();

        return View(model);
    }

}
