using DBCovid.Data;
using DBCovid.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PttkProject.DatabaseDAO
{
    public class NhanVienYTeDAO: DBCovidContext
    {
        /*Nhân viên y tế*/
        public List<NhanVienYTe> layDSNhanVienYTe()
        {
            return nhanVienYTe.ToList();
        }
    }
}