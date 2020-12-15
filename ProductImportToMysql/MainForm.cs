using ExcelDataReader;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;


namespace ProductImportToMysql
{
    public partial class MainForm : Form
    {
        public MySqlConnection connection;
        public string server;
        public string database;
        public string uid;
        public string password;
        public string port;
        public string cmdValue;
        public string tableName = string.Empty;
        public string tempFileDirectory = @"D:\ImagePool\";
        public string host = "ftp://host.com/";
        public string user = "aa";
        public string pass = "2020!";
        DateTime date;  // Use date

        public string strDate = "Unknown";

        public string sourcefilepath = @"D:\ImagePool\"; // e.g. "d:/test.docx"
        public string ftpurl = "ftp://host.com/"; // e.g. ftp://serverip/foldername/foldername
        public string ftpusername = "aa"; // e.g. username
        public string ftppassword = "2020!"; // e.g. password




        public MainForm()
        {
            InitializeComponent();

            server = "10.10.10.10";
            database = "aaa_o06";
            uid = "aaa_oc6";
            password = "p9A-98SL]Q";
            port = "3300";
            cmdValue = "Allow Zero Datetime=true";

            string connectionString;
            connectionString = @"SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";" + "PORT = " + port + ";" + cmdValue + ";";

            connection = new MySqlConnection(connectionString);


        }

        private void buttonAddExcell_Click(object sender, EventArgs e)
        {
            if (comboBoxTableList.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen Tablo Seçimi Yapınız !");
                return;
            }

            tableName = comboBoxTableList.SelectedItem.ToString();

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.ShowDialog();
            textBoxExcelFilePath.Text = openFile.FileName;
            string filePath = textBoxExcelFilePath.Text;
            strDate = date.ToString("dd/MM/yyyy");

            #region ocly_product 

            if (tableName == "ocly_product")
            {

                Cursor.Current = Cursors.WaitCursor;

                FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);

                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                var result = new ExcelDataReader.ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataReader.ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true
                    }
                };


                var dataSet = excelReader.AsDataSet(result);

                DataTable dtOc5eProduct = new DataTable();

                dtOc5eProduct = dataSet.Tables[0];
                connection.Open();

                for (int i = 0; i < dtOc5eProduct.Rows.Count; i++)
                {

                    string strSQL = "INSERT INTO " + tableName + "(product_id,model,quantity,stock_status_id,image,manufacturer_id,shipping,price,tax_class_id,date_available,weight_class_id,length_class_id,subtract,minimum,sort_order,status,date_added,date_modified,bulkpriceupdate)" + "VALUES('"
                       + dtOc5eProduct.Rows[i][0].ToString() + "',"
                       + "'" + dtOc5eProduct.Rows[i][1].ToString() + "',"
                       + "'" + dtOc5eProduct.Rows[i][2].ToString() + "',"
                       + "'" + dtOc5eProduct.Rows[i][3].ToString() + "',"
                       + "'" + dtOc5eProduct.Rows[i][4].ToString() + "',"
                       + "'" + dtOc5eProduct.Rows[i][5].ToString() + "',"
                       + "'" + dtOc5eProduct.Rows[i][6].ToString() + "',"
                       + "'" + dtOc5eProduct.Rows[i][7].ToString() + "',"
                       + "'" + dtOc5eProduct.Rows[i][8].ToString() + "',"
                       + "'" + dtOc5eProduct.Rows[i][9].ToString() + "',"
                       + "'" + dtOc5eProduct.Rows[i][10].ToString() + "',"
                       + "'" + dtOc5eProduct.Rows[i][11].ToString() + "',"
                       + "'" + dtOc5eProduct.Rows[i][12].ToString() + "',"
                       + "'" + dtOc5eProduct.Rows[i][13].ToString() + "',"
                       + "'" + dtOc5eProduct.Rows[i][14].ToString() + "',"
                       + "'" + dtOc5eProduct.Rows[i][15].ToString() + "',"
                       + "'" + dtOc5eProduct.Rows[i][16].ToString() + "',"
                       + "'" + dtOc5eProduct.Rows[i][17].ToString() + "',"
                       + "'" + dtOc5eProduct.Rows[i][18].ToString() + "'"
                       + ")";

                    var objCmd = new MySqlCommand(strSQL, connection);
                    var sendData = objCmd.ExecuteNonQuery();
                }

