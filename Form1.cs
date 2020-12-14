using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace lab5
{
    public partial class Form1 : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ClinicConnection"].ConnectionString;
        SqlDataAdapter adapter;
        DataSet dataSet = new DataSet("Clinic");
        SqlCommandBuilder sqlCommandBuilder;
        int checkTable = 0;

        DataBaseController dbc = new DataBaseController();

        public Form1()
        {
            InitializeComponent();
            dbc.OpenConnection(connectionString);
            //string connectionString = @"Data Source=.\blackberry;Initial Catalog=Clinic;Integrated Security=False";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dbc.GetDataDocuments();
            checkTable = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dbc.GetDataNaprav();
            checkTable = 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dbc.GetDataEquipments();
            checkTable = 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dbc.GetDataPacients();
            checkTable = 4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dbc.GetDataProcedure();
            checkTable = 5;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            switch (checkTable)
            {
                case 1: 
                    {
                        dbc.InsertDocuments(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                        dataGridView1.DataSource = dbc.GetDataDocuments();
                        break;
                    };
                case 2: 
                    {
                        dbc.InsertNaprav(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                        dataGridView1.DataSource = dbc.GetDataNaprav();
                        break; 
                    };
                case 3: 
                    { 
                        dbc.InsertEquipments(textBox1.Text,textBox2.Text);
                        dataGridView1.DataSource = dbc.GetDataEquipments();
                        break; 
                    };
                case 4: 
                    {
                        dbc.InsertPacients(textBox1.Text, textBox2.Text);
                        dataGridView1.DataSource = dbc.GetDataPacients();
                        break; 
                    };
                case 5: 
                    {
                        dbc.InsertProcedure(textBox1.Text, Convert.ToInt32(textBox2.Text));
                        dataGridView1.DataSource = dbc.GetDataProcedure();
                        break; 
                    };
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            switch (checkTable)
            {
                case 1: 
                    {
                        dbc.DeleteDocuments(Convert.ToInt32(textBox3.Text));
                        dataGridView1.DataSource = dbc.GetDataDocuments();
                        break; 
                    };
                case 2: 
                    {
                        dbc.DeleteNaprav(Convert.ToInt32(textBox3.Text));
                        dataGridView1.DataSource = dbc.GetDataNaprav();
                        break; 
                    };
                case 3: 
                    {
                        dbc.DeleteEquipments(Convert.ToInt32(textBox3.Text));
                        dataGridView1.DataSource = dbc.GetDataEquipments();
                        break; 
                    };
                case 4: 
                    {
                        dbc.DeletePacients(Convert.ToInt32(textBox3.Text));
                        dataGridView1.DataSource = dbc.GetDataPacients();
                        break; 
                    };
                case 5:
                    {
                        dbc.DeleteProcedure(Convert.ToInt32(textBox3.Text));
                        dataGridView1.DataSource = dbc.GetDataProcedure();
                        break; 
                    };
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            switch (checkTable)
            { 
                case 1: 
                    {
                        dbc.UpdateDocuments(Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                        dataGridView1.DataSource = dbc.GetDataDocuments();
                        break; 
                    };
                case 2: 
                    {
                        dbc.UpdateNaprav(Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                        dataGridView1.DataSource = dbc.GetDataNaprav();
                        break; 
                    };
                case 3: 
                    {
                        dbc.UpdateEquipments(Convert.ToInt32(textBox3.Text), textBox1.Text, textBox2.Text);
                        dataGridView1.DataSource = dbc.GetDataEquipments();
                        break; 
                    };
                case 4: 
                    {
                        dbc.UpdatePacients(Convert.ToInt32(textBox3.Text),textBox1.Text,textBox2.Text);
                        dataGridView1.DataSource = dbc.GetDataPacients();
                        break; 
                    };
                case 5: 
                    {
                        dbc.UpdateProcedure(Convert.ToInt32(textBox3.Text), textBox1.Text, Convert.ToInt32(textBox2.Text));
                        dataGridView1.DataSource = dbc.GetDataProcedure();
                        break; 
                    };
            }
        }
    }
}
