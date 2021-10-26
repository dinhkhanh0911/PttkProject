using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBCovid.Data;
using DBCovid.models;

namespace PttkProject.DatabaseDAO
{
    
    public class DBIO
    {
        private DBCovidContext data = new DBCovidContext();
        public List<BenhNhan> layDSBenhNhan()
        {
            List<BenhNhan> b = data.benhNhan.ToList();
            return b;
        }
        public List<BenhNhan> layDSBenhNhan(string input)
        {
            List<BenhNhan> b = data.benhNhan.Where(x => x.CMND == input || x.ten == input).ToList();
            return b;
        }
    }

}