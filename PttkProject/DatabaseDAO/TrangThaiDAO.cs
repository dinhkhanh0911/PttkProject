using DBCovid.Data;
using DBCovid.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PttkProject.DatabaseDAO
{
    public class TrangThaiDAO: DBCovidContext
    {
        public List<TrangThai> layDSTrangThai()
        {
            List<TrangThai> t = trangThai.ToList();
            return t;
        }
    }
}