namespace MYTDotNetCore.WindowFormsApp;

using System.Data.SqlClient;
using MYTDotNetCore.Shared;
using MYTDotNetCore.WindowFormsApp.Models;

public partial class txt : Form
{
    private readonly DapperService _dapperService;

    public txt()
    {
        InitializeComponent();
        _dapperService = new DapperService(
            ConnectionStrings.SqlConnectionStringBuilder.ConnectionString
        );
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControl();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            BlogModel blog = new BlogModel();
            blog.BlogTitle = txtTitle.Text.Trim();
            blog.BlogAuthor = txtAuthor.Text.Trim();
            blog.BlogContent = txtContent.Text.Trim();

            int result = _dapperService.Execute(Queries.BlogQuery.BlogCreate, blog);
            string message = result > 0 ? "Create Success" : "Create Fail";
            var messageBoxIcon = result > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Error;
            MessageBox.Show(message, "Blog", MessageBoxButtons.OK, messageBoxIcon);
            if(result > 0) 
                ClearControl();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void txtContent_TextChanged(object sender, EventArgs e) {

    }

    private void ClearControl()
    {
        txtTitle.Clear();
        txtAuthor.Clear();
        txtContent.Clear();

        txtTitle.Focus();
    }
}
