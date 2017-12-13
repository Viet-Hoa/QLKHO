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
    public partial class Xempx : Form
    {
        public Xempx()
        {
            InitializeComponent();
        }
        public void set(PHIEUXUAT px)
        {
            label1.Text += " " + px.ID;
            label2.Text += " " + px.NGAY.ToString("dd/MM/yyyy");
            label3.Text += " " + px.CUAHANG.TENCH;
            label4.Text += " " + px.PHANTRAMLOI;
            label5.Text += " " + px.KHUYENMAI;
            gridControl2.DataSource = BUS.QLXUAT_BUS.loadpx(px.ID);
        }
    }
}
