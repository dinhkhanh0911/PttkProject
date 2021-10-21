using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CovidModels.models
{
    public class tbl_viTriLamViec
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string tenViTri { get; set; }
        public string moTa { get; set; }
        public virtual ICollection<tbl_nhanVienYTe> NhanVIenYTe { get; set; }
        public virtual ICollection<tbl_nguoiDung> NguoiDung { get; set; }
    }
}