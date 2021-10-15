using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PttkProject.models
{
    public class tbl_nguoiDung : tbl_nguoi
    {
        public string taiKhoan { get; set; }
        public string matKhau { get; set; }
        public int viTriLamViecID { get; set; }
        [ForeignKey("viTriLamViecID")]
        public virtual tbl_viTriLamViec viTriLamViec {get;set;}
    }
}