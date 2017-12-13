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
    public partial class Thempn : Form
    {
        PHIEUNHAP pn = new PHIEUNHAP();
        DONDATHANG ddh = new DONDATHANG();
        CTPN pnc = new CTPN();
        List<CTPN> dsct = new List<CTPN>();
        List<SANPHAM> dssp = new List<SANPHAM>();
        public Thempn()
        {
            InitializeComponent();
        }
        public void set(DONDATHANG dh, int manv, List<SANPHAM> ds)
        {
            ddh = dh;
            pn.ID = dh.ID;
            pn.IDNCC = dh.IDNCC;
            pn.NCC = dh.NCC;
            pn.IDNV = manv;
            pn.GHICHU=dh.GHICHU;
            richTextBox2.Text = pn.GHICHU;
            textBox1.Text = pn.NCC.TENNCC;
            List<CTDH> ctdh = BUS.QLNHAP_BUS.loaddh(dh.ID);
            foreach(var ct in ctdh)
            {
                CTPN ctt = new CTPN();
                ctt.ID = ct.ID;
                ctt.IDSP = ct.IDSP;
                ctt.SANPHAM = ct.SANPHAM;
                ctt.SL = ct.SL;
                ctt.DONGIA = ct.DONGIA;
                ctt.GHICHU = ct.GHICHU;
                dsct.Add(ctt);
            }
            gridControl2.DataSource = dsct;
        }

        private void xoasp_Click(object sender, EventArgs e)
        {
            dsct.Remove(pnc);
            gridControl2.DataSource = dsct;
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            pnc.IDSP = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "IDSP").ToString());
            pnc.SL = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "SL").ToString());
            pnc.DONGIA = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "DONGIA").ToString());
            pnc.GHICHU = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "GHICHU").ToString();
            textBox5.Text = pnc.SL.ToString();
            textBox6.Text = pnc.DONGIA.ToString();
            richTextBox1.Text = pnc.GHICHU;
        }

        private void themsp_Click(object sender, EventArgs e)
        {
            CTPN ct = new CTPN();
            ct = pnc;
            ct.SANPHAM = dssp.Where(s => s.ID == ct.IDSP).FirstOrDefault();
            ct.SL = int.Parse(textBox5.Text);
            ct.DONGIA = int.Parse(textBox6.Text);
            ct.GHICHU = richTextBox1.Text;
            var x = dsct.Where(s => s.IDSP == pnc.IDSP).FirstOrDefault();
            dsct.Remove(x);
            dsct.Add(ct);
            gridControl2.DataSource = dsct;
        }

        private void luu_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                pn.GHICHU = richTextBox2.Text;
                pn.NCC = null;
                int t = BUS.QLNHAP_BUS.them(pn);
                if (t == 0)
                    MessageBox.Show("Gặp lỗi pn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    t = BUS.QLNHAP_BUS.them(dsct);
                    if (t == 0)
                    {
                        MessageBox.Show("Gặp lỗi ct!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        BUS.QLNHAP_BUS.xoa();
                    }
                    else
                        t = BUS.QLNHAP_BUS.tangno(pn.IDNCC);
                    if (t == 0)
                    {
                        MessageBox.Show("Gặp lỗi no!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        ddh.TINHTRANG = true;
                        ddh.GHICHU = "Đã nhập";
                        t = BUS.QLNHAP_BUS.sua(ddh);
                        if (t == 0)
                            MessageBox.Show("Gặp lỗi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (t != 0)
                    this.Close();

            }
        }
    }
}
