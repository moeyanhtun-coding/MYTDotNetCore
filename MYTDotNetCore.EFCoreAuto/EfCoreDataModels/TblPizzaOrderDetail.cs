using System;
using System.Collections.Generic;

namespace MYTDotNetCore.EFCoreAuto.EfCoreDataModels;

public partial class TblPizzaOrderDetail
{
    public int PizzaOrderDetailId { get; set; }

    public string PizzaOrderInvoiceNo { get; set; } = null!;

    public int PizzaExtraId { get; set; }
}
