using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Phong_Mach_Tu.BUS;
using Phong_Mach_Tu.DTO;


namespace Phong_Mach_Tu.DAO
{
    class DonViDAO
    {
        public static List<DonViDTO> SelectAllDonVi()
        {
            List<DonViDTO> listDonVi = null;
            string sql = "Select * from DonVi";
            // Doc thong tin danh sach hoc sinhDung
            DataTable dt = DataProvider.ExecQuery(sql);
            
            if (dt != null && dt.Rows.Count > 0)
            {
                listDonVi = new List<DonViDTO>();

                foreach (DataRow row in dt.Rows)
                {
                    DonViDTO donvi = new DonViDTO();
                    donvi.TenDonVi = row.ItemArray[0].ToString();
                    

                    listDonVi.Add(donvi);
                }
            }

            
            return listDonVi;
        }

        public static DbAck Insert(DonViDTO DonVi)
        {

            string sql = "insert into DonVi(ten_don_vi) values(@Ten)";

            Dictionary<string, object> parameter = new Dictionary<string, object>();
           
            parameter.Add("@Ten", DonVi.TenDonVi);


            DbAck result = DataProvider.ExecNonQuery(sql, parameter);

            return result;
        }

        //public static DbAck Update(DonViDTO DonVi)
        //{

        //    string sql = "update DonVi set ten_don_vi = @Ten";

        //    Dictionary<string, object> parameter = new Dictionary<string, object>();
           
        //    parameter.Add("@Ten", DonVi.TenDonVi);


        //    DbAck result = DataProvider.ExecNonQuery(sql, parameter);

        //    return result;
        //}

        public static DbAck Delete(DonViDTO DonVi)
        {
            string sql = "delete from DonVi where ten_don_vi = @Ten";
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter.Add("@Ten", DonVi.TenDonVi);

            DbAck result = DataProvider.ExecNonQuery(sql, parameter);

            return DbAck.Unknown;
        }
    }
}
