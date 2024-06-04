using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MYTDotNetCore.MvcApp.Models;

[Table("Tbl_RadarChart")]
public class ApexChartRadarChartModel
{
    [Key]
    public int Id { get; set; }
    public string Month { get; set; }
    public int Series { get; set; }
}

public class ApexChartRadarResponseModel
{
    public List<int> Series { get; set; }
    public List<string> Labels { get; set; }
}

