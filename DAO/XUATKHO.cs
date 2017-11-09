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
    class XUATKHO
    {
        private KHODMEntities db = new KHODMEntities();
        //ycxuat
        public List<YCXUAT> load(YCXUAT ycC)
        {
            return db.YCXUATs.ToList();
        }
        public void them(YCXUAT yc)
        {
            db.YCXUATs.Add(yc);
            db.SaveChanges();
        }
        public void sua(YCXUAT yc)
        {
            db.Entry(yc).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void xoa(YCXUAT yc)
        {
            db.YCXUATs.Remove(yc);
            db.SaveChanges();
        }
        public List<CTYCX> load(int id)
        {
            return db.CTYCXes.Where(s => s.ID == id).ToList();
        }
        public void them(CTYCX yc)
        {
            db.CTYCXes.Add(yc);
            db.SaveChanges();
        }
        public void sua(CTYCX yc)
        {
            db.Entry(yc).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void xoa(CTYCX yc)
        {
            db.CTYCXes.Remove(yc);
            db.SaveChanges();
        }

        //xuat
        public List<PHIEUXUAT> load(PHIEUXUAT px)
        {
            return db.PHIEUXUATs.ToList();
        }
        public void them(PHIEUXUAT px)
        {
            db.PHIEUXUATs.Add(px);
            db.SaveChanges();
        }
        public List<CTPX> load(int id)
        {
            return db.CTPXes.Where(s => s.ID == id).ToList();
        }
        public void them(CTPX px)
        {
            db.CTPXes.Add(px);
            db.SaveChanges();
        }
    }
}
