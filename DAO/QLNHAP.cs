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
    public class QLNHAP
    {
        private static KHODMEntities db = new KHODMEntities();
        //dathang
        public static List<DONDATHANG> loaddh()
        {
            return db.DONDATHANGs.Include(s => s.NCC).Include(s=>s.NHANVIEN).OrderByDescending(s => s.NGAY).ToList();
        }
        public static void them(DONDATHANG dh)
        {
            db.DONDATHANGs.Add(dh);
            db.SaveChanges();
        }
        public static void sua(DONDATHANG dh)
        {
            var v = db.DONDATHANGs.Find(dh.ID);
            db.Entry(v).CurrentValues.SetValues(dh);
            db.SaveChanges();
        }
        public static void xoa(DONDATHANG dh)
        {
            var x = db.DONDATHANGs.Find(dh.ID);
            db.DONDATHANGs.Remove(x);
            db.SaveChanges();
        }
        public static void xoa()
        {
            var dh = db.DONDATHANGs.LastOrDefault();
            db.DONDATHANGs.Remove(dh);
            db.SaveChanges();
        }
        public static List<CTDH> loaddh(int id)
        {
            return db.CTDHs.Include(s => s.SANPHAM).Where(s => s.ID == id).ToList();
        }
        public static void them(CTDH dh)
        {
            var x = db.DONDATHANGs.AsNoTracking().OrderByDescending(s => s.ID).FirstOrDefault();
            dh.ID = x.ID;
            dh.SANPHAM = null;
            db.CTDHs.Add(dh);
            db.SaveChanges();
        }
        public static void sua(CTDH dh)
        {
            db.Entry(dh).State = EntityState.Modified;
            db.SaveChanges();
        }
        public static void xoa(int id)
        {
            var ct = db.CTDHs.Where(s => s.ID == id).ToList();
            foreach (var dh in ct)
            {
                db.CTDHs.Remove(dh);
                db.SaveChanges();
            }         
        }

        //nhap
        public static List<PHIEUNHAP> loadpn()
        {
            return db.PHIEUNHAPs.Include(s => s.NCC).OrderByDescending(s => s.NGAY).ToList();
        }
        public static void them(PHIEUNHAP pn)
        {
            db.PHIEUNHAPs.Add(pn);
            db.SaveChanges();
        }
        public static List<CTPN> loadpn(int id)
        {
            return db.CTPNs.Include(s => s.SANPHAM).Where(s => s.ID == id).ToList();
        }
        public static void them(CTPN pn)
        {
            var x = db.PHIEUNHAPs.AsNoTracking().OrderByDescending(s => s.ID).FirstOrDefault();
            pn.ID = x.ID;
            pn.SANPHAM = null;
            db.CTPNs.Add(pn);
            db.SaveChanges();
        }
      
    }
}
