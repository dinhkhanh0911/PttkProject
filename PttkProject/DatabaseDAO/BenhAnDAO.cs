using DBCovid.Data;
using DBCovid.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PttkProject.DatabaseDAO
{
    public class BenhAnDAO:DBCovidContext
    {
        public BenhAn layBenhAnMoiNhat(int idBenhNhan)
        {
            try
            {
                BenhAn BA = (from ba in benhAn
                             join tt in trangThai
                             on ba.trangThaiID equals tt.ID
                             where tt.ID == 1
                             select ba).FirstOrDefault();
                return BA;
            }
            catch
            {
                return null;
            }
        }
    }
}