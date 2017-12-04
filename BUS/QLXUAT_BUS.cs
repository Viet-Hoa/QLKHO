using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BUS
{
    public class QLXUAT_BUS
    {
        public static List<YCXUAT> loadyc()
        {
            return DAO.QLXUAT.loadyc();
        }
        public static int them(YCXUAT yc)
        {
            try
            {
                DAO.QLXUAT.them(yc);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static int sua(YCXUAT yc)
        {
            try
            {
                DAO.QLXUAT.sua(yc);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static void xoa(YCXUAT yc)
        {
            DAO.QLXUAT.xoa(yc);
        }

        public static List<CTYCX> loadyc(int id)
        {
            return DAO.QLXUAT.loadyc(id);
        }
        public static int them(List<CTYCX> yc)
        {
            try
            {
                foreach(var ct in yc)
                    DAO.QLXUAT.them(ct);
                return 1;
            }
            catch 
            {
                return 0;
            }
        }
        public static int sua(CTYCX yc)
        {
            try
            {
                DAO.QLXUAT.sua(yc);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static List<PHIEUXUAT> loadpx()
        {
            return DAO.QLXUAT.loadpx();
        }
        public static int them(PHIEUXUAT px)
        {
            try
            {
                DAO.QLXUAT.them(px);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        
        public static List<CTPX> loadpx(int id)
        {
            return DAO.QLXUAT.loadpx(id);
        }
        public static int them(List<CTPX> px)
        {
            try
            {
                foreach (var ct in px)
                {
                    DAO.QLXUAT.them(ct);
                    DAO.QLSP.giamsl(ct.IDSP, ct.SL);
                }                    
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public static int tangno(int id)
        {
            try
            {
                DAO.QLDOITAC.tangnoch(id);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

    }
}
