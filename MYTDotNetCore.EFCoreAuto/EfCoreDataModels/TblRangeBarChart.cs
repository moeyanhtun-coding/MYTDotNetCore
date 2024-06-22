using System;
using System.Collections.Generic;

namespace MYTDotNetCore.EFCoreAuto.EfCoreDataModels;

public partial class TblRangeBarChart
{
    public int Id { get; set; }

    public string Labels { get; set; } = null!;

    public int SeriesX { get; set; }

    public int SeriesY1 { get; set; }

    public int SeriesY2 { get; set; }
}
