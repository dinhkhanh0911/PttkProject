using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PttkProject.models
{
    public class TTTruyVet
    {
        public TTTruyVet(int iD, DateTime thoiGian, string diaChiChiTiet, string xa, string tinh, string huyen)
        {
            ID = iD;
            this.thoiGian = thoiGian;
            this.diaChiChiTiet = diaChiChiTiet;
            this.xa = xa;
            this.tinh = tinh;
            this.huyen = huyen;
        }

        public int ID { get; set; }
        public DateTime thoiGian { set; get; }
        public string diaChiChiTiet { set; get; }
        public string xa { set; get; }
        public string tinh { set; get; }
        public string huyen { set; get; }
    }
}