namespace MYTDotNetCore.MvcApp.Models;

public class HighChartStackedBarChartModel
{
    public List<MonthData> Category { get; set; }
    public List<VehicleData> Serires { get; set; }
}

public class VehicleData
{
    public string name { get; set; }
    public List<int> data { get; set; }
}

public class MonthData
{
    public List<string> categories { get; set; }
}
