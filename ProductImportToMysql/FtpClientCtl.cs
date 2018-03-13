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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ProductImportToMysql
{
    /// <summary>
	/// Provides an FTP viewer control.
	/// </summary>
	[DefaultEvent("Repopulated")]
    public partial class FtpClientCtl : UserControl
    {

        // Event provides notification the current file has changed
        public delegate void RepopulatedHandler(object sender, EventArgs e);
        [Description("Occurs after the contents of the control have beupden ated.")]
        public event RepopulatedHandler Repopulated;

         FtpClient _ftpClient;

        /// <summary>
		/// Returns the underlying instance of the FtpClient class.
		/// </summary>
		public FtpClient FtpClient
        {
            get { return _ftpClient; }
        }

        /// <summary>
        /// Determines if users can navigate to other directories.
        /// </summary>
        public bool AllowDirectoryNavigation { get; set; }

        /// <summary>
        /// Gets or sets the current FTP domain and optional directory
        /// </summary>
        public string Host
        {
            get { return _ftpClient.Host; }
            set { _ftpClient.Host = value; }
        }

        /// <summary>
        /// Gets or sets the login username
        /// </summary>
        public string Username
        {
            get { return _ftpClient.Username; }
            set { _ftpClient.Username = value; }
        }

        /// <summary>
        /// Gets or sets the login password
        /// </summary>
        public string Password
        {
            get { return _ftpClient.Password; }
            set { _ftpClient.Password = value; }
        }

        // Construction
        public FtpClientCtl()
        {
            InitializeComponent();

            _ftpClient = new FtpClient();
            listView1.ListViewItemSorter = new ListViewItemComparer();
            AllowDirectoryNavigation = true;
        }

        /// <summary>
		/// Repopulates the control using the current FTP directory.
		/// </summary>
		public void Populate()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                // Populate directory listing
                listView1.Items.Clear();
                List<FtpDirectoryEntry> entries = _ftpClient.ListDirectory();
                foreach (FtpDirectoryEntry entry in entries)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = entry.Name;
                    item.Tag = entry;
                    item.SubItems.Add((entry.IsDirectory) ? "<DIR>" : FileSizeToString(entry.Size));
             //       item.SubItems.Add(entry.CreateTime.ToString());
                    item.ImageIndex = entry.IsDirectory ? 0 : 1;
                    listView1.Items.Add(item);
                }

                // Fire event to indicate we just updated
                if (Repopulated != null)
                    Repopulated(this, new EventArgs());
            }
            catch (Exception ex)
            {
                ShowError("Error listing FTP directory", ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
		/// Downloads the specified files from the current FTP directory
		/// to the given local path.
		/// </summary>
		/// <param name="targetPath">Local path to store downloaded files</param>
		/// <param name="files">List of files to download</param>
		public void DownloadFiles(string targetPath, params string[] files)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                _ftpClient.DownloadFiles(targetPath, files);
            }
            catch (Exception ex)
            {
                ShowError("Error downloading files", ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }


        /// <summary>
		/// Uploads the specified local files to the current FTP directory.
		/// </summary>
		/// <param name="files">List of files to upload</param>
		public void UploadFiles(params string[] files)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                _ftpClient.UploadFiles(files);
            }
            catch (Exception ex)
            {
                ShowError("Error uploading files", ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            Populate();
        }
        
        /// <summary>
		/// Deletes the specified files from the current FTP directory.
		/// </summary>
		/// <param name="files">List of files to delete</param>
		public void DeleteFiles(params string[] files)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                _ftpClient.DeleteFiles(files);
            }
            catch (Exception ex)
            {
                ShowError("Error deleting files", ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            Populate();
        }
        
        /// <summary>
        /// Creates a directory under the current FTP directory.
        /// </summary>
        /// <param name="directory">Directory to create</param>
        public void CreateDirectory(string directory)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                _ftpClient.CreateDirectory(directory);
            }
            catch (Exception ex)
            {
                ShowError("Error creating directory", ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            Populate();
        }

        /// <summary>
		/// Deletes a directory under the current FTP directory.
		/// </summary>
		/// <param name="directory">Directory to delete</param>
		public void DeleteDirectory(string directory)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                _ftpClient.DeleteDirectory(directory);
            }
            catch (Exception ex)
            {
                ShowError("Error deleting directory", ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            Populate();
        }

        /// <summary>
		/// Sets the current FTP directory.
		/// </summary>
		/// <param name="directory">The name of the directory to make
		/// current</param>
		public void SetDirectory(string directory)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                _ftpClient.ChangeDirectory(directory);
            }
            catch (Exception ex)
            {
                ShowError("Error changing the current directory", ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            Populate();
        }

        /// <summary>
        /// Determines if the specified directory exists
        /// </summary>
        /// <param name="directory">The name of the directory to test</param>
        public bool DirectoryExists(string directory)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                return _ftpClient.DirectoryExists(directory);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        #region Menu Commands

        // Change to parent directory
        private void tsbParent_Click(object sender, EventArgs e)
        {
            SetDirectory("..");
        }

        // Download Files command
        private void tsbDownload_Click(object sender, EventArgs e)
        {
            List<string> files = GetSelectedFiles();
            if (files.Count > 0)
            {
                folderBrowserDialog1.Description = String.Format("Select folder to save {0} files(s). (Note that downloading directories is not currently supported.)",
                    files.Count);
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    DownloadFiles(folderBrowserDialog1.SelectedPath, files.ToArray());
            }
            if (files.Count==0)
            {
                MessageBox.Show(String.Format("Listeden Kayıt Seçmelisiniz  ! Seçtiğiniz Kayıt Sayısı : {0} ",files.Count));
                return;
            }

        }

        // Upload Files command
        private void tsbUpload_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Upload Files";
            openFileDialog1.FileName = String.Empty;
            openFileDialog1.Filter = "All Files|*.*|Image Files|*.jpg;*.jpeg;*.gif;*.png|Zip Files|*.zip";
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                UploadFiles(openFileDialog1.FileNames);
        }

        // Delete Files command
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection items = listView1.SelectedItems;
            if (items.Count > 0)
            {
                string description;
                if (items.Count > 1)
                    description = String.Format("{0} items", items.Count);
                else
                    description = String.Format("'{0}'", ((FtpDirectoryEntry)items[0].Tag).Name);

                if (MessageBox.Show(String.Format("Are you sure you want to permanently delete {0}?", description),
                    "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (ListViewItem item in items)
                    {
                        FtpDirectoryEntry entry = (FtpDirectoryEntry)item.Tag;
                        if (entry.IsDirectory)
                        {
                            DeleteDirectory(entry.Name);
                        }
                        else
                        {
                            DeleteFiles(entry.Name);
                        }
                    }
                }
            }
            if (items.Count==0)
            {
                MessageBox.Show(String.Format("Listeden Kayıt Seçmelisiniz  ! Seçtiğiniz Kayıt Sayısı : {0} ", items.Count));
                return;
            }
        }

        // Create directory
        private void tsbCreateDirectory_Click(object sender, EventArgs e)
        {
            string directory = String.Empty;
            if (InputBox.Show("Create Directory", "&New directory name:", ref directory) == DialogResult.OK)
                CreateDirectory(directory);
        }

        // Refresh directory
        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            Populate();
        }


        #endregion

        #region Event Handlers
        // Keydown in listview
        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                ChooseItem();
            else if (e.KeyCode == Keys.Back)
            {
                if (AllowDirectoryNavigation && !_ftpClient.IsRootDirectory)
                    SetDirectory("..");
            }
        }

        // Double click in listview
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChooseItem();
        }

        // Right click in listview
        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            // Display context menu in response to right click
            if (e.Button == MouseButtons.Right)
            {
                // Display context menu
                bool filesSelected = (listView1.SelectedItems.Count > 0);
                tsmiDownloadFiles.Enabled = filesSelected;
                tsmiDelete.Enabled = filesSelected;
                tsmiParentDirectory.Enabled = AllowDirectoryNavigation && !_ftpClient.IsRootDirectory;
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        // Prepare for drop operation
        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        // Handle drop operation
        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                UploadFiles(files);
                e.Effect = DragDropEffects.Copy;
            }
        }

        #endregion

        #region Helper Methods

        // Handle Enter or mouse double click
        protected void ChooseItem()
        {
            if (AllowDirectoryNavigation)
            {
                ListView.SelectedListViewItemCollection items = listView1.SelectedItems;
                if (items.Count > 0)
                {
                    FtpDirectoryEntry entry = (FtpDirectoryEntry)items[0].Tag;
                    if (entry.IsDirectory)
                        SetDirectory(entry.Name);
                }
            }
        }

        // Returns the list of selected files. Directories are not included.
        protected List<string> GetSelectedFiles()
        {
            // Build list of selected files
            List<string> files = new List<string>();
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                FtpDirectoryEntry entry = (FtpDirectoryEntry)item.Tag;
                if (!entry.IsDirectory)
                    files.Add(entry.Name);
            }
            return files;
        }

        protected static string[] _suffix = { "Bytes", "KB", "MB", "GB", "TB", "PB", "EB" };
        protected static double _fileSizeDivisor = 1024.0;

        // Formats a file size value
        protected string FileSizeToString(long sizeInBytes)
        {
            int i = 0;
            double size = (double)sizeInBytes;

            while (size >= _fileSizeDivisor)
            {
                i++;
                size /= _fileSizeDivisor;
            }
            return String.Format("{0:#,##0.##} {1}", size, _suffix[i]);
        }

        // Displays an error message
        protected void ShowError(string msg, Exception ex)
        {
            MessageBox.Show(String.Format("{0} : {1}", msg, ex.Message),
                "FTP Client Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        #endregion

        

        // Implements the manual sorting of items by columns.
        class ListViewItemComparer : IComparer
        {
            public int Compare(object obj1, object obj2)
            {
                FtpDirectoryEntry entry1 = ((ListViewItem)obj1).Tag as FtpDirectoryEntry;
                FtpDirectoryEntry entry2 = ((ListViewItem)obj2).Tag as FtpDirectoryEntry;

                if (entry1 == null || entry2 == null)
                {
                    return 0;
                }
                else if (entry1.IsDirectory != entry2.IsDirectory)
                {
                    return (entry1.IsDirectory) ? -1 : 1;
                }
                else
                {
                    return String.Compare(entry1.Name, entry2.Name);
                }
            }
        }

        class InputBox
        {
            /// <summary>
            /// Displays a dialog with a prompt and textbox where the user can enter information
            /// </summary>
            /// <param name="title">Dialog title</param>
            /// <param name="promptText">Dialog prompt</param>
            /// <param name="value">Sets the initial value and returns the result</param>
            /// <returns>Dialog result</returns>
            public static DialogResult Show(string title, string promptText, ref string value)
            {
                Form form = new Form();
                Label label = new Label();
                TextBox textBox = new TextBox();
                Button buttonOk = new Button();
                Button buttonCancel = new Button();

                form.Text = title;
                label.Text = promptText;
                textBox.Text = value;

                buttonOk.Text = "OK";
                buttonCancel.Text = "Cancel";
                buttonOk.DialogResult = DialogResult.OK;
                buttonCancel.DialogResult = DialogResult.Cancel;

                label.SetBounds(9, 20, 372, 13);
                textBox.SetBounds(12, 36, 372, 20);
                buttonOk.SetBounds(228, 72, 75, 23);
                buttonCancel.SetBounds(309, 72, 75, 23);

                label.AutoSize = true;
                textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
                buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

                form.ClientSize = new Size(396, 107);
                form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
                form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.MinimizeBox = false;
                form.MaximizeBox = false;
                form.AcceptButton = buttonOk;
                form.CancelButton = buttonCancel;

                DialogResult dialogResult = form.ShowDialog();
                value = textBox.Text;
                return dialogResult;
            }
        }

        // Change to parent directory
        private void tsmiParentDirectory_Click(object sender, EventArgs e)
        {
            SetDirectory("..");
        }

        // Download Files command
        private void tsmiDownloadFiles_Click(object sender, EventArgs e)
        {
            List<string> files = GetSelectedFiles();
            if (files.Count > 0)
            {
                folderBrowserDialog1.Description = String.Format("Select folder to save {0} files(s). (Note that downloading directories is not currently supported.)",
                    files.Count);
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    DownloadFiles(folderBrowserDialog1.SelectedPath, files.ToArray());
            }
        }

        // Upload Files command
        private void tsmiUploadFiles_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Upload Files";
            openFileDialog1.FileName = String.Empty;
            openFileDialog1.Filter = "All Files|*.*|Image Files|*.jpg;*.jpeg;*.gif;*.png|Zip Files|*.zip";
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                UploadFiles(openFileDialog1.FileNames);
        }

        // Delete Files command
        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection items = listView1.SelectedItems;
            if (items.Count > 0)
            {
                string description;
                if (items.Count > 1)
                    description = String.Format("{0} items", items.Count);
                else
                    description = String.Format("'{0}'", ((FtpDirectoryEntry)items[0].Tag).Name);

                if (MessageBox.Show(String.Format("Are you sure you want to permanently delete {0}?", description),
                    "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (ListViewItem item in items)
                    {
                        FtpDirectoryEntry entry = (FtpDirectoryEntry)item.Tag;
                        if (entry.IsDirectory)
                        {
                            DeleteDirectory(entry.Name);
                        }
                        else
                        {
                            DeleteFiles(entry.Name);
                        }
                    }
                }
            }
        }

        // Create directory
        private void tsmiCreateDirectory_Click(object sender, EventArgs e)
        {
            string directory = String.Empty;
            if (InputBox.Show("Create Directory", "&New directory name:", ref directory) == DialogResult.OK)
                CreateDirectory(directory);
        }

        // Refresh directory
        private void tsmiRefresh_Click(object sender, EventArgs e)
        {
            Populate();
        }
    }
}
