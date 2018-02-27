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

        public Form1()
        {
            InitializeComponent();
            server = "5.250.241.18";
            database = "platinde_ocar405";
            uid = "platinde";
            password = "Platin1987";
            port = "3308";

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

                DataTable dt = new DataTable();

                dt = dataSet.Tables[0];
                connection.Open();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //string strSQL = "INSERT INTO " + tableName + "(model,quantity,stock_status_id,image,manufacturer_id,shipping,price,tax_class_id,date_available,weight_class_id,length_class_id,subtract,minimum,sort_order,status,date_added,date_modified)" + "VALUES('"
                    string strSQL = "INSERT INTO " + tableName + "(model,quantity,stock_status_id,image,manufacturer_id,shipping,price,tax_class_id,date_available,weight_class_id,length_class_id,subtract,minimum,sort_order,status,date_added,date_modified)" + "VALUES('"
                       + dt.Rows[i][0].ToString() + "',"
                       + "'" + dt.Rows[i][1].ToString()  + "',"
                       + "'" + dt.Rows[i][2].ToString()  + "',"
                       + "'" + dt.Rows[i][3].ToString()  + "',"
                       + "'" + dt.Rows[i][4].ToString()  + "',"
                       + "'" + dt.Rows[i][5].ToString()  + "',"
                       + "'" + dt.Rows[i][6].ToString()  + "',"
                       + "'" + dt.Rows[i][7].ToString()  + "',"
                       + "'" + dt.Rows[i][8].ToString()  + "',"
                       + "'" + dt.Rows[i][9].ToString()  + "',"
                       + "'" + dt.Rows[i][10].ToString() + "',"
                       + "'" + dt.Rows[i][11].ToString() + "',"
                       + "'" + dt.Rows[i][12].ToString() + "',"
                       + "'" + dt.Rows[i][13].ToString() + "',"
                       + "'" + dt.Rows[i][14].ToString() + "',"
                       + "'" + dt.Rows[i][15].ToString() + "',"
                       + "'" + dt.Rows[i][16].ToString() + "'"
                       + ")";

                    var objCmd = new MySqlCommand(strSQL, connection);
                    var sendData = objCmd.ExecuteNonQuery();
                }

                MessageBox.Show(tableName + " Tablosuna Excel Kayıtları Eklendi !");

            }


            else if (tableName == "oc5e_product_description")
            {

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
