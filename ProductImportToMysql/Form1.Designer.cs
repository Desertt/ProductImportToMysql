namespace ProductImportToMysql
{
	partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ftpClientCtl1 = new ProductImportToMysql.FtpClientCtl();
            this.SuspendLayout();
            // 
            // ftpClientCtl1
            // 
            this.ftpClientCtl1.AllowDirectoryNavigation = true;
            this.ftpClientCtl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ftpClientCtl1.Host = "/";
            this.ftpClientCtl1.Location = new System.Drawing.Point(0, 0);
            this.ftpClientCtl1.Name = "ftpClientCtl1";
            this.ftpClientCtl1.Password = null;
            this.ftpClientCtl1.Size = new System.Drawing.Size(515, 327);
            this.ftpClientCtl1.TabIndex = 0;
            this.ftpClientCtl1.Username = null;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 327);
            this.Controls.Add(this.ftpClientCtl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FTP Client";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

		}

		#endregion

		private ProductImportToMysql.FtpClientCtl ftpClientCtl1;
	}
}

