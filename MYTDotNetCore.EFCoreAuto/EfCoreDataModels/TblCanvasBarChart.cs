using System;
using System.Collections.Generic;

namespace MYTDotNetCore.EFCoreAuto.EfCoreDataModels;

public partial class TblCanvasBarChart
{
    public int Id { get; set; }

    public int Series { get; set; }

    public string Labels { get; set; } = null!;
}
