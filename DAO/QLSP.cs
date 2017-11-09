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
        private KHODMEntities db = new KHODMEntities();
        public List<SANPHAM> load()
        {
            return db.SANPHAMs.ToList();        
        }
        public void them(SANPHAM sp)
        {
            db.SANPHAMs.Add(sp);
            db.SaveChanges();
        }
        public void sua(SANPHAM sp)
        {
            db.Entry(sp).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void tangsl(int id, int sl)
        {
            var sp = db.SANPHAMs.Find(id);
            sp.SL += sl;
            db.Entry(sp).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void giamsl(int id, int sl)
        {
            var sp = db.SANPHAMs.Find(id);
            sp.SL -= sl;
            db.Entry(sp).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void giabq(int id, int sl, int gia)
        {
            var sp = db.SANPHAMs.Find(id);
            sp.DG = (sp.DG * sp.SL + sl + gia) / (sp.SL + sl);
            db.Entry(sp).State = EntityState.Modified;
            db.SaveChanges();
        }
        public List<SANPHAM> timkiemten(String ten)
        {
            return db.SANPHAMs.Where(s => s.TENSP.StartsWith(ten)).ToList();
        }
        public List<SANPHAM> timkiemgia(int tu, int den)
        {
            return db.SANPHAMs.Where(s => s.DG>=tu && s.DG<=den).ToList();
        }
    }
}
