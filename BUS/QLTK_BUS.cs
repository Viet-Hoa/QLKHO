using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BUS
{
     public class QLTK_BUS
    {
        public static int idnv = DAO.QLTK.manv;
        public static List<NHANVIEN> load()
        {
            return DAO.QLTK.load();
        }
        public static int them(NHANVIEN nv)
        {
            try
            {
                DAO.QLTK.them(nv);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static int sua(NHANVIEN nv)
        {
            try
            {
                DAO.QLTK.sua(nv);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
