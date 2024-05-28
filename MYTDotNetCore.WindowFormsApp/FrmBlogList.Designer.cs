namespace MYTDotNetCore.WindowFormsApp
{
    partial class FrmBlogList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvBlog = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colTitle = new DataGridViewTextBoxColumn();
            colAuthor = new DataGridViewTextBoxColumn();
            colContent = new DataGridViewTextBoxColumn();
            colEdit = new DataGridViewButtonColumn();
            colDelete = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgvBlog).BeginInit();
            SuspendLayout();
            // 
            // dgvBlog
            // 
            dgvBlog.AllowUserToAddRows = false;
            dgvBlog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBlog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBlog.Columns.AddRange(new DataGridViewColumn[] { colId, colTitle, colAuthor, colContent, colEdit, colDelete });
            dgvBlog.Dock = DockStyle.Fill;
            dgvBlog.Location = new Point(0, 0);
            dgvBlog.Name = "dgvBlog";
            dgvBlog.RowHeadersWidth = 62;
            dgvBlog.RowTemplate.Height = 33;
            dgvBlog.Size = new Size(800, 450);
            dgvBlog.TabIndex = 0;
            // 
            // colId
            // 
            colId.DataPropertyName = "BlogId";
            colId.HeaderText = "ID";
            colId.MinimumWidth = 8;
            colId.Name = "colId";
            colId.Visible = false;
            // 
            // colTitle
            // 
            colTitle.DataPropertyName = "BlogTitle";
            colTitle.HeaderText = "Title";
            colTitle.MinimumWidth = 8;
            colTitle.Name = "colTitle";
            // 
            // colAuthor
            // 
            colAuthor.DataPropertyName = "BlogAuthor";
            colAuthor.HeaderText = "Author";
            colAuthor.MinimumWidth = 8;
            colAuthor.Name = "colAuthor";
            // 
            // colContent
            // 
            colContent.DataPropertyName = "BlogContent";
            colContent.HeaderText = "Content";
            colContent.MinimumWidth = 8;
            colContent.Name = "colContent";
            // 
            // colEdit
            // 
            colEdit.HeaderText = "";
            colEdit.MinimumWidth = 8;
            colEdit.Name = "colEdit";
            colEdit.Text = "Edit";
            colEdit.UseColumnTextForButtonValue = true;
            // 
            // colDelete
            // 
            colDelete.HeaderText = "";
            colDelete.MinimumWidth = 8;
            colDelete.Name = "colDelete";
            colDelete.Text = "Delete";
            colDelete.UseColumnTextForButtonValue = true;
            // 
            // FrmBlogList
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvBlog);
            Name = "FrmBlogList";
            Text = "FrmBlogList";
            Load += FrmBlogList_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBlog).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvBlog;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colTitle;
        private DataGridViewTextBoxColumn colAuthor;
        private DataGridViewTextBoxColumn colContent;
        private DataGridViewButtonColumn colEdit;
        private DataGridViewButtonColumn colDelete;
    }
}