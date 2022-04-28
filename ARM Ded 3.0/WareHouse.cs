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

    public partial class WareHouse : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= ARM.mdb";
        private OleDbConnection myConnection;
        public WareHouse()
        {
            InitializeComponent();
           // myConnection = new OleDbConnection(connectString);
            //myConnection.Open();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Deliveries frm = new Deliveries();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Shipment frm = new Shipment();
            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CheckList frm = new CheckList();
            frm.Show();
        }

        private void WareHouse_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "aRMDataSet.Товары". При необходимости она может быть перемещена или удалена.
        //    this.товарыTableAdapter.Fill(this.aRMDataSet.Товары);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Name = textBox1.Text;
            string query = "SELECT [Код], [Название], [Кол-во], [Поставщик] FROM Товары WHERE  Название LIKE '%" + Name + "%' ";
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
        //    dataGridView1.DataSource = товарыBindingSource;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox2.Text);
            string query = "DELETE FROM Товары WHERE [Код] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
        //    this.товарыTableAdapter.Fill(this.aRMDataSet.Товары);
            textBox2.Clear();
        }

        private void WareHouse_Activated(object sender, EventArgs e)
        {
       //     this.товарыTableAdapter.Fill(this.aRMDataSet.Товары);
        }
    }
}
