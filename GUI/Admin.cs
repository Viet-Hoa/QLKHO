using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using BUS;
using DTO;

namespace GUI
{
    public partial class Admin : Form
    {
        public NHANVIEN nv;
        public NHANVIEN nvtemp = new NHANVIEN();
        public SANPHAM sp = new SANPHAM();
        public DONDATHANG dh = new DONDATHANG();
        public PHIEUNHAP pn = new PHIEUNHAP();
        public YCXUAT yc = new YCXUAT();
        public PHIEUXUAT px = new PHIEUXUAT();
        public List<SANPHAM> dssp = new List<SANPHAM>();
        public List<NCC> dsncc = new List<NCC>();
        public List<CUAHANG> dsch = new List<CUAHANG>();
        public PHIEUTHU pt = new PHIEUTHU();
        public PHIEUCHI pc = new PHIEUCHI();
        public Admin()
        {
            InitializeComponent();
            nv = BUS.QLTK_BUS.manv();
            loadsp();
            loadch();
            loadncc();
            loaddh();
            loadpn();
            loadchi();
            loadthu();
            loadnv();
            loadyc();
            loadpx();
            comboBox1.DataSource = dsch;
            comboBox1.DisplayMember = "TENCH";
            comboBox1.ValueMember = "ID";
            comboBox2.DataSource = dsncc;
            comboBox2.DisplayMember = "TENNCC";
            comboBox2.ValueMember = "ID";
        }
        private void loadsp()
        {
            dssp = BUS.QLSP_BUS.load();
            this.gridControl1.DataSource = dssp;
            gridView1.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(gridView1_RowStyle);
            if (!dssp.Any())
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                String t = View.GetRowCellDisplayText(e.RowHandle, View.Columns["GHICHU"]);
                if (t=="ngừng KD")
                {
                    e.Appearance.BackColor = Color.Gray;
                    e.Appearance.BackColor2 = Color.SeaShell;
                    e.HighPriority = true;
                }
            }
        }
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                textBox1.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString();
                textBox2.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LOAISP").ToString();
                textBox3.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TENSP").ToString();
                textBox4.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NSX").ToString();
                textBox5.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SL").ToString();
                textBox6.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DG").ToString();
                richTextBox1.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GHICHU").ToString(); 
                sp.ID = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString());
                sp.LOAISP = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LOAISP").ToString();
                sp.TENSP = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TENSP").ToString();
                sp.NSX = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NSX").ToString();
                int sl = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SL").ToString());
                sp.SL = sl;
                int dgm = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DG").ToString());
                sp.DG = dgm;
                sp.GHICHU = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GHICHU").ToString();
                sp.TINHTRANG = Convert.ToBoolean(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TINHTRANG").ToString());
                if (sp.TINHTRANG)
                    khoasp.Enabled = true;
                else
                    khoasp.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gặp lỗi!\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void themsp_Click(object sender, EventArgs e)
        {
            sp.ID = 0;
            sp.LOAISP = textBox2.Text;
            sp.TENSP = textBox3.Text;
            sp.NSX = textBox4.Text;
            sp.SL = 0;
            sp.DG = 0;
            sp.GHICHU = richTextBox1.Text;
            sp.TINHTRANG = true;
            int t = BUS.QLSP_BUS.them(sp);
            loadsp();
            if(t==0)
                MessageBox.Show("Gặp lỗi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void suasp_Click(object sender, EventArgs e)
        {
            sp.ID = int.Parse(textBox1.Text);
            sp.LOAISP = textBox2.Text;
            sp.TENSP = textBox3.Text;
            sp.NSX = textBox4.Text;
            sp.SL = int.Parse(textBox5.Text);
            sp.DG = int.Parse(textBox6.Text);
            sp.GHICHU = richTextBox1.Text;
            int t = BUS.QLSP_BUS.sua(sp);
            if (t == 0)
                MessageBox.Show("Gặp lỗi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            loadsp();
        }

        private void khoasp_Click(object sender, EventArgs e)
        {
            if(sp.SL!=0 && sp.GHICHU!="ngừng KD")
                MessageBox.Show("Không thể khoá! Số lượng phải bằng 0 và ghi chú: ngừng KD", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                sp.TINHTRANG = false;
                int t = BUS.QLSP_BUS.sua(sp);
                if (t == 0)
                    MessageBox.Show("Gặp lỗi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void clearsp_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            richTextBox1.Text = "";
        }

        private void rfsp_Click(object sender, EventArgs e)
        {
            loadsp();
        }

        private void loaddh()
        {
            List<DONDATHANG> dsdh = BUS.QLNHAP_BUS.loaddh();
            this.gridControl2.DataSource = dsdh;
            gridView2.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(gridView2_RowStyle);
        }

        private void rfdh_Click(object sender, EventArgs e)
        {
            loaddh();
        }
        private void loadncc()
        {
            dsncc = BUS.QLDOITAC_BUS.loadncc();
        }
        private void loadch()
        {
            dsch = BUS.QLDOITAC_BUS.loadch();
        }
        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                dh.ID = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "ID").ToString());
                dh.NGAY = DateTime.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "NGAY").ToString());
                dh.IDNCC = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "IDNCC").ToString());
                dh.IDNV = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "IDNV").ToString());
                dh.GHICHU = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "GHICHU").ToString();
                dh.TINHTRANG = Convert.ToBoolean(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "TINHTRANG").ToString());
                if (dh.GHICHU != "Đã nhập" && dh.TINHTRANG == false)
                {
                    nhap.Enabled = true;
                    cleardh.Enabled = true;
                }                    
                else
                {
                    nhap.Enabled = false;
                    cleardh.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gặp lỗi!\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridView2_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                String t = View.GetRowCellDisplayText(e.RowHandle, View.Columns["GHICHU"]);
                if (t == "Đã nhập")
                {
                    e.Appearance.BackColor = Color.Gray;
                    e.Appearance.BackColor2 = Color.SeaShell;
                    e.HighPriority = true;
                }
            }
        }

        private void cleardh_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                BUS.QLNHAP_BUS.xoa(dh.ID);
                BUS.QLNHAP_BUS.xoa(dh);
                loaddh();
            }
        }

        private void xemct_Click(object sender, EventArgs e)
        {
            using (var form = new XemCTDH())
            {
                dh.NCC = dsncc.Where(s=>s.ID==dh.IDNCC).FirstOrDefault();
                form.set(dh);
                form.ShowDialog();
            }
        }

        private void themdh_Click(object sender, EventArgs e)
        {
            using (var form = new ThemCTDH())
            {
                dh.NCC = dsncc.Where(s => s.ID == dh.IDNCC).FirstOrDefault();
                form.set(dsncc, dssp.Where(s=>s.TINHTRANG!=false).ToList(),nv.ID);
                form.ShowDialog();
            }
            loaddh();
        }

        private void nhap_Click(object sender, EventArgs e)
        {
            using (var form = new Thempn())
            {
                dh.NCC = dsncc.Where(s => s.ID == dh.IDNCC).FirstOrDefault();
                form.set(dh, nv.ID, dssp.Where(s => s.TINHTRANG != false).ToList());
                form.ShowDialog();                
            }
            loaddh();
            loadpn();
        }
        private void loadpn()
        {
            gridControl3.DataSource = BUS.QLNHAP_BUS.loadpn();
        }

        private void rfpn_Click(object sender, EventArgs e)
        {
            loadpn();
        }
                
        private void gridView3_RowClick(object sender, RowClickEventArgs e)
        {
            pn.ID = int.Parse(gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "ID").ToString());
            pn.NGAY = DateTime.Parse(gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "NGAY").ToString());
            pn.IDNCC = int.Parse(gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "IDNCC").ToString());
            pn.IDNV = int.Parse(gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "IDNV").ToString());
            pn.GHICHU = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "GHICHU").ToString();            
        }

        private void ctpn_Click(object sender, EventArgs e)
        {
            try
            {
                using (var form = new Xempn())
                {
                    pn.NCC = dsncc.Where(s => s.ID == pn.IDNCC).FirstOrDefault();
                   
                    form.set(pn,pn.NCC.TENNCC);
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gặp lỗi!\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void loadyc()
        {
            gridControl4.DataSource = BUS.QLXUAT_BUS.loadyc();
            gridView4.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(gridView4_RowStyle);
        }

        private void rfyc_Click(object sender, EventArgs e)
        {
            loadyc();
        }

        private void gridView4_RowClick(object sender, RowClickEventArgs e)
        {
            yc.ID = int.Parse(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "ID").ToString());
            yc.NGAY = DateTime.Parse(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "NGAY").ToString());
            yc.IDCH = int.Parse(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "IDCH").ToString());
            yc.IDNV = int.Parse(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "IDNV").ToString());
            yc.GHICHU = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "GHICHU").ToString();
            yc.TINHTRANG = Convert.ToBoolean(gridView4.GetRowCellValue(gridView3.FocusedRowHandle, "TINHTRANG").ToString());
            if (yc.GHICHU != "Đã xuất" && yc.TINHTRANG == false)
            {
                ctyc.Enabled = true;
                xuathang.Enabled = true;
                xoayc.Enabled = false;
            }
            else
            {
                ctyc.Enabled = false;
                xuathang.Enabled = false;
                xoayc.Enabled = true;
            }
        }
        private void gridView4_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                String t = View.GetRowCellDisplayText(e.RowHandle, View.Columns["GHICHU"]);
                if (t == "Đã xuất")
                {
                    e.Appearance.BackColor = Color.Gray;
                    e.Appearance.BackColor2 = Color.SeaShell;
                    e.HighPriority = true;
                }
            }
        }

        private void themyc_Click(object sender, EventArgs e)
        {
            using (var form = new ThemYCX())
            {
                yc.CUAHANG = dsch.Where(s => s.ID == yc.IDCH).FirstOrDefault();
                form.set(dsch, dssp.Where(s => s.TINHTRANG != false).ToList(), nv.ID);
                form.ShowDialog();
            }
        }

        private void xoayc_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                BUS.QLXUAT_BUS.xoa(yc.ID);
                BUS.QLXUAT_BUS.xoa(yc);
                loaddh();
            }
        }

        private void ctyc_Click(object sender, EventArgs e)
        {
            using (var form = new Xemycx())
            {
                yc.CUAHANG = dsch.Where(s => s.ID == yc.IDCH).FirstOrDefault();
                form.set(yc);
                form.ShowDialog();
            }
        }

        private void xuathang_Click(object sender, EventArgs e)
        {
            using (var form = new Thempx())
            {
                yc.CUAHANG = dsch.Where(s => s.ID == yc.IDCH).FirstOrDefault();
                form.set(yc, nv.ID,dssp.Where(s => s.TINHTRANG != false).ToList());
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    yc.TINHTRANG = true;
                    yc.GHICHU = "Đã xuất";
                    int t = BUS.QLXUAT_BUS.sua(yc);
                    if (t == 0)
                        MessageBox.Show("Gặp lỗi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            loadyc();
            loadpx();
        }
        private void loadpx()
        {
            gridControl5.DataSource = BUS.QLXUAT_BUS.loadpx();
        }

        private void rfx_Click(object sender, EventArgs e)
        {
            loadpx();
        }

        private void gridView5_RowClick(object sender, RowClickEventArgs e)
        {
            px.ID = int.Parse(gridView5.GetRowCellValue(gridView5.FocusedRowHandle, "ID").ToString());
            px.NGAY = DateTime.Parse(gridView5.GetRowCellValue(gridView5.FocusedRowHandle, "NGAY").ToString());
            px.IDCH = int.Parse(gridView5.GetRowCellValue(gridView5.FocusedRowHandle, "IDCH").ToString());
            px.IDNV = int.Parse(gridView5.GetRowCellValue(gridView5.FocusedRowHandle, "IDNV").ToString());
            px.GHICHU = gridView5.GetRowCellValue(gridView5.FocusedRowHandle, "GHICHU").ToString();
            px.PHANTRAMLOI = float.Parse(gridView5.GetRowCellValue(gridView5.FocusedRowHandle, "PHANTRAMLOI").ToString());
            px.KHUYENMAI = float.Parse(gridView5.GetRowCellValue(gridView5.FocusedRowHandle, "KHUYENMAI").ToString());
            ctxuat.Enabled = true;
        }

        private void ctxuat_Click(object sender, EventArgs e)
        {
            try
            {
                using (var form = new Xempx())
                {
                    px.CUAHANG = dsch.Where(s => s.ID == yc.IDCH).FirstOrDefault();
                    form.set(px);
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gặp lỗi!\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void loadthu()
        {
            gridControl6.DataSource = BUS.QLTHUCHI_BUS.loadthu();
        }

        private void rfthu_Click(object sender, EventArgs e)
        {
            loadthu();
        }

        private void gridView6_RowClick(object sender, RowClickEventArgs e)
        {
            pt.ID = int.Parse(gridView6.GetRowCellValue(gridView6.FocusedRowHandle, "ID").ToString());
            pt.NGAY = DateTime.Parse(gridView6.GetRowCellValue(gridView6.FocusedRowHandle, "NGAY").ToString());
            pt.IDCH = int.Parse(gridView6.GetRowCellValue(gridView6.FocusedRowHandle, "IDCH").ToString());
            pt.TIEN = int.Parse(gridView6.GetRowCellValue(gridView6.FocusedRowHandle, "TIEN").ToString());
            pt.NOIDUNG = gridView6.GetRowCellValue(gridView6.FocusedRowHandle, "NOIDUNG").ToString();
            dateTimePicker1.Value = pt.NGAY;
            comboBox1.SelectedValue = pt.IDCH;
            textBox15.Text = pt.TIEN.ToString();
            richTextBox3.Text = pt.NOIDUNG;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today;
            textBox15.Text = "";
            richTextBox3.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            pt.NGAY = dateTimePicker1.Value.Date;
            pt.IDCH = int.Parse(comboBox1.SelectedValue.ToString());
            pt.TIEN = int.Parse(textBox15.Text);
            pt.NOIDUNG = richTextBox3.Text;
            int t = BUS.QLTHUCHI_BUS.them(pt);
            if (t == 0)
                MessageBox.Show("Gặp lỗi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                loadthu();
        }

        private void loadchi()
        {
            gridControl7.DataSource = BUS.QLTHUCHI_BUS.loadchi();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            loadchi();
        }

        private void gridView7_RowClick(object sender, RowClickEventArgs e)
        {
            pc.ID = int.Parse(gridView7.GetRowCellValue(gridView7.FocusedRowHandle, "ID").ToString());
            pc.NGAY = DateTime.Parse(gridView7.GetRowCellValue(gridView7.FocusedRowHandle, "NGAY").ToString());
            pc.IDNCC = int.Parse(gridView7.GetRowCellValue(gridView7.FocusedRowHandle, "IDNCC").ToString());
            pc.TIEN = int.Parse(gridView7.GetRowCellValue(gridView7.FocusedRowHandle, "TIEN").ToString());
            pc.NOIDUNG = gridView7.GetRowCellValue(gridView7.FocusedRowHandle, "NOIDUNG").ToString();
            dateTimePicker2.Value = pc.NGAY;
            comboBox2.SelectedValue = pc.IDNCC;
            textBox13.Text = pc.TIEN.ToString();
            richTextBox4.Text = pc.NOIDUNG;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dateTimePicker2.Value = DateTime.Today;
            textBox13.Text = "";
            richTextBox4.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            pc.NGAY = dateTimePicker2.Value.Date;
            pc.IDNCC = int.Parse(comboBox2.SelectedValue.ToString());
            pc.TIEN = int.Parse(textBox13.Text);
            pc.NOIDUNG = richTextBox4.Text;
            int t = BUS.QLTHUCHI_BUS.them(pc);
            if (t == 0)
                MessageBox.Show("Gặp lỗi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                loadchi();
        }
        private void loadnv()
        {
            gridControl8.DataSource = BUS.QLTK_BUS.load();
            gridView8.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(gridView8_RowStyle);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            loadnv();
        }

        private void gridView8_RowClick(object sender, RowClickEventArgs e)
        {
            nvtemp.ID = int.Parse(gridView8.GetRowCellValue(gridView8.FocusedRowHandle, "ID").ToString());
            nvtemp.HO = gridView8.GetRowCellValue(gridView8.FocusedRowHandle, "HO").ToString();
            nvtemp.TEN = gridView8.GetRowCellValue(gridView8.FocusedRowHandle, "TEN").ToString();
            nvtemp.CMND = gridView8.GetRowCellValue(gridView8.FocusedRowHandle, "CMND").ToString();
            nvtemp.DT = gridView8.GetRowCellValue(gridView8.FocusedRowHandle, "DT").ToString();
            nvtemp.LOAI = gridView8.GetRowCellValue(gridView8.FocusedRowHandle, "LOAI").ToString();
            nvtemp.USERNAME = gridView8.GetRowCellValue(gridView8.FocusedRowHandle, "USERNAME").ToString();
            nvtemp.PASSWORD = gridView8.GetRowCellValue(gridView8.FocusedRowHandle, "PASSWORD").ToString();
            nvtemp.GHICHU = gridView8.GetRowCellValue(gridView8.FocusedRowHandle, "GHICHU").ToString();
            nvtemp.TINHTRANG = Convert.ToBoolean(gridView8.GetRowCellValue(gridView8.FocusedRowHandle, "TINHTRANG").ToString());
            button18.Enabled = true;
            button17.Enabled = true;
            textBox12.Text = nvtemp.ID.ToString();
            textBox11.Text = nvtemp.HO;
            textBox25.Text = nvtemp.TEN;
            textBox10.Text = nvtemp.CMND;
            textBox9.Text = nvtemp.DT;
            if (nvtemp.LOAI == "admin")
                comboBox3.SelectedIndex = 0;
            else
                comboBox3.SelectedIndex = 1;
            textBox8.Text = nvtemp.USERNAME;
            textBox7.Text = nvtemp.PASSWORD;
            richTextBox2.Text = nvtemp.GHICHU;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox12.Text = "";
            textBox11.Text = "";
            textBox25.Text = "";
            textBox10.Text = "";
            textBox9.Text = "";
            textBox8.Text = "";
            textBox7.Text = "";
            richTextBox2.Text = "";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            nvtemp.HO = textBox11.Text;
            nvtemp.TEN = textBox25.Text;
            nvtemp.CMND = textBox10.Text;
            nvtemp.DT = textBox9.Text;
            nvtemp.LOAI = comboBox3.SelectedText;
            nvtemp.USERNAME = textBox8.Text;
            nvtemp.PASSWORD = textBox7.Text;
            nvtemp.GHICHU = richTextBox2.Text;
            nvtemp.TINHTRANG = true;
            int t = BUS.QLTK_BUS.them(nvtemp);
            if (t == 0)
                MessageBox.Show("Gặp lỗi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                loadnv();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            nvtemp.ID = int.Parse(textBox12.Text);
            nvtemp.HO = textBox11.Text;
            nvtemp.TEN = textBox25.Text;
            nvtemp.CMND = textBox10.Text;
            nvtemp.DT = textBox9.Text;
            if (comboBox3.SelectedIndex == 0)
                nvtemp.LOAI = "admin";
            else
                nvtemp.LOAI = "user";
            nvtemp.USERNAME = textBox8.Text;
            nvtemp.PASSWORD = textBox7.Text;
            nvtemp.GHICHU = richTextBox2.Text;
            int t = BUS.QLTK_BUS.sua(nvtemp);
            if (t == 0)
                MessageBox.Show("Gặp lỗi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                loadnv();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (richTextBox2.Text == "")
                MessageBox.Show("Phải điền lý do", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            else if(comboBox3.SelectedIndex==0)
                MessageBox.Show("Không khoá admin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    nvtemp.ID = int.Parse(textBox12.Text);
                    nvtemp.HO = textBox11.Text;
                    nvtemp.TEN = textBox25.Text;
                    nvtemp.CMND = textBox10.Text;
                    nvtemp.DT = textBox9.Text;
                    nvtemp.LOAI = comboBox3.SelectedText;
                    nvtemp.USERNAME = textBox8.Text;
                    nvtemp.PASSWORD = textBox7.Text;
                    nvtemp.GHICHU = richTextBox2.Text;
                    if (nvtemp.TINHTRANG == true)
                        nvtemp.TINHTRANG = false;
                    else
                    {
                        nvtemp.TINHTRANG = true;
                        nvtemp.GHICHU = "";
                    }                        
                    int t = BUS.QLTK_BUS.sua(nvtemp);
                    if (t == 0)
                        MessageBox.Show("Gặp lỗi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        loadnv();
                }
            }
        }
        private void gridView8_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                String t = View.GetRowCellDisplayText(e.RowHandle, View.Columns["TINHTRANG"].ToString());
                
                if (t == "False")
                {
                    e.Appearance.BackColor = Color.Gray;
                    e.Appearance.BackColor2 = Color.SeaShell;
                    e.HighPriority = true;
                }
            }
        }
    }
}
