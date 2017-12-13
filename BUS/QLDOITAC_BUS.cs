using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class QLDOITAC_BUS
    {
        //doitac
        public static List<NCC> loadncc()
        {
            return DAO.QLDOITAC.loadncc();
        }
        public static int them(NCC ncc)
        {
            try
            {
                DAO.QLDOITAC.them(ncc);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public static int sua(NCC ncc)
        {
            try
            {
                DAO.QLDOITAC.sua(ncc);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        //cuahang
        public static List<CUAHANG> loadch()
        {
            return DAO.QLDOITAC.loadch();
        }
        public static int them(CUAHANG ch)
        {
            try
            {
                DAO.QLDOITAC.them(ch);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public static int sua(CUAHANG ch)
        {
            try
            {
                DAO.QLDOITAC.sua(ch);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

    }
}
