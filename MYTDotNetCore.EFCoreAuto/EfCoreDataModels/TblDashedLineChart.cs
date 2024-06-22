using System;
using System.Collections.Generic;

namespace MYTDotNetCore.EFCoreAuto.EfCoreDataModels;

public partial class TblDashedLineChart
{
    public int PageStatistics { get; set; }

    public int SessionDuration { get; set; }

    public int PageViews { get; set; }

    public int TotalVisits { get; set; }

    public string CreatedDate { get; set; } = null!;
}
