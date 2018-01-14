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
    class CachDungDAO
    {
        public static List<CachDungDTO> SelectAllCachDung()
        {
            List<CachDungDTO> listCachDung = null;

            // Doc thong tin danh sach hoc sinhDung
            string sql = "Select * from CachDung";

            DataTable dt = DataProvider.ExecQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                listCachDung = new List<CachDungDTO>();

                foreach (DataRow row in dt.Rows)
                {
                    CachDungDTO cachdung = new CachDungDTO();
                    cachdung.Ma = row.ItemArray[0].ToString();
                    cachdung.Ten = row.ItemArray[1].ToString();

                    listCachDung.Add(cachdung);
                }
            }

            return listCachDung;
        }

        public static DbAck Insert(CachDungDTO CachDung)
        {

            string sql = "insert into CachDung(ma_cach_dung,cach_su_dung) values(@Ma,@Ten)";

            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter.Add("@Ma", CachDung.Ma);
            parameter.Add("@Ten", CachDung.Ten);


            DbAck result = DataProvider.ExecNonQuery(sql, parameter);

            return result;
        }

        public static DbAck Update(CachDungDTO CachDung)
        {

            string sql = "update CachDung set cach_su_dung = @Ten where ma_cach_dung= @Ma";

            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter.Add("@Ma", CachDung.Ma);
            parameter.Add("@Ten", CachDung.Ten);


            DbAck result = DataProvider.ExecNonQuery(sql, parameter);

            return result;
        }

        public static DbAck Delete(CachDungDTO CachDung)
        {
            string sql = "delete from CachDung where ma_cach_dung = @Ma";
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter.Add("@Ma", CachDung.Ma);

            DbAck result = DataProvider.ExecNonQuery(sql, parameter);

            return DbAck.Ok;
        }
    }
}
