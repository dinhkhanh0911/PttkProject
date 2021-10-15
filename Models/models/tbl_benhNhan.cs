﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PttkProject.models
{
    public class tbl_benhNhan:tbl_nguoi
    {
        [Key]
        public string maBHYT { get; set; }
        public string sdtBenhNhan { get; set; }
        public string sdtNguoiThan { get; set; }
        public virtual ICollection<tbl_benhAn> BenhAn { get; set; }
    }
}