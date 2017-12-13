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
    public partial class XemCTDH : Form
    {
        public XemCTDH()
        {
            InitializeComponent();
        }
        public void set(DONDATHANG dh)
        {
            label1.Text += " " + dh.ID;
            label2.Text += " " + dh.NGAY.ToString("dd/MM/yyyy");
            label3.Text += " " + dh.NCC.TENNCC;
            gridControl2.DataSource = BUS.QLNHAP_BUS.loaddh(dh.ID);
        }

        
    }
}
