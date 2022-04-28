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
    public partial class Shipment : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= ARM.mdb";
        private OleDbConnection myConnection;
        public Shipment()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Shipment_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "aRMDataSet.Отгрузка". При необходимости она может быть перемещена или удалена.
            this.отгрузкаTableAdapter.Fill(this.aRMDataSet.Отгрузка);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox1.Text);
            string Name = textBox2.Text;
            string Kolvo = textBox3.Text;
            string Time = textBox5.Text;
            string Zakup = textBox6.Text;
            string Status = "Отгрузка";
            string otchet = "INSERT INTO Отчет ([Товар],[Дата],[Поставщик],[Статус]) VALUES ('" + Name + "', '" + Time + "','" + Zakup + "','" + Status + "')";
            OleDbCommand otchet1 = new OleDbCommand(otchet, myConnection);
            otchet1.ExecuteNonQuery();
            string query = "DELETE FROM Товары WHERE [Код] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            string Zakup1 = "INSERT INTO Отгрузка ([Код товара],[Наименование],[Количество],[Дата отгрузки],[Закупщик],[Статус]) VALUES(" + kod + ",'" + Name + "', '" + Kolvo + "','" + Time + "','" + Zakup + "','" + Status + "')";
            MessageBox.Show("Данные обновлены!");
            OleDbCommand Zakup12 = new OleDbCommand(Zakup1, myConnection);
            command.ExecuteNonQuery();
        }
    }
}
