using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class QLTK
    {
        private static KHODMEntities db = new KHODMEntities();
        public static NHANVIEN ma;
        public static List<NHANVIEN> load()
        {
            return db.NHANVIENs.ToList();
        }
        public static void them(NHANVIEN nv)
        {
            db.NHANVIENs.Add(nv);
            db.SaveChanges();
        }
        public static void sua(NHANVIEN nv)
        {
            var v = db.NHANVIENs.Find(nv.ID);
            db.Entry(v).CurrentValues.SetValues(nv);
            db.SaveChanges();
        }
        public static int dangnhap(String uname, String pas)
        {
            var nv = db.NHANVIENs.Where(s => s.USERNAME.Equals(uname) && s.PASSWORD.Equals(pas)).FirstOrDefault();
            if(nv!=null)
            {
                ma = nv;
                if (nv.TINHTRANG == false)
                    return 3;//tai khoan bi khoa
                if (nv.LOAI == "admin")
                    return 1; //nv la admin
                else
                    return 2;//nv la user
            }
            return 0;//nhap sai
        }
        public static NHANVIEN manv()
        {
            return ma;
        }
    }
}
