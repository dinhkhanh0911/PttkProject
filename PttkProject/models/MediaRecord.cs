using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PttkProject.models
{
    public partial class MediaRecord
    {
        
        [Key]
        public int benhNhanID { set; get; }
        public string tenBenhNhan { set; get; }
        public DateTime? ngayNhapVien { set; get; }
        public DateTime? ngayXuatVien { set; get; }

        
        [Range(1,Int32.MaxValue,ErrorMessage = "Vui lòng chọn phòng")]
        public int phongID{set;get;}
        [Required(ErrorMessage = "Vui lòng chọn trạng thái")]
        public int trangThaiID { set; get; }
        public string chanDoan { set; get; }
        public string trieuChung { set; get; }

        

    }
}