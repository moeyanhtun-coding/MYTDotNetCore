using Microsoft.AspNetCore.Components;
using MudBlazor;
using MYTDotNetCore.BlazorWasmAppV3.Database;

namespace MYTDotNetCore.BlazorWasmAppV3.Pages.Blog
{
    public partial class BlogDialog
    {
        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }
        private BlogModel reqModel = new();

        private async Task Save()
        {
            try { }
            catch (Exception)
            {
                throw;
            }
        }

        private void Cancel()
        {
            MudDialog.Cancel();
        }
    }
}
