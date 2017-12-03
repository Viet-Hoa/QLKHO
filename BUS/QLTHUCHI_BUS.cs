using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace BUS
{
    class QLTHUCHI_BUS
    {
        public static List<PHIEUTHU> load()
        {
            return DAO.QLTHUCHI.loadthu();
        }
        public static int them(PHIEUTHU pt)
        {
            try
            {
                DAO.QLTHUCHI.them(pt);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static void xoa(PHIEUTHU pt)
        {
            DAO.QLTHUCHI.xoa(pt);
        }

        public static List<PHIEUCHI> loadchi()
        {
            return DAO.QLTHUCHI.loadchi();
        }
        public static int them(PHIEUCHI pc)
        {
            try
            {
                DAO.QLTHUCHI.them(pc);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static void xoa(PHIEUCHI pc)
        {
            DAO.QLTHUCHI.xoa(pc);
        }
    }
}
