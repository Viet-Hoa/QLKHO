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
        public static List<NCC> load()
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
        public static void tangno(PHIEUNHAP pn)
        {
            var ncc = db.NCCs.Find(pn.IDNCC);
            int t = 0;
            foreach(CTPN ct in pn.CTPNs)
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
        public static List<CUAHANG> load()
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
        public static void tangno(PHIEUXUAT px)
        {
            var ncc = db.NCCs.Find(px.IDCH);
            int t = 0;
            foreach (CTPX ct in px.CTPXes)
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
