using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MYTDotNetCore.Shared2;
using MYTDotNetCore.WindowFormsApp.Models;

namespace MYTDotNetCore.WindowFormsApp
{
    public partial class FrmBlogList : Form
    {
        private readonly DapperService _dapperService;

        public FrmBlogList()
        {
            InitializeComponent();
            _dapperService = new DapperService(
                ConnectionStrings.SqlConnectionStringBuilder.ConnectionString
            );
        }

        private void FrmBlogList_Load(object sender, EventArgs e)
        {
            BlogLists();
        }


        private void dgvBlog_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == (int)EnumFormControlType.Edit) { }
            else if (e.ColumnIndex == (int)EnumFormControlType.Delete)
            {
                var dialogResult = MessageBox.Show("Are you sure want to delete?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult != DialogResult.Yes) return;
                int blogId = Convert.ToInt32(dgvBlog.Rows[e.RowIndex].Cells["colId"].Value);
                DeletBlog(blogId);
            }
        }
        private void BlogLists()
        {
            List<BlogModel> lst = _dapperService.Query<BlogModel>(Queries.BlogQuery.BlogLists);
            dgvBlog.DataSource = lst;
        }
        private void DeletBlog(int id)
        {
            int result = _dapperService.Execute(
                    Queries.BlogQuery.BlogDelete,
                    new BlogModel { BlogId = id }
                );
            string message = result > 0 ? "Delete Successful" : "Delete Fail";
        }
    }
}
