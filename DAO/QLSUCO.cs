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
    class QLSUCO
    {
        private KHODMEntities db = new KHODMEntities();
        //dathang
        public List<SUCO> load(SUCO sc)
        {
            return db.SUCOes.OrderByDescending(s => s.NGAY).ToList();
        }
        public void them(SUCO sc)
        {
            db.SUCOes.Add(sc);
            db.SaveChanges();
        }
        public void sua(SUCO sc)
        {
            db.Entry(sc).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void xoa(SUCO sc)
        {
            db.SUCOes.Remove(sc);
            db.SaveChanges();
        }
        public List<CTSUCO> load(int id)
        {
            return db.CTSUCOes.Include(s => s.SANPHAM.TENSP).Where(s => s.ID == id).ToList();
        }
        public void them(CTSUCO sc)
        {
            db.CTSUCOes.Add(sc);
            db.SaveChanges();
        }
        public void sua(CTSUCO sc)
        {
            db.Entry(sc).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void xoa(CTSUCO sc)
        {
            db.CTSUCOes.Remove(sc);
            db.SaveChanges();
        }

        
      
    }
}
