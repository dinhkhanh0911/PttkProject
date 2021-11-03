using DBCovid.models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DBCovid.Abstact
{
    public abstract class Nguoi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        public string ten { get; set; }

        [Column(TypeName = "Date")]

        public DateTime? ngaySinh { get; set; }

        [Required]
        public string CMND { get; set; }
        public string diaChichiTiet { get; set; }
        public int xaID { get; set; }
        
        public string moTa { set; get; }

        [Required]
        public string gioiTinh { get; set; }

        [ForeignKey("xaID")]
        public virtual Xa xa { get; set; }


    }
}
