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
    public partial class WareHouse : Form
    {
        public WareHouse()
        {
            InitializeComponent();
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
    }
}
