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
    class QLTK
    {
        private KHODMEntities db = new KHODMEntities();
        public List<NHANVIEN> load()
        {
            return db.NHANVIENs.ToList();
        }
        public void them(NHANVIEN nv)
        {
            db.NHANVIENs.Add(nv);
            db.SaveChanges();
        }
        public void sua(NHANVIEN nv)
        {
            db.Entry(nv).State = EntityState.Modified;
            db.SaveChanges();
        }
        public int dangnhap(String uname, String pas)
        {
            var nv = db.NHANVIENs.Where(s => s.USERNAME == uname && s.PASSWORD == pas).FirstOrDefault();
            if (nv == null)
                return 0;//nhap sai
            if (nv.TINHTRANG == false)
                return 3;//tai khoan bi khoa
            if (nv.LOAI == "admin")
                return 1; //nv la admin
            return 2;//nv la user
        }
    }
}
