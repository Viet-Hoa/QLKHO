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
    public class QLDOITAC
    {
        private static KHODMEntities db = new KHODMEntities();
        //nha cung cap
        public static List<NCC> loadncc()
        {
            return db.NCCs.ToList();        
        }
        public static void them(NCC ncc)
        {
            db.NCCs.Add(ncc);
            db.SaveChanges();
        }
        public static void sua(NCC ncc)
        {
            db.Entry(ncc).State = EntityState.Modified;
            db.SaveChanges();
        }
        public static void tangnocc(int id)
        {
            var ncc = db.NCCs.Find(id);
            int t = 0;
            int idpn = db.PHIEUNHAPs.OrderByDescending(s => s.ID).FirstOrDefault().ID;
            var ctpn = db.CTPNs.Where(s => s.ID == idpn).ToList();
            foreach(CTPN ct in ctpn)
            {
                t += ct.DONGIA * ct.SL;
            }
            ncc.TIENNO += t;
            db.Entry(ncc).State = EntityState.Modified;
            db.SaveChanges();
        }
        public static void giamno(PHIEUCHI pc)
        {
            var ncc = db.NCCs.Find(pc.IDNCC);
            ncc.TIENNO -= pc.TIEN;
            db.Entry(ncc).State = EntityState.Modified;
            db.SaveChanges();
        }
        // cua hang
        public static List<CUAHANG> loadch()
        {
            return db.CUAHANGs.ToList();
        }
        public static void them(CUAHANG ch)
        {
            db.CUAHANGs.Add(ch);
            db.SaveChanges();
        }
        public static void sua(CUAHANG ch)
        {
            db.Entry(ch).State = EntityState.Modified;
            db.SaveChanges();
        }
        public static void tangnoch(int id)
        {
            var ncc = db.NCCs.Find(id);
            int t = 0;
            var px = db.PHIEUXUATs.OrderByDescending(s => s.ID).FirstOrDefault();
            var ctpx = db.CTPXes.Where(s => s.ID == px.ID).ToList();
            foreach (CTPX ct in ctpx)
            {
                int gt = ct.SL * ct.SANPHAM.DG;
                t += (int)((100 + px.PHANTRAMLOI) / 100 * gt - (px.KHUYENMAI/100 * gt));
            }
            ncc.TIENNO += t;
            db.Entry(ncc).State = EntityState.Modified;
            db.SaveChanges();
        }
        public static void giamno(PHIEUTHU pt)
        {
            var ch = db.NCCs.Find(pt.IDCH);
            ch.TIENNO -= pt.TIEN;
            db.Entry(ch).State = EntityState.Modified;
            db.SaveChanges();
        }
      
    }
}
