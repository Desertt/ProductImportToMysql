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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonAddExcell = new System.Windows.Forms.Button();
            this.textBoxExcelFilePath = new System.Windows.Forms.TextBox();
            this.comboBoxTableList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelTotalCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonSendBulkImage = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSendBulkImage);
            this.groupBox1.Controls.Add(this.buttonClose);
            this.groupBox1.Controls.Add(this.buttonAddExcell);
            this.groupBox1.Controls.Add(this.textBoxExcelFilePath);
            this.groupBox1.Controls.Add(this.comboBoxTableList);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.labelTotalCount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1003, 369);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonClose.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonClose.Location = new System.Drawing.Point(918, 225);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(82, 138);
            this.buttonClose.TabIndex = 7;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonAddExcell
            // 
            this.buttonAddExcell.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonAddExcell.Location = new System.Drawing.Point(431, 270);
            this.buttonAddExcell.Name = "buttonAddExcell";
            this.buttonAddExcell.Size = new System.Drawing.Size(174, 75);
            this.buttonAddExcell.TabIndex = 6;
            this.buttonAddExcell.Text = "Add Excel";
            this.buttonAddExcell.UseVisualStyleBackColor = true;
            this.buttonAddExcell.Click += new System.EventHandler(this.buttonAddExcell_Click);
            // 
            // textBoxExcelFilePath
            // 
            this.textBoxExcelFilePath.Enabled = false;
            this.textBoxExcelFilePath.Location = new System.Drawing.Point(180, 298);
            this.textBoxExcelFilePath.Name = "textBoxExcelFilePath";
            this.textBoxExcelFilePath.Size = new System.Drawing.Size(245, 20);
            this.textBoxExcelFilePath.TabIndex = 5;
            // 
            // comboBoxTableList
            // 
            this.comboBoxTableList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTableList.FormattingEnabled = true;
            this.comboBoxTableList.Location = new System.Drawing.Point(431, 238);
            this.comboBoxTableList.Name = "comboBoxTableList";
            this.comboBoxTableList.Size = new System.Drawing.Size(174, 21);
            this.comboBoxTableList.TabIndex = 4;
            this.comboBoxTableList.SelectedIndexChanged += new System.EventHandler(this.comboBoxTableList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(330, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Table Select";
            // 
            // labelTotalCount
            // 
            this.labelTotalCount.AutoSize = true;
            this.labelTotalCount.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelTotalCount.Location = new System.Drawing.Point(64, 225);
            this.labelTotalCount.Name = "labelTotalCount";
            this.labelTotalCount.Size = new System.Drawing.Size(15, 20);
            this.labelTotalCount.TabIndex = 2;
            this.labelTotalCount.Text = ".";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total : ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(997, 206);
            this.dataGridView1.TabIndex = 0;
            // 
            // buttonSendBulkImage
            // 
            this.buttonSendBulkImage.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonSendBulkImage.Location = new System.Drawing.Point(721, 238);
            this.buttonSendBulkImage.Name = "buttonSendBulkImage";
            this.buttonSendBulkImage.Size = new System.Drawing.Size(142, 75);
            this.buttonSendBulkImage.TabIndex = 8;
            this.buttonSendBulkImage.Text = "Send Bulk Image";
            this.buttonSendBulkImage.UseVisualStyleBackColor = true;
            this.buttonSendBulkImage.Click += new System.EventHandler(this.buttonSendBulkImage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 369);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductImportToMysql";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonAddExcell;
        private System.Windows.Forms.TextBox textBoxExcelFilePath;
        private System.Windows.Forms.ComboBox comboBoxTableList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTotalCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonSendBulkImage;
    }
}

