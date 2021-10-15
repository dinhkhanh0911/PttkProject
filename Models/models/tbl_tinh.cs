using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PttkProject.models
{
    public class tbl_tinh
    {
        public int ID { get; set; }
        public string tenTinh { get; set; }
        public string moTa { get; set; }
        public virtual ICollection<tbl_huyen> Huyen { get; set; }
        public virtual ICollection<tbl_diaChi> diaChi { get; set; }

    }
}