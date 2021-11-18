using DBCovid.Data;
using DBCovid.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PttkProject.DatabaseDAO
{
    public class DiaChiDAO:DBCovidContext
    {
        public List<Tinh> layDSTinh()
        {
            List<Tinh> list;
            try
            {
                list = tinh.ToList();
            }
            catch (Exception e)
            {
                return new List<Tinh>();
            }
            return list;
        }
        public List<Huyen> layDSHuyen()
        {
            List<Huyen> list;
            try
            {
                list = huyen.ToList();
            }
            catch (Exception e)
            {
                list = new List<Huyen>();
            }
            return list;
        }
        public List<Xa> layDSXa()
        {
            List<Xa> list;
            try
            {
                list = xa.ToList();
            }
            catch (Exception e)
            {
                list = new List<Xa>();
            }
            return list;
        }
        public Tinh layTinh(int id)
        {
            return tinh.Find(id);
        }
        public Huyen layHuyen(int id)
        {
            return huyen.Find(id);
        }
        public Xa layXa(int id)
        {
            return xa.Find(id);
        }
    }
}