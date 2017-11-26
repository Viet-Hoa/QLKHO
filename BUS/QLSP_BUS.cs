using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class QLSP_BUS
    {
        public static List<SANPHAM> load()
        {
            return DAO.QLSP.load();
        }
        public static int them(SANPHAM sp)
        {
            try
            {
                sp.SL = 0;
                DAO.QLSP.them(sp);
                return 1;//them thanh cong
            }
            catch(Exception ex)
            {
                return 0;//gap loi
            }
        }
        public static int sua(SANPHAM sp)
        {
            try
            {
                DAO.QLSP.sua(sp);
                return 1;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }
    }
}
