//////////////////////////////////////////////////////////////////////////////
// This source code and all associated files and resources are copyrighted by
// the author(s). This source code and all associated files and resources may
// be used as long as they are used according to the terms and conditions set
// forth in The Code Project Open License (CPOL), which may be viewed at
// http://www.blackbeltcoder.com/Legal/Licenses/CPOL.
//
// Copyright (c) 2011 Jonathan Wood
//

using System;
using System.Windows.Forms;

namespace ProductImportToMysql
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			FtpCredentials frm = new FtpCredentials();
			frm.ShowDialog();
			ftpClientCtl1.Host = Properties.Settings.Default.Host;
			ftpClientCtl1.Username = Properties.Settings.Default.Username;
			ftpClientCtl1.Password = Properties.Settings.Default.Password;
			ftpClientCtl1.Populate();
		}
	}
}
