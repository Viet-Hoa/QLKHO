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
    class QLTHUCHI
    {
        private KHODMEntities db = new KHODMEntities();
        //PHIEUTHU
        public List<PHIEUTHU> load(PHIEUTHU pt)
        {
            return db.PHIEUTHUs.Include(s => s.CUAHANG.TENCH).OrderByDescending(s => s.NGAY).ToList();
        }
        public void them(PHIEUTHU pt)
        {
            db.PHIEUTHUs.Add(pt);
            db.SaveChanges();
        }
        public void xoa(PHIEUTHU pt)
        {
            db.PHIEUTHUs.Remove(pt);
            db.SaveChanges();
        }
        //chi
        public List<PHIEUCHI> load(PHIEUCHI pc)
        {
            return db.PHIEUCHIs.Include(s => s.NCC.TENNCC).OrderByDescending(s => s.NGAY).ToList();
        }
        public void them(PHIEUCHI pc)
        {
            db.PHIEUCHIs.Add(pc);
            db.SaveChanges();
        }
        public void xoa(PHIEUCHI pc)
        {
            db.PHIEUCHIs.Remove(pc);
            db.SaveChanges();
        }
    }
}
        
        