using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace BUS
{
    public class QLTHUCHI_BUS
    {
        //thu
        public static List<PHIEUTHU> loadthu()
        {
            return DAO.QLTHUCHI.loadthu();
        }
        public static int them(PHIEUTHU pt)
        {
            try
            {
                DAO.QLTHUCHI.them(pt);
                DAO.QLDOITAC.giamno(pt);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public static void xoa(PHIEUTHU pt)
        {
            DAO.QLTHUCHI.xoa(pt);
        }
        //chi
        public static List<PHIEUCHI> loadchi()
        {
            return DAO.QLTHUCHI.loadchi();
        }
        public static int them(PHIEUCHI pc)
        {
            try
            {
                DAO.QLTHUCHI.them(pc);
                DAO.QLDOITAC.giamno(pc);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public static void xoa(PHIEUCHI pc)
        {
            DAO.QLTHUCHI.xoa(pc);
        }
    }
}
