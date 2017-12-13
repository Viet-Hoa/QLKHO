using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BUS
{
    public class THONGKE_BUS
    {
        //tonkho
        private static List<PHIEUTHU> pt = new List<PHIEUTHU>();
        private static List<PHIEUCHI> pc = new List<PHIEUCHI>();
        public static List<TONKHO> load()
        {
            return DAO.THONGKE.load();
        }
        public static List<CTTK> load(int id)
        {
            return DAO.THONGKE.load(id);
        }
        //thuchi
        public static List<PHIEUTHU> loadthu(DateTime tu, DateTime den)
        {
            pt = DAO.THONGKE.loadthu(tu, den);
            return pt;
        }
        public static int tongthu()
        {
            int t = 0;
            foreach(var p in pt)
            {
                t += p.TIEN;
            }
            return t;
        }
        public static List<PHIEUCHI> loadchi(DateTime tu, DateTime den)
        {
            pc = DAO.THONGKE.loadchi(tu, den);
            return pc;
        }
        public static int tongchi()
        {
            int t = 0;
            foreach (var p in pc)
            {
                t += p.TIEN;
            }
            return t;
        }
        public static List<SANPHAM> loadbanchay(DateTime tu, DateTime den)
        {
            return DAO.THONGKE.loadbanchay(tu, den);
        }

    }
}
