using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MYTDotNetCore.MvcApp.Models;

[Table("Tbl_ColumnChart")]
public class ApexChartColumnChartModel
{
    [Key]
    public int Id { get; set; }
    public int ProductA {  get; set; }
    public int ProductB { get; set; }
    public int ProductC { get; set; }
    public string Categories { get; set; }
}

public class ColumnChartSeriesModel
{
    public string name { get; set; }
    public List<int> data { get; set; }
}
public class ApexChartColumnChartResponseModel
{
    public List<ColumnChartSeriesModel> Series { get; set; }
    public List<string> Labels { get; set; }
}