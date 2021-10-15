﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PttkProject.models
{
    public class tbl_diaChi
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string chiTiet { get; set; }
        public string moTa { get; set; }
        public int tinhID { get; set; }
        [ForeignKey("tinhID")]
        public virtual tbl_tinh tinh { get; set; }
        public int huyenID { get; set; }
        [ForeignKey("huyenID")]
        public virtual tbl_huyen huyen { get; set; }
        public int xaID { get; set; }
        [ForeignKey("benhNhanID")]
        public virtual tbl_xa xa { get; set; }

    }
}