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
    public partial class ThemCTDH : Form
    {
        int idnv;
        int t = 0;
        DONDATHANG dh = new DONDATHANG();
        CTDH ct = new CTDH();
        List<CTDH> dsct = new List<CTDH>();
        List<SANPHAM> sp = new List<SANPHAM>();
        public ThemCTDH()
        {
            InitializeComponent();
        }
        public void set(List<NCC> dsncc, List<SANPHAM> ds, int id)
        {
            sp = ds;
            idnv = id;
            comboBox2.DataSource = dsncc;
            comboBox2.DisplayMember = "TENNCC";
            comboBox2.ValueMember = "ID";        
            comboBox1.DataSource = ds;
            comboBox1.DisplayMember = "TENSP";
            comboBox1.ValueMember = "ID";
        }

        private void themsp_Click(object sender, EventArgs e)
        {
            CTDH cttemp = new CTDH();
            cttemp.ID = t;
            cttemp.IDSP = int.Parse(comboBox1.SelectedValue.ToString());
            cttemp.SANPHAM = sp.Where(s => s.ID == cttemp.IDSP).FirstOrDefault();
            cttemp.SL = int.Parse(textBox5.Text);
            cttemp.DONGIA = int.Parse(textBox6.Text);
            cttemp.GHICHU = richTextBox1.Text;
            dsct.Add(cttemp);
            gridControl2.DataSource = dsct;
            gridControl2.RefreshDataSource();
            t++;
        }

        private void xoasp_Click(object sender, EventArgs e)
        {
            CTDH cttemp = new CTDH();
            cttemp.ID = ct.ID;
            cttemp.IDSP = int.Parse(comboBox1.SelectedValue.ToString());
            cttemp.SANPHAM = sp.Where(s => s.ID == cttemp.IDSP).FirstOrDefault();
            cttemp.SL = int.Parse(textBox5.Text);
            cttemp.DONGIA = int.Parse(textBox6.Text);
            cttemp.GHICHU = richTextBox1.Text;
            dsct.Remove(cttemp);
            gridControl2.DataSource = dsct;
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            ct.IDSP = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "IDSP").ToString());
            ct.SL = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "SL").ToString());
            ct.DONGIA = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "DONGIA").ToString());
            ct.GHICHU = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "GHICHU").ToString();
            comboBox1.SelectedValue = ct.IDSP;
            textBox5.Text = ct.SL.ToString();
            textBox6.Text = ct.DONGIA.ToString();
            richTextBox1.Text = ct.GHICHU;
        }

        private void luu_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                dh.ID = 0;
                dh.NGAY = dateTimePicker1.Value.Date;
                dh.IDNCC = int.Parse(comboBox2.SelectedValue.ToString());
                dh.IDNV = idnv;
                dh.GHICHU = richTextBox2.Text;
                dh.TINHTRANG = false;
                int t = BUS.QLNHAP_BUS.them(dh);
                if (t == 0)
                    MessageBox.Show("Gặp lỗi d!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    t=BUS.QLNHAP_BUS.them(dsct);
                    if (t == 0)
                        MessageBox.Show("Gặp lỗi ct!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                               
                if (t != 0)
                    this.Close();
            }                  
                
        }

     

        
    }
}
