using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PttkProject.models
{
    public class User
    {
        [Key]
        [Required]
        public string taiKhoan { get; set; }
        [Required]
        public string matKhau { get; set; }
    }
}