using System;
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
        public int xaID { get; set; }
        [ForeignKey("xaID")]
        public virtual tbl_xa xa { get; set; }

    }
}