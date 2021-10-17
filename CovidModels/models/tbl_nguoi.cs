using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PttkProject.models
{
    public class tbl_nguoi
    {
        [Key]
        [Column(Order =1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string ten { get; set; }
        public DateTime ngaySinh { get; set; }
        [Required]

        public string CMND { get; set; }
        public string gioiTinh { get; set; }
        public int diaChiID { get; set; }
        [ForeignKey("diaChiID")]
        public virtual tbl_diaChi diaChi { get; set; }
    }
}