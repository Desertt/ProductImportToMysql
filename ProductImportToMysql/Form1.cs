using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Net;
using ExcelDataReader;


namespace ProductImportToMysql
{
    public partial class Form1 : Form
    {
        public MySqlConnection connection;
        public string server;
        public string database; 
        public string uid;
        public string password;   
        public string port; 
        public string tableName = string.Empty;
        DateTime date;  // Use date
        string strDate = "Unknown";
        
        
        public Form1()
        {
            InitializeComponent();
            server = "1.250.240.75";
            database = "oscar_ocar905";
            uid = "Test";
            password = "Test1453";
            port = "3306";

            string connectionString;
            connectionString = @"SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";" + "PORT = " + port + ";";

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


            if (tableName == "oc5e_product")
            {

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

                    string strSQL = "INSERT INTO " + tableName + "(model,quantity,stock_status_id,image,manufacturer_id,shipping,price,tax_class_id,date_available,weight_class_id,length_class_id,subtract,minimum,sort_order,status,date_added,date_modified)" + "VALUES('"
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
                       + "'" + dtOc5eProduct.Rows[i][16].ToString() + "'"
                       + ")";

                    var objCmd = new MySqlCommand(strSQL, connection);
                    var sendData = objCmd.ExecuteNonQuery();
                }

                MessageBox.Show(tableName + " Tablosuna Excel Kayıtları Eklendi !");
                textBoxExcelFilePath.Text = String.Empty;
                connection.Close();
            }


            else if (tableName == "oc5e_product_description")
            {
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

                    string strSQL = "INSERT INTO " + tableName + "(model,quantity,stock_status_id,image,manufacturer_id,shipping,price,tax_class_id,date_available,weight_class_id,length_class_id,subtract,minimum,sort_order,status,date_added,date_modified)" + "VALUES('"
                       + dtOc5eProductDescription.Rows[i][0].ToString() + "',"
                       + "'" + dtOc5eProductDescription.Rows[i][1].ToString() + "',"
                       + "'" + dtOc5eProductDescription.Rows[i][2].ToString() + "',"
                       + "'" + dtOc5eProductDescription.Rows[i][3].ToString() + "',"
                       + "'" + dtOc5eProductDescription.Rows[i][4].ToString() + "',"
                       + "'" + dtOc5eProductDescription.Rows[i][5].ToString() + "',"
                       + "'" + dtOc5eProductDescription.Rows[i][6].ToString() + "',"
                       + "'" + dtOc5eProductDescription.Rows[i][7].ToString() + "',"
                       + "'" + dtOc5eProductDescription.Rows[i][8].ToString() + "',"
                       + "'" + dtOc5eProductDescription.Rows[i][9].ToString() + "',"
                       + "'" + dtOc5eProductDescription.Rows[i][10].ToString() + "',"
                       + "'" + dtOc5eProductDescription.Rows[i][11].ToString() + "',"
                       + "'" + dtOc5eProductDescription.Rows[i][12].ToString() + "',"
                       + "'" + dtOc5eProductDescription.Rows[i][13].ToString() + "',"
                       + "'" + dtOc5eProductDescription.Rows[i][14].ToString() + "',"
                       + "'" + dtOc5eProductDescription.Rows[i][15].ToString() + "',"
                       + "'" + dtOc5eProductDescription.Rows[i][16].ToString() + "'"
                       + ")";

                    var objCmd = new MySqlCommand(strSQL, connection);
                    var sendData = objCmd.ExecuteNonQuery();
                }

                MessageBox.Show(tableName + " Tablosuna Excel Kayıtları Eklendi !");
                textBoxExcelFilePath.Text = String.Empty;
                connection.Close();
            }
            else if (tableName == "oc5e_product_image")
            {

            }
            else if (tableName == "oc5e_category")
            {

            }
            else if (tableName == "oc5e_product_to_category")
            {

            }
            else if (tableName == "oc5e_category_description")
            {

            }
            else if (tableName == "oc5e_category_path")
            {

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxTableList.Items.Add("oc5e_product");
            comboBoxTableList.Items.Add("oc5e_product_description");
            comboBoxTableList.Items.Add("oc5e_product_image");
            comboBoxTableList.Items.Add("oc5e_category");
            comboBoxTableList.Items.Add("oc5e_product_to_category");
            comboBoxTableList.Items.Add("oc5e_category_description");
            comboBoxTableList.Items.Add("oc5e_category_path");
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
    }
}
