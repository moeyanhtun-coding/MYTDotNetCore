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
            if (e.ColumnIndex < 0) return;
            int blogId = Convert.ToInt32(dgvBlog.Rows[e.RowIndex].Cells["colId"].Value);

            #region If case

            if (e.ColumnIndex == (int)EnumFormControlType.Edit)
            {
                FrmBlog frm = new FrmBlog(blogId);
                frm.ShowDialog();
                BlogLists();
            }
            else if (e.ColumnIndex == (int)EnumFormControlType.Delete)
            {
                var dialogResult = MessageBox.Show("Are you sure want to delete?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult != DialogResult.Yes) return;
                MessageBox.Show(DeleteBlog(blogId));
                BlogLists();
            }

            #endregion

            #region switch Case

            int index = e.ColumnIndex;
            EnumFormControlType enumFormControlType = (EnumFormControlType)index;

            switch (enumFormControlType)
            {
                case EnumFormControlType.Edit:
                    FrmBlog frm = new FrmBlog(blogId);
                    frm.ShowDialog();
                    BlogLists();
                    break;
                case EnumFormControlType.Delete:
                    var dialogResult = MessageBox.Show("Are you sure want to delete?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult != DialogResult.Yes) return;
                    MessageBox.Show(DeleteBlog(blogId));
                    BlogLists();
                    break;
                default:
                    MessageBox.Show("Something Was Wrong!", "",MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    break;
            }

            #endregion
        }
        private void BlogLists()
        {
            List<BlogModel> lst = _dapperService.Query<BlogModel>(Queries.BlogQuery.BlogLists);
            dgvBlog.DataSource = lst;
        }

        private string DeleteBlog(int id)
        {
            int result = _dapperService.Execute(
                    Queries.BlogQuery.BlogDelete,
                    new BlogModel { BlogId = id }
                );
            string message = result > 0 ? "Delete Successful" : "Delete Fail";
            return message;
        }
    }
}
