using DBCovid.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCovid.Data
{
    class DBCovidContext : DbContext
    {
        public DBCovidContext()
            : base("DBCovidContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        
        public virtual DbSet<tbl_nguoiDung> tbl_nguoiDung { get; set; }
        public virtual DbSet<tbl_nhanVienYTe> tbl_nhanVienYTe { get; set; }
        
        
    }
}
