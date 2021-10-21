using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CovidModels.models
{
    public class tbl_tinh
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string tenTinh { get; set; }
        public string moTa { get; set; }
        public virtual ICollection<tbl_huyen> Huyen { get; set; }
    }
}