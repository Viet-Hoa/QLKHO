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
    public class QLSUCO
    {
        private static KHODMEntities db = new KHODMEntities();
        //dathang
        public static List<SUCO> load(SUCO sc)
        {
            return db.SUCOes.OrderByDescending(s => s.NGAY).ToList();
        }
        public static void them(SUCO sc)
        {
            db.SUCOes.Add(sc);
            db.SaveChanges();
        }
        public static void sua(SUCO sc)
        {
            db.Entry(sc).State = EntityState.Modified;
            db.SaveChanges();
        }
        public static void xoa(SUCO sc)
        {
            db.SUCOes.Remove(sc);
            db.SaveChanges();
        }
        public static List<CTSUCO> load(int id)
        {
            return db.CTSUCOes.Include(s => s.SANPHAM.TENSP).Where(s => s.ID == id).ToList();
        }
        public static void them(CTSUCO sc)
        {
            sc.ID = db.SUCOes.Select(s => s.ID).LastOrDefault();
            db.CTSUCOes.Add(sc);
            db.SaveChanges();
        }
        public static void sua(CTSUCO sc)
        {
            db.Entry(sc).State = EntityState.Modified;
            db.SaveChanges();
        }
        public static void xoa(int id)
        {
            var ct = db.CTSUCOes.Where(s => s.ID == id).ToList();
            foreach (var sc in ct)
            {
                db.CTSUCOes.Remove(sc);
                db.SaveChanges();
            }             
        }

        
      
    }
}
