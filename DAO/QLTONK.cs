using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAO
{
    public class QLTONK
    {
        private static KHODMEntities db = new KHODMEntities();
        //tonkho
        public static List<TONKHO> load()
        {
            return db.TONKHOes.OrderByDescending(s => s.NGAY).ToList();
        }
        public static void them(TONKHO tk)
        {
            db.TONKHOes.Add(tk);
            db.SaveChanges();
        }
        //cttonkho
        public static List<CTTK> load(int id)
        {
            return db.CTTKs.Where(s => s.ID == id).ToList();
        }
        public static void them(CTTK tk)
        {
            tk.ID = db.TONKHOes.Select(s => s.ID).LastOrDefault();
            db.CTTKs.Add(tk);
            db.SaveChanges();
        }
    }
}
