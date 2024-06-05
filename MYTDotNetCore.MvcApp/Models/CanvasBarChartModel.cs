using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MYTDotNetCore.MvcApp.Models;

[Table("Tbl_CanvasBarChart")]
public class CanvasBarChartModel
{
	[Key]
	public int Id { get; set; }
	public int Series {  get; set; }
	public string Labels { get; set; }
}

public class CanvasBarChartResponseModel
{
	public List<BarChartData> DataList { get; set; }	
}

public class BarChartData
{
	public int y { get; set; }
	public string label { get; set; }
}