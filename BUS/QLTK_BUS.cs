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
                Console.WriteLine(ex.Message);
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
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public static int login(String u, String p)
        {
            return DAO.QLTK.dangnhap(u, p);            
        }
        public static NHANVIEN manv()
        {
            return DAO.QLTK.manv();
        }
    }
}
