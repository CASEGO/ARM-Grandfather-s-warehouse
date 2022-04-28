using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARM_Ded_3._0
{
    public partial class CheckList : Form
    {
        public CheckList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CheckList_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "aRMDataSet.Отчет". При необходимости она может быть перемещена или удалена.
            this.отчетTableAdapter.Fill(this.aRMDataSet.Отчет);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "aRMDataSet.Отчет". При необходимости она может быть перемещена или удалена.

        }
    }
}
