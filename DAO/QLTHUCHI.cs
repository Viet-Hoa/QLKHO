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
    public class QLTHUCHI
    {
        private static KHODMEntities db = new KHODMEntities();
        //PHIEUTHU
        public static List<PHIEUTHU> load(PHIEUTHU pt)
        {
            return db.PHIEUTHUs.Include(s => s.CUAHANG.TENCH).OrderByDescending(s => s.NGAY).ToList();
        }
        public static void them(PHIEUTHU pt)
        {
            db.PHIEUTHUs.Add(pt);
            db.SaveChanges();
        }
        public static void xoa(PHIEUTHU pt)
        {
            db.PHIEUTHUs.Remove(pt);
            db.SaveChanges();
        }
        //chi
        public static List<PHIEUCHI> load(PHIEUCHI pc)
        {
            return db.PHIEUCHIs.Include(s => s.NCC.TENNCC).OrderByDescending(s => s.NGAY).ToList();
        }
        public static void them(PHIEUCHI pc)
        {
            db.PHIEUCHIs.Add(pc);
            db.SaveChanges();
        }
        public static void xoa(PHIEUCHI pc)
        {
            db.PHIEUCHIs.Remove(pc);
            db.SaveChanges();
        }
    }
}
        
        