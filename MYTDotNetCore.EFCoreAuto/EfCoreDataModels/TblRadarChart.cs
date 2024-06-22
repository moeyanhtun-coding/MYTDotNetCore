using System;
using System.Collections.Generic;

namespace MYTDotNetCore.EFCoreAuto.EfCoreDataModels;

public partial class TblRadarChart
{
    public int Id { get; set; }

    public string Month { get; set; } = null!;

    public int Series { get; set; }
}
