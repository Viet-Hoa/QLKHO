using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace GUI
{
    public partial class Xemycx : Form
    {
        public Xemycx()
        {
            InitializeComponent();
        }
        public void set(YCXUAT yc)
        {
            label1.Text += " " + yc.ID;
            label2.Text += " " + yc.NGAY.ToString("dd/MM/yyyy");
            label3.Text += " " + yc.CUAHANG.TENCH;
            gridControl2.DataSource = BUS.QLNHAP_BUS.loadpn(yc.ID);
        }
    }
}
