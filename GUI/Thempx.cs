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
    public partial class Thempx : Form
    {
        PHIEUXUAT px = new PHIEUXUAT();
        CTPX pxc = new CTPX();
        List<CTPX> dsct = new List<CTPX>();
        List<SANPHAM> dssp = new List<SANPHAM>();
        public Thempx()
        {
            InitializeComponent();
        }
        public void set(YCXUAT yc, int manv,List<SANPHAM> ds)
        {
            dssp = ds;
            px.ID = yc.ID;
            px.IDCH = yc.IDCH;
            px.CUAHANG = yc.CUAHANG;
            px.IDNV = manv;
            px.GHICHU=yc.GHICHU;
            richTextBox2.Text = px.GHICHU;
            textBox1.Text = px.CUAHANG.TENCH;
            List<CTYCX> ctdh = BUS.QLXUAT_BUS.loadyc(yc.ID);
            foreach(var ct in ctdh)
            {
                CTPX ctt = new CTPX();
                ctt.ID = ct.ID;
                ctt.IDSP = ct.IDSP;
                ctt.SANPHAM = ct.SANPHAM;
                ctt.SL = ct.SL;
                ctt.GHICHU = ct.GHICHU;
                dsct.Add(ctt);
            }
            gridControl2.DataSource = dsct;
        }

        private void xoasp_Click(object sender, EventArgs e)
        {
            dsct.Remove(pxc);
            gridControl2.DataSource = dsct;
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            pxc.IDSP = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "IDSP").ToString());
            pxc.SL = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "SL").ToString());
            pxc.GHICHU = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "GHICHU").ToString();
            textBox5.Text = pxc.SL.ToString();            
            richTextBox1.Text = pxc.GHICHU;
        }

        private void themsp_Click(object sender, EventArgs e)
        {
            CTPX ctt = new CTPX();
            ctt = pxc;
            ctt.SL = int.Parse(textBox5.Text);            
            ctt.GHICHU = richTextBox1.Text;
            var x = dsct.Where(s => s.IDSP == ctt.IDSP).FirstOrDefault();
            dsct.Remove(x);
            dsct.Add(ctt);
            gridControl2.DataSource = dsct;
        }

        private void luu_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                px.GHICHU = richTextBox2.Text;
                px.PHANTRAMLOI = int.Parse(textBox2.Text);
                px.KHUYENMAI = int.Parse(textBox3.Text);
                px.CUAHANG = null;
                int t = BUS.QLXUAT_BUS.them(px);
                if (t == 0)
                    MessageBox.Show("Gặp lỗi px!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    t = BUS.QLXUAT_BUS.them(dsct);
                    if (t == 0)
                    {
                        MessageBox.Show("Gặp lỗi ct!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);                        
                    }
                    else
                        t = BUS.QLXUAT_BUS.tangno(px.IDCH);
                    if (t == 0)
                    {
                        MessageBox.Show("Gặp lỗi no!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (t != 0)
                    this.Close();

            }
        }

    }
}
