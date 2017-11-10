using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    class THONGKE
    {
        private KHODMEntities db = new KHODMEntities();
        //tonkho
        public List<TONKHO> load()
        {
            return db.TONKHOes.OrderByDescending(s => s.NGAY).ToList();
        }
        public void them(TONKHO tk)
        {
            db.TONKHOes.Add(tk);
            db.SaveChanges();
        }
        public List<CTTK> load(int id)
        {
            return db.CTTKs.Include(s => s.SANPHAM.TENSP).Where(s => s.ID == id).ToList();
        }
        //thu chi
        public List<PHIEUTHU> loadthu(DateTime tu, DateTime den)
        {
            return db.PHIEUTHUs.Where(s => s.NGAY >= tu && s.NGAY <= den).ToList();
        }
        public List<PHIEUCHI> loadchi(DateTime tu, DateTime den)
        {
            return db.PHIEUCHIs.Where(s => s.NGAY >= tu && s.NGAY <= den).ToList();
        }
        public List<CTPX> loadbanchay(DateTime tu, DateTime den)
        {
            List<CTPX> kq=new List<CTPX>();  
            var x = db.PHIEUXUATs.Where(s => s.NGAY >= tu && s.NGAY <= den).ToList();
            var sp=db.SANPHAMs.ToList();
            for(int i=0; i<sp.Count;i++)
            {
                CTPX ct = new CTPX();
                ct.ID = i;
                ct.IDSP = sp[i].ID;
                ct.SL = 0;
                ct.GHICHU = " ";
                kq.Add(ct);
            }
            kq=kq.Join(sp, CTPX => CTPX.IDSP, SANPHAM => SANPHAM.ID, (CTPX, SANPHAM) => new CTPX { ID = CTPX.ID, IDSP = CTPX.IDSP, SL = CTPX.SL, SANPHAM = SANPHAM }).ToList();            
            foreach(PHIEUXUAT px in x)
            {
                foreach(CTPX ct in px.CTPXes)
                {
                    foreach(CTPX ctkq in kq)
                    {
                        if (ct.IDSP == ctkq.IDSP)
                        {
                            ctkq.SL += ct.SL;
                            break;
                        }
                    }
                }
            }
            return kq;
        }
    }
}
