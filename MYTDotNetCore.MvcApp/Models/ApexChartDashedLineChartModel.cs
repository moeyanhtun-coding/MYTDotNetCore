using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MYTDotNetCore.MvcApp.Models
{
    [Table("Tbl_DashedLineChart")]
    public class DashedLineChartModel
    {
        [Key]
        public int PageStatistics { get; set; }
        public int SessionDuration { get; set; }
        public int PageViews { get; set; }
        public int TotalVisits { get; set; }
        public string CreatedDate { get; set; }
    }
    
}
public class ApexChartDashedLineChartModel
{
    public string name { get; set; }
    public List<int> data { get; set; }
}

public class ApexChartDashedLineChartResponseModel
{
    public List<ApexChartDashedLineChartModel> data { get; set; }
    public List<string> Lables { get; set; }
}