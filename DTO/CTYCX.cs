//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class CTYCX
    {
        public int ID { get; set; }
        public int IDSP { get; set; }
        public int SL { get; set; }
        public string GHICHU { get; set; }
    
        public virtual YCXUAT YCXUAT { get; set; }
        public virtual SANPHAM SANPHAM { get; set; }
    }
}
