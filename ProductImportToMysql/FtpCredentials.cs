using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductImportToMysql
{
    public partial class FtpCredentials : Form
    {
        public FtpCredentials()
        {
            InitializeComponent();
            txtHost.Text = Properties.Settings.Default.Host;
            txtUsername.Text = Properties.Settings.Default.Username;
            txtPassword.Text = Properties.Settings.Default.Password;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string host = txtHost.Text;
            if (host.IndexOf("://") < 0)
                host = "ftp://" + host;
            Properties.Settings.Default.Host = host;
            Properties.Settings.Default.Username = txtUsername.Text;
            Properties.Settings.Default.Password = txtPassword.Text;
            Properties.Settings.Default.Save();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
