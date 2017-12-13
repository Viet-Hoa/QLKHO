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
    public partial class ThemYCX : Form
    {
        int idnv;
        YCXUAT yc = new YCXUAT();
        CTYCX ct = new CTYCX();
        List<CTYCX> dsct = new List<CTYCX>();
        List<SANPHAM> sp = new List<SANPHAM>();
        public ThemYCX()
        {
            InitializeComponent();
        }
        public void set(List<CUAHANG> dsch, List<SANPHAM> ds, int id)
        {
            sp = ds;
            idnv = id;
            comboBox2.DataSource = dsch;
            comboBox2.DisplayMember = "TENCH";
            comboBox2.ValueMember = "ID";        
            comboBox1.DataSource = ds;
            comboBox1.DisplayMember = "TENSP";
            comboBox1.ValueMember = "ID";
        }

        private void themsp_Click(object sender, EventArgs e)
        {
            CTYCX ctt = new CTYCX();
            ctt.ID = 0;
            ctt.IDSP = int.Parse(comboBox1.SelectedValue.ToString());
            ctt.SANPHAM = sp.Where(s => s.ID == ct.IDSP).FirstOrDefault();
            ctt.SL = int.Parse(textBox5.Text);            
            ctt.GHICHU = richTextBox1.Text;
            dsct.Add(ctt);
            gridControl2.DataSource = dsct;
        }

        private void xoasp_Click(object sender, EventArgs e)
        {
            CTYCX ctt = new CTYCX();
            ctt.ID = 0;
            ctt.IDSP = int.Parse(comboBox1.SelectedValue.ToString());
            ctt.SL = int.Parse(textBox5.Text);            
            ctt.GHICHU = richTextBox1.Text;
            dsct.Remove(ctt);
            gridControl2.DataSource = dsct;
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            ct.IDSP = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "IDSP").ToString());
            ct.SL = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "SL").ToString());
            ct.GHICHU = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "GHICHU").ToString();
            comboBox1.SelectedValue = ct.IDSP;
            textBox5.Text = ct.SL.ToString();
            
            richTextBox1.Text = ct.GHICHU;
        }

        private void luu_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                yc.ID = 0;
                yc.NGAY = dateTimePicker1.Value.Date;
                yc.IDCH = int.Parse(comboBox2.SelectedValue.ToString());
                yc.IDNV = idnv;
                yc.GHICHU = richTextBox2.Text;
                yc.TINHTRANG = false;
                int t = BUS.QLXUAT_BUS.them(yc);
                if (t == 0)
                    MessageBox.Show("Gặp lỗi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    t = BUS.QLXUAT_BUS.them(dsct);
                    if (t == 0)
                    {
                        MessageBox.Show("Gặp lỗi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);                        
                    }
                }                               
                if (t != 0)
                    this.Close();
            }                  
                
        }

     

        
    }
}
