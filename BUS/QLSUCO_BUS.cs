using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class QLSUCO_BUS
    {
        public static List<SUCO> load(SUCO sc)
        {
            return DAO.QLSUCO.load(sc);
        }
        public static int them(SUCO sc)
        {
            try
            {
                DAO.QLSUCO.them(sc);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static int sua(SUCO sc)
        {
            try
            {
                DAO.QLSUCO.sua(sc);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static void xoa(SUCO sc)
        {
            DAO.QLSUCO.xoa(sc);
        }

        public static List<CTSUCO> load(int id)
        {
            return DAO.QLSUCO.load(id);
        }
        public static int them(List<CTSUCO> ct)
        {
            try
            {
                foreach (var sc in ct)
                {
                    DAO.QLSUCO.them(sc);
                }
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static void xoa(int id)
        {
            DAO.QLSUCO.xoa(id);
        }
    }
}
