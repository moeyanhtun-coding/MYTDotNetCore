using System.ComponentModel.DataAnnotations.Schema;

namespace MYTDotNetCore.MvcApp.Models;

[Table("Tbl_RangeBarChart")]
public class CanvasRangeBarChartModel
{
    public int Id { get; set; }
    public string Labels { get; set; }
    public int SeriesX { get; set; }
    public int SeriesY1 { get; set; }
    public int SeriesY2 { get; set; }
}

public class CanvasRangeBarChartData
{
    public int x { get; set; }
    public  int[] y { get; set; }
    public string Label { get; set; }
}

public class CanvasRangeBarChartResponseModel
{
    public List<CanvasRangeBarChartData> DataList { get; set; }
}