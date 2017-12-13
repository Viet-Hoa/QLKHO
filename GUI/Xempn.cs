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
    public partial class Xempn : Form
    {
        public Xempn()
        {
            InitializeComponent();
        }
        public void set(PHIEUNHAP pn, string y)
        {
            label1.Text += " " + pn.ID;
            label2.Text += " " + pn.NGAY.ToString("dd/MM/yyyy");
            label3.Text += " " + y;
            gridControl2.DataSource = BUS.QLNHAP_BUS.loadpn(pn.ID);
        }
    }
}
