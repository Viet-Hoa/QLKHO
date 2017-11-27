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
    public class QLXUAT
    {
        private static KHODMEntities db = new KHODMEntities();
        //ycxuat
        public static List<YCXUAT> loadyc()
        {
            return db.YCXUATs.Include(s => s.CUAHANG.TENCH).OrderByDescending(s => s.NGAY).ToList();
        }
        public static void them(YCXUAT yc)
        {
            db.YCXUATs.Add(yc);
            db.SaveChanges();
        }
        public static void sua(YCXUAT yc)
        {
            db.Entry(yc).State = EntityState.Modified;
            db.SaveChanges();
        }
        public static void xoa(YCXUAT yc)
        {
            db.YCXUATs.Remove(yc);
            db.SaveChanges();
        }
        public static List<CTYCX> loadyc(int id)
        {
            return db.CTYCXes.Include(s => s.SANPHAM.TENSP).Where(s => s.ID == id).ToList();
        }
        public static void them(CTYCX yc)
        {
            yc.ID = db.YCXUATs.Select(s => s.ID).LastOrDefault();
            db.CTYCXes.Add(yc);
            db.SaveChanges();
        }
        public static void sua(CTYCX yc)
        {
            db.Entry(yc).State = EntityState.Modified;
            db.SaveChanges();
        }
        public static void xoa(int id)
        {
            var ct = db.CTYCXes.Where(s => s.ID == id).ToList();
            foreach (var yc in ct)
            {
                db.CTYCXes.Remove(yc);
                db.SaveChanges();
            }  
        }

        //xuat
        public static List<PHIEUXUAT> loadpx()
        {
            return db.PHIEUXUATs.Include(s => s.CUAHANG.TENCH).OrderByDescending(s => s.NGAY).ToList();
        }
        public static void them(PHIEUXUAT px)
        {
            db.PHIEUXUATs.Add(px);
            db.SaveChanges();
        }
        public static List<CTPX> loadpx(int id)
        {
            return db.CTPXes.Include(s => s.SANPHAM.TENSP).Where(s => s.ID == id).ToList();
        }
        public static void them(CTPX px)
        {
            px.ID = db.PHIEUXUATs.Select(s => s.ID).LastOrDefault();
            db.CTPXes.Add(px);
            db.SaveChanges();
        }
    }
}
