using Microsoft.AspNetCore.Mvc;
using MYTDotNetCore.MvcApp.Db;
using MYTDotNetCore.MvcApp.Models;

namespace MYTDotNetCore.MvcApp.Controllers;

public class ApexChartController : Controller
{
    private readonly AppDbContext _db;

    public ApexChartController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult PieChart()
    {
        ApexChartPieChartResponseModel model = new ApexChartPieChartResponseModel()
        {
            Series = new List<int> { 44, 55, 13, 43, 22 },
            Labels = new List<string> { "Team A", "Team B", "Team C", "Team D", "Team E" },
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
        model.Labels = lstDate;

        return View(model);
    }

    public IActionResult RadarChart()
    {
        var lst = _db.ApexChartRadarChart.ToList();
        ApexChartRadarResponseModel model = new ApexChartRadarResponseModel();

        model.Series = lst.Select(x => x.Series).ToList();
        model.Labels = lst.Select(x => x.Month).ToList();

        return View(model);
    }

    public IActionResult ColumnChart()
    {
        List<ApexChartColumnChartModel> lst = _db.ApexChartColumnChart.ToList();
        List<ColumnChartSeriesModel> lstSeries = new List<ColumnChartSeriesModel>();

        var lstProductA = lst.Select(x => x.ProductA).ToList();
        var lstProductB = lst.Select(x => x.ProductB).ToList();
        var lstProductC = lst.Select(x => x.ProductC).ToList();
        var lstCategories = lst.Select(x => x.Categories).ToList();

        lstSeries.Add(new ColumnChartSeriesModel
        {
            name = "Product A",
            data = lstProductA,
        });

        lstSeries.Add(new ColumnChartSeriesModel
        {
            name = "Product B",
            data = lstProductB
        });

        lstSeries.Add(new ColumnChartSeriesModel
        {
            name = "Product C",
            data = lstProductC
        });

        ApexChartColumnChartResponseModel model = new ApexChartColumnChartResponseModel()
        {
            Series = lstSeries,
            Labels = lstCategories
        };

        return View(model);
    }
}
