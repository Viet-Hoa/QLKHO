using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BUS
{
    public class QLTONK_BUS
    {
        public static List<TONKHO> load()
        {
            return DAO.QLTONK.load();
        }
        public static int them(TONKHO tk)
        {
            try
            {
                DAO.QLTONK.them(tk);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public static List<CTTK> load(int id)
        {
            return DAO.QLTONK.load(id);
        }
        public static int them(CTTK tk)
        {
            try
            {
                DAO.QLTONK.them(tk);
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
