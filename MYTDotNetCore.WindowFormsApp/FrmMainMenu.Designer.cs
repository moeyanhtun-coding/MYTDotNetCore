namespace MYTDotNetCore.WindowFormsApp
{
    partial class FrmMainMenu
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
            blogToolStripMenuItem = new ToolStripMenuItem();
            newBlogToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            blogListToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // blogToolStripMenuItem
            // 
            blogToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newBlogToolStripMenuItem, blogListToolStripMenuItem });
            blogToolStripMenuItem.Name = "blogToolStripMenuItem";
            blogToolStripMenuItem.Size = new Size(64, 29);
            blogToolStripMenuItem.Text = "Blog";
            // 
            // newBlogToolStripMenuItem
            // 
            newBlogToolStripMenuItem.Name = "newBlogToolStripMenuItem";
            newBlogToolStripMenuItem.Size = new Size(270, 34);
            newBlogToolStripMenuItem.Text = "New Blog";
            newBlogToolStripMenuItem.Click += newBlogToolStripMenuItem_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { blogToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 33);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // blogListToolStripMenuItem
            // 
            blogListToolStripMenuItem.Name = "blogListToolStripMenuItem";
            blogListToolStripMenuItem.Size = new Size(270, 34);
            blogListToolStripMenuItem.Text = "Blog List";
            blogListToolStripMenuItem.Click += blogListToolStripMenuItem_Click;
            // 
            // FrmMainMenu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FrmMainMenu";
            Text = "FrmMainMenu";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStripMenuItem blogToolStripMenuItem;
        private ToolStripMenuItem newBlogToolStripMenuItem;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem blogListToolStripMenuItem;
    }
}