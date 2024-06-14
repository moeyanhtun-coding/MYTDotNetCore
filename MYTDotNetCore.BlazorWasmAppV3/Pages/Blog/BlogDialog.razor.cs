namespace MYTDotNetCore.BlazorWasmAppV3.Pages.Blog;

public partial class BlogDialog
{
    [CascadingParameter]
    MudDialogInstance MudDialog { get; set; }
    private BlogModel reqModel = new();
    private ResponseModel responseModel = new ResponseModel();

    private async Task Save()
    {
        var response = await HttpClientService.ExecuteAsync<ResponseModel>(
            EndPoints.Blog,
            EnumHttpMethod.Post,
            reqModel
        );
        MudDialog.Close();
    }

    private void Cancel()
    {
        MudDialog.Cancel();
    }
}
