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
    public class THONGKE
    {
        private static KHODMEntities db = new KHODMEntities();
        //tonkho
        public static List<TONKHO> load()
        {
            return db.TONKHOes.OrderByDescending(s => s.NGAY).ToList();
        }
        public static void them(TONKHO tk)
        {
            db.TONKHOes.Add(tk);
            db.SaveChanges();
        }
        public static List<CTTK> load(int id)
        {
            return db.CTTKs.Include(s => s.SANPHAM.TENSP).Where(s => s.ID == id).ToList();
        }
        //thu chi
        public static List<PHIEUTHU> loadthu(DateTime tu, DateTime den)
        {
            return db.PHIEUTHUs.Where(s => s.NGAY >= tu && s.NGAY <= den).ToList();
        }
        public static List<PHIEUCHI> loadchi(DateTime tu, DateTime den)
        {
            return db.PHIEUCHIs.Where(s => s.NGAY >= tu && s.NGAY <= den).ToList();
        }
        public static List<SANPHAM> loadbanchay(DateTime tu, DateTime den)
        { 
            var x = db.PHIEUXUATs.Where(s => s.NGAY >= tu && s.NGAY <= den).ToList();
            var sp=db.SANPHAMs.Where(s=>s.TINHTRANG == true).ToList();
            foreach(var u in sp)
            {
                u.SL = 0;
            }
            foreach(PHIEUXUAT px in x)
            {
                foreach(CTPX ct in px.CTPXes)
                {
                    foreach(var u in sp)
                    {
                        if (ct.IDSP == u.ID)
                        {
                            u.SL += ct.SL;
                            break;
                        }
                    }
                }
            }
            return sp.OrderByDescending(s=>s.SL).ToList();
        }
    }
}
