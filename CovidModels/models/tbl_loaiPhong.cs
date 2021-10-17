using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PttkProject.models
{
    public class tbl_loaiPhong
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string tenLoaiPhong { get; set; }
        public string moTa { get; set; }
        public virtual ICollection<tbl_phongBenh> PhongBenh { get; set; }
    }
}