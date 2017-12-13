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
    public class QLSP
    {
        private static KHODMEntities db = new KHODMEntities();
        public static List<SANPHAM> load()
        {
            return db.SANPHAMs.ToList();        
        }
        public static void them(SANPHAM sp)
        {
            db.SANPHAMs.Add(sp);
            db.SaveChanges();
        }
        public static void sua(SANPHAM sp)
        {
            var v = db.SANPHAMs.Find(sp.ID);
            db.Entry(v).CurrentValues.SetValues(sp);
            db.SaveChanges();
        }
        public static void tangsl(int id, int sl)
        {
            var sp = db.SANPHAMs.Find(id);
            sp.SL += sl;
            db.Entry(sp).State = EntityState.Modified;
            db.SaveChanges();
        }
        public static void giamsl(int id, int sl)
        {
            var sp = db.SANPHAMs.Find(id);
            sp.SL -= sl;
            db.Entry(sp).State = EntityState.Modified;
            db.SaveChanges();
        }
        public static void giabq(int id, int sl, int gia)
        {
            var sp = db.SANPHAMs.Find(id);
            sp.DG = (sp.DG * sp.SL + sl * gia) / (sp.SL + sl);
            db.Entry(sp).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
