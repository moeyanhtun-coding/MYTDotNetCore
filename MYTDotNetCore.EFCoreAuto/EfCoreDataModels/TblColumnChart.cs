using System;
using System.Collections.Generic;

namespace MYTDotNetCore.EFCoreAuto.EfCoreDataModels;

public partial class TblColumnChart
{
    public int Id { get; set; }

    public int ProductA { get; set; }

    public int ProductB { get; set; }

    public int ProductC { get; set; }

    public string Categories { get; set; } = null!;
}