                MessageBox.Show(tableName + " Tablosuna Excel Kayıtları Eklendi !");
                textBoxExcelFilePath.Text = String.Empty;
                connection.Close();
                Cursor.Current = Cursors.Default;
            }

            #endregion

            #region ocly_product_description

            else if (tableName == "ocly_product_description")
            {

                Cursor.Current = Cursors.WaitCursor;

                FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);

                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                var result = new ExcelDataReader.ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataReader.ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true
                    }
                };


                var dataSet = excelReader.AsDataSet(result);

                DataTable dtOc5eProductDescription = new DataTable();

                dtOc5eProductDescription = dataSet.Tables[0];
                connection.Open();

                for (int i = 0; i < dtOc5eProductDescription.Rows.Count; i++)
                {

                    string strSQL = "INSERT INTO " + tableName + "(product_id,language_id,name,description,tag,meta_title,meta_description,meta_keyword)" + "VALUES('"
                       + dtOc5eProductDescription.Rows[i][0].ToString() + "',"
                       + "'" + dtOc5eProductDescription.Rows[i][1].ToString() + "',"
                       + "'" + dtOc5eProductDescription.Rows[i][2].ToString() + "',"
                       + "'" + dtOc5eProductDescription.Rows[i][3].ToString() + "',"
                       + "'" + dtOc5eProductDescription.Rows[i][4].ToString() + "',"
                       + "'" + dtOc5eProductDescription.Rows[i][5].ToString() + "',"
                       + "'" + dtOc5eProductDescription.Rows[i][6].ToString() + "',"
                       + "'" + dtOc5eProductDescription.Rows[i][7].ToString() + "'"
                       + ")";

                    var objCmd = new MySqlCommand(strSQL, connection);
                    var sendData = objCmd.ExecuteNonQuery();
                }

                MessageBox.Show(tableName + " Tablosuna Excel Kayıtları Eklendi !");
                textBoxExcelFilePath.Text = String.Empty;
                connection.Close();
                Cursor.Current = Cursors.Default;
            }

            #endregion

            #region ocly_product_image

            else if (tableName == "ocly_product_image")
            {
                Cursor.Current = Cursors.WaitCursor;

                FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);

                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                var result = new ExcelDataReader.ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataReader.ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true
                    }
                };


                var dataSet = excelReader.AsDataSet(result);

                DataTable dtOc5eProductImage = new DataTable();

                dtOc5eProductImage = dataSet.Tables[0];
                connection.Open();

                for (int i = 0; i < dtOc5eProductImage.Rows.Count; i++)
                {

                    string strSQL = "INSERT INTO " + tableName + "(product_image_id,product_id,image)" + "VALUES('"
                       + dtOc5eProductImage.Rows[i][0].ToString() + "',"
                       + "'" + dtOc5eProductImage.Rows[i][1].ToString() + "',"
                       + "'" + dtOc5eProductImage.Rows[i][2].ToString() + "'"
                       + ")";

                    var objCmd = new MySqlCommand(strSQL, connection);
                    var sendData = objCmd.ExecuteNonQuery();
                }

                MessageBox.Show(tableName + " Tablosuna Excel Kayıtları Eklendi !");
                textBoxExcelFilePath.Text = String.Empty;
                connection.Close();

                Cursor.Current = Cursors.Default;
            }

            #endregion

            #region ocly_product_related

            else if (tableName == "ocly_product_related")
            {
                Cursor.Current = Cursors.WaitCursor;

                FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);

                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                var result = new ExcelDataReader.ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataReader.ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true
                    }
                };


                var dataSet = excelReader.AsDataSet(result);

                DataTable dtOc5eProductRelated = new DataTable();

                dtOc5eProductRelated = dataSet.Tables[0];
                connection.Open();

                for (int i = 0; i < dtOc5eProductRelated.Rows.Count; i++)
                {

                    string strSQL = "INSERT INTO " + tableName + "(product_id,related_id)" + "VALUES('"
                       + dtOc5eProductRelated.Rows[i][0].ToString() + "',"
                       + "'" + dtOc5eProductRelated.Rows[i][1].ToString() + "'"
                       + ")";

                    var objCmd = new MySqlCommand(strSQL, connection);
                    var sendData = objCmd.ExecuteNonQuery();
                }

                MessageBox.Show(tableName + " Tablosuna Excel Kayıtları Eklendi !");
                textBoxExcelFilePath.Text = String.Empty;
                connection.Close();

                Cursor.Current = Cursors.Default;
            }

            #endregion

            #region ocly_product_special

            else if (tableName == "ocly_product_special")
            {
                Cursor.Current = Cursors.WaitCursor;

                FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);

                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                var result = new ExcelDataReader.ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataReader.ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true
                    }
                };


                var dataSet = excelReader.AsDataSet(result);

                DataTable dtOc5eProductSpecial = new DataTable();

                dtOc5eProductSpecial = dataSet.Tables[0];
                connection.Open();

                for (int i = 0; i < dtOc5eProductSpecial.Rows.Count; i++)
                {

                    string strSQL = "INSERT INTO " + tableName + "(product_special_id,product_id,customer_group_id,price,bulkpriceupdate)" + "VALUES('"
                       + dtOc5eProductSpecial.Rows[i][0].ToString() + "',"
                       + "'" + dtOc5eProductSpecial.Rows[i][1].ToString() + "',"
                       + "'" + dtOc5eProductSpecial.Rows[i][2].ToString() + "',"
                       + "'" + dtOc5eProductSpecial.Rows[i][3].ToString() + "',"
                       + "'" + dtOc5eProductSpecial.Rows[i][4].ToString() + "'"
                       + ")";

                    var objCmd = new MySqlCommand(strSQL, connection);
                    var sendData = objCmd.ExecuteNonQuery();
                }

                MessageBox.Show(tableName + " Tablosuna Excel Kayıtları Eklendi !");
                textBoxExcelFilePath.Text = String.Empty;
                connection.Close();
                Cursor.Current = Cursors.Default;
            }
            #endregion

            #region ocly_product_to_category

            else if (tableName == "ocly_product_to_category")
            {

                Cursor.Current = Cursors.WaitCursor;

                FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);

                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                var result = new ExcelDataReader.ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataReader.ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true
                    }
                };


                var dataSet = excelReader.AsDataSet(result);

                DataTable dtOc5eProductToCategory = new DataTable();

                dtOc5eProductToCategory = dataSet.Tables[0];
                connection.Open();

                for (int i = 0; i < dtOc5eProductToCategory.Rows.Count; i++)
                {

                    string strSQL = "INSERT INTO " + tableName + "(product_id,category_id)" + "VALUES('"
                       + dtOc5eProductToCategory.Rows[i][0].ToString() + "',"
                       + "'" + dtOc5eProductToCategory.Rows[i][1].ToString() + "'"
                       + ")";

                    var objCmd = new MySqlCommand(strSQL, connection);
                    var sendData = objCmd.ExecuteNonQuery();
                }

                MessageBox.Show(tableName + " Tablosuna Excel Kayıtları Eklendi !");
                textBoxExcelFilePath.Text = String.Empty;
                connection.Close();

                Cursor.Current = Cursors.Default;
            }

            #endregion

            #region ocly_product_to_layout


            else if (tableName == "ocly_product_to_layout")
            {

                Cursor.Current = Cursors.WaitCursor;

                FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);

                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                var result = new ExcelDataReader.ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataReader.ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true
                    }
                };


                var dataSet = excelReader.AsDataSet(result);

                DataTable dtOc5eProductToLayout = new DataTable();

                dtOc5eProductToLayout = dataSet.Tables[0];
                connection.Open();

                for (int i = 0; i < dtOc5eProductToLayout.Rows.Count; i++)
                {

                    string strSQL = "INSERT INTO " + tableName + "(product_id,store_id,layout_id)" + "VALUES('"
                       + dtOc5eProductToLayout.Rows[i][0].ToString() + "',"
                       + "'" + dtOc5eProductToLayout.Rows[i][1].ToString() + "',"
                       + "'" + dtOc5eProductToLayout.Rows[i][2].ToString() + "'"
                       + ")";

                    var objCmd = new MySqlCommand(strSQL, connection);
                    var sendData = objCmd.ExecuteNonQuery();
                }

                MessageBox.Show(tableName + " Tablosuna Excel Kayıtları Eklendi !");
                textBoxExcelFilePath.Text = String.Empty;
                connection.Close();

                Cursor.Current = Cursors.Default;
            }

            #endregion

            #region ocly_product_to_store

            else if (tableName == "ocly_product_to_store")
            {

                Cursor.Current = Cursors.WaitCursor;

                FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);

                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                var result = new ExcelDataReader.ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataReader.ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true
                    }
                };


                var dataSet = excelReader.AsDataSet(result);

                DataTable dtOc5eProductToStore = new DataTable();

                dtOc5eProductToStore = dataSet.Tables[0];
                connection.Open();

                for (int i = 0; i < dtOc5eProductToStore.Rows.Count; i++)
                {

                    string strSQL = "INSERT INTO " + tableName + "(product_id,store_id)" + "VALUES('"
                       + dtOc5eProductToStore.Rows[i][0].ToString() + "',"
                       + "'" + dtOc5eProductToStore.Rows[i][1].ToString() + "'"
                       + ")";

                    var objCmd = new MySqlCommand(strSQL, connection);
                    var sendData = objCmd.ExecuteNonQuery();
                }

                MessageBox.Show(tableName + " Tablosuna Excel Kayıtları Eklendi !");
                textBoxExcelFilePath.Text = String.Empty;
                connection.Close();

                Cursor.Current = Cursors.Default;
            }

            #endregion

            #region ocly_seo_url

            else if (tableName == "ocly_seo_url")
            {

                Cursor.Current = Cursors.WaitCursor;

                FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);

                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                var result = new ExcelDataReader.ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataReader.ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true
                    }
                };


                var dataSet = excelReader.AsDataSet(result);

                DataTable dtOc5eSeoUrl = new DataTable();

                dtOc5eSeoUrl = dataSet.Tables[0];
                connection.Open();

                for (int i = 0; i < dtOc5eSeoUrl.Rows.Count; i++)
                {

                    string strSQL = "INSERT INTO " + tableName + "(seo_url_id,store_id,language_id,query,keyword)" + "VALUES('"
                       + dtOc5eSeoUrl.Rows[i][0].ToString() + "',"
                       + "'" + dtOc5eSeoUrl.Rows[i][1].ToString() + "',"
                       + "'" + dtOc5eSeoUrl.Rows[i][2].ToString() + "',"
                       + "'" + dtOc5eSeoUrl.Rows[i][3].ToString() + "',"
                       + "'" + dtOc5eSeoUrl.Rows[i][4].ToString() + "'"
                       + ")";

                    var objCmd = new MySqlCommand(strSQL, connection);
                    var sendData = objCmd.ExecuteNonQuery();
                }

                MessageBox.Show(tableName + " Tablosuna Excel Kayıtları Eklendi !");
                textBoxExcelFilePath.Text = String.Empty;
                connection.Close();
                Cursor.Current = Cursors.Default;
            }

            #endregion

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxTableList.Items.Add("ocly_product");
            comboBoxTableList.Items.Add("ocly_product_description");
            comboBoxTableList.Items.Add("ocly_product_image");
            comboBoxTableList.Items.Add("ocly_product_related");
            comboBoxTableList.Items.Add("ocly_product_special");
            comboBoxTableList.Items.Add("ocly_product_to_category");
            comboBoxTableList.Items.Add("ocly_product_to_layout");
            comboBoxTableList.Items.Add("ocly_product_to_store");
            comboBoxTableList.Items.Add("ocly_seo_url");

        }

        private void comboBoxTableList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            tableName = comboBoxTableList.SelectedItem.ToString();
            groupBox1.Text = tableName;
            DataTable Dt = new DataTable();
            string query = "SELECT * FROM " + tableName + "";
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter Da = new MySqlDataAdapter(cmd);
            Da.Fill(Dt);
            dataGridView1.DataSource = Dt;
            labelTotalCount.Text = dataGridView1.RowCount.ToString();
            connection.Close();
            Cursor.Current = Cursors.Default;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSendBulkImage_Click(object sender, EventArgs e)
        {
            FtpCredentials ftpCredentialFrm = new FtpCredentials();
            ftpCredentialFrm.Show();

        }
    }

}

