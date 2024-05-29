namespace MYTDotNetCore.WindowFormsApp
{
    partial class FrmBlog
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCancel = new Button();
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            txtContent = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnSave = new Button();
            btnUpdate = new Button();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(158, 158, 158);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(237, 353);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 34);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(237, 84);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(493, 31);
            txtTitle.TabIndex = 1;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(237, 146);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(493, 31);
            txtAuthor.TabIndex = 2;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(237, 208);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(493, 139);
            txtContent.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(237, 56);
            label1.Name = "label1";
            label1.Size = new Size(53, 25);
            label1.TabIndex = 4;
            label1.Text = "Title :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(237, 118);
            label2.Name = "label2";
            label2.Size = new Size(76, 25);
            label2.TabIndex = 5;
            label2.Text = "Author :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(237, 180);
            label3.Name = "label3";
            label3.Size = new Size(84, 25);
            label3.TabIndex = 6;
            label3.Text = "Content :";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(66, 165, 245);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(355, 353);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(128, 128, 255);
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(355, 353);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(112, 34);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Visible = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // FrmBlog
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(923, 518);
            Controls.Add(btnUpdate);
            Controls.Add(btnSave);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtContent);
            Controls.Add(txtAuthor);
            Controls.Add(txtTitle);
            Controls.Add(btnCancel);
            Name = "FrmBlog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmBlog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancel;
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private TextBox txtContent;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnSave;
        private Button btnUpdate;
    }
}
