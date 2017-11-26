using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
namespace BUS
{
    public class QLNHAP_BUS
    {
        //dathang
        public static List<DONDATHANG> loaddh()
        {
            return DAO.QLNHAP.loaddh();
        }
        public static int them(DONDATHANG dh)
        {
            try
            {
                DAO.QLNHAP.them(dh);
                return 1;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }
        public static int sua(DONDATHANG dh)
        {
            try
            {
                DAO.QLNHAP.sua(dh);
                return 1;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }
        public static void xoa(DONDATHANG dh)
        {
            DAO.QLNHAP.xoa(dh);
        }
        //ctdh
        public static List<CTDH> loaddh(int id)
        {
            return DAO.QLNHAP.loaddh(id);
        }
        public static int them(List<CTDH> ct)
        {
            try
            {
                foreach (var x in ct)
                    DAO.QLNHAP.them(x);
                return 1;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }
        public static int sua(CTDH ct)
        {
            try
            {
                DAO.QLNHAP.sua(ct);
                return 1;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }
        public void xoa(int id)
        {
            DAO.QLNHAP.xoa(id);
        }
        //phieunhap
        public static List<PHIEUNHAP> loadpn()
        {
            return DAO.QLNHAP.loadpn();
        }
        public static int them(PHIEUNHAP pn)
        {
            try{
                DAO.QLNHAP.them(pn);
                return 1;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }
        //ctpn
        public static List<CTPN> loadpn(int id)
        {
            return DAO.QLNHAP.loadpn(id);
        }
        public static int them(List<CTPN> ct)
        {
            try
            {
                foreach (var pn in ct)
                {
                    DAO.QLNHAP.them(pn);
                    DAO.QLSP.tangsl(pn.IDSP, pn.SL);
                    DAO.QLSP.giabq(pn.IDSP, pn.SL, pn.DONGIA);
                }                   
                return 1;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }
    }
}
