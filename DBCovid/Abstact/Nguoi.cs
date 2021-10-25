using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCovid.Abstact
{
    public abstract class Nguoi
    {
        public string ten { get; set; }

        public DateTime ngaySinh { get; set; }

        [Required]
        public string CMND { get; set; }

        public string gioiTinh { get; set; }
    }
}
