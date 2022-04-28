using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ARM_Ded_3._0
{
    public partial class Deliveries : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= ARM.mdb";
        private OleDbConnection myConnection;
        public Deliveries()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Deliveries_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "aRMDataSet.Поставки". При необходимости она может быть перемещена или удалена.
            this.поставкиTableAdapter.Fill(this.aRMDataSet.Поставки);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Name = textBox4.Text;
            string query = "SELECT [Код поставки], [Поставщик], [Дата поставки], [Товар], [Количество],[Статус] FROM Поставки WHERE [Дата поставки] LIKE '%" + Name + "%' ";
            OleDbDataAdapter command = new OleDbDataAdapter(query, myConnection);
            DataTable dt = new DataTable();
            command.Fill(dt);
            dataGridView1.DataSource = dt;
            myConnection.Close();
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            dataGridView1.DataSource = поставкиBindingSource;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Postavka = textBox1.Text;
            string Time = textBox2.Text;
            string Tovar = textBox3.Text;
            string Kolvo = textBox5.Text;
            string Status = "Поставка";
            string query = "INSERT INTO Поставки ([Поставщик],[Дата поставки],[Товар],[Количество],[Статус]) VALUES('" + Postavka + "','" + Time + "', '" + Tovar + "','" + Kolvo + "','" + Status + "')";
            string sklad = "INSERT INTO Товары ([Название],[Кол-во],[Поставщик]) VALUES ('" + Tovar + "', '" + Kolvo + "','" + Postavka + "')";
            string otchet = "INSERT INTO Отчет ([Товар],[Дата],[Поставщик],[Статус]) VALUES ('" + Tovar + "', '" + Time + "','" + Postavka + "','" +Status+ "')";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            OleDbCommand sklad1 = new OleDbCommand(sklad, myConnection);
            sklad1.ExecuteNonQuery();
            OleDbCommand otchet1 = new OleDbCommand(otchet, myConnection);
            otchet1.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            this.поставкиTableAdapter.Fill(this.aRMDataSet.Поставки);

        }
    }
}
