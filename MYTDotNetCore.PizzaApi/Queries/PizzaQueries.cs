namespace MYTDotNetCore.PizzaApi.Queries
{
    public class PizzaQueries
    {
        public static string pizzaOrderQuery { get; } =
            @"SELECT po.*, p.pizza, p.Price FROM [dbo].[Tbl_PizzaOrder] po 
                INNER JOIN [dbo].[Tbl_Pizza] p ON p.PizzaId = po.PizzaId
                WHERE PizzaOrderInvoiceNo = @PizzaOrderInvoiceNo;";
        public static string pizzaOrderDetailQuery { get; } =
            @"SELECT po.*, pe.PizzaExtraName, pe.Price FROM [dbo].[Tbl_PizzaOrderDetail] po 
                INNER JOIN [dbo].[Tbl_PizzaExtra] pe ON pe.PizzaExtraId = po.PizzaExtraId
                WHERE PizzaOrderInvoiceNo = @PizzaOrderInvoiceNo;";
    }
}
