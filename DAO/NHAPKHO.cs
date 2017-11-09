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
    class NHAPKHO
    {
        private KHODMEntities db = new KHODMEntities();
        //dathang
        public List<DONDATHANG> load(DONDATHANG dh)
        {
            return db.DONDATHANGs.ToList();
        }
        public void them(DONDATHANG dh)
        {
            db.DONDATHANGs.Add(dh);
            db.SaveChanges();
        }
        public void sua(DONDATHANG dh)
        {
            db.Entry(dh).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void xoa(DONDATHANG dh)
        {
            db.DONDATHANGs.Remove(dh);
            db.SaveChanges();
        }
        public List<CTDH> load(int id)
        {
            return db.CTDHs.Where(s => s.ID == id).ToList();
        }
        public void them(CTDH dh)
        {
            db.CTDHs.Add(dh);
            db.SaveChanges();
        }
        public void sua(CTDH dh)
        {
            db.Entry(dh).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void xoa(CTDH dh)
        {
            db.CTDHs.Remove(dh);
            db.SaveChanges();
        }

        //nhap
        public List<PHIEUNHAP> load(PHIEUNHAP pn)
        {
            return db.PHIEUNHAPs.ToList();
        }
        public void them(PHIEUNHAP pn)
        {
            db.PHIEUNHAPs.Add(pn);
            db.SaveChanges();
        }
        public List<CTPN> load(int id)
        {
            return db.CTPNs.Where(s => s.ID == id).ToList();
        }
        public void them(CTPN pn)
        {
            db.CTPNs.Add(pn);
            db.SaveChanges();
        }
      
    }
}
