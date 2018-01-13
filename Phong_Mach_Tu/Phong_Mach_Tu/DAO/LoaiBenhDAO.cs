using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Phong_Mach_Tu.BUS;
using Phong_Mach_Tu.DTO;
using Phong_Mach_Tu.DAO;

namespace Phong_Mach_Tu.DAO
{
    class LoaiBenhDAO
    {
        public static List<LoaiBenhDTO> SelectAllLoaiBenh()
        {
            List<LoaiBenhDTO> listLoaiBenh = null;

            // Doc thong tin danh sach hoc sinh
            string sql = "Select * from LoaiBenh";
            
            DataTable dt = DataProvider.ExecQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                listLoaiBenh = new List<LoaiBenhDTO>();

                foreach (DataRow row in dt.Rows)
                {
                    LoaiBenhDTO loaibenh = new LoaiBenhDTO();
                    loaibenh.Ma = row.ItemArray[0].ToString();
                    loaibenh.Ten = row.ItemArray[1].ToString();
                   
                    listLoaiBenh.Add(loaibenh);
                }
            }

            return listLoaiBenh;
        }

        public static DbAck Insert(LoaiBenhDTO LoaiBenh)
        {

            string sql = "insert into LoaiBenh(ma_loai_benh,ten_loai_benh) values(@Ma,@Ten)";

            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter.Add("@Ma", LoaiBenh.Ma);
            parameter.Add("@Ten", LoaiBenh.Ten);


            DbAck result = DataProvider.ExecNonQuery(sql, parameter);

            return result;
        }

        public static DbAck Update(LoaiBenhDTO LoaiBenh)
        {

            string sql = "update LoaiBenh set ten_loai_benh = @Ten where ma_loai_benh= @Ma";

            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter.Add("@Ma", LoaiBenh.Ma);
            parameter.Add("@Ten", LoaiBenh.Ten);


            DbAck result = DataProvider.ExecNonQuery(sql, parameter);

            return result;
        }

        public static DbAck Delete(LoaiBenhDTO LoaiBenh)
        {
            string sql = "delete from LoaiBenh where ma_loai_benh = @Ma";
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter.Add("@Ma", LoaiBenh.Ma);

            DbAck result = DataProvider.ExecNonQuery(sql, parameter);

            return DbAck.Unknown;
        }
    }
}
