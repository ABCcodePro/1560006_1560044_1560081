using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phong_Mach_Tu.BUS;
using Phong_Mach_Tu.DTO;
using System.Data;

namespace Phong_Mach_Tu.DAO
{
    class BenhNhanDAO
    {
        public static List<BenhNhanDTO> SelectAllBenhNhan()
        {
            List<BenhNhanDTO> listBenhNhan = null;

            
            string sql = "Select * from BenhNhan";

            DataTable dt = DataProvider.ExecQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                listBenhNhan = new List<BenhNhanDTO>();

                foreach (DataRow row in dt.Rows)
                {
                    BenhNhanDTO BenhNhan = new BenhNhanDTO();
                    BenhNhan.MaBN = row.ItemArray[0].ToString();
                    BenhNhan.HoTen = row.ItemArray[1].ToString();
                    BenhNhan.GioiTinh = row.ItemArray[2].ToString();
                    BenhNhan.NamSinh = row.ItemArray[3].ToString();
                    BenhNhan.DiaChi = row.ItemArray[4].ToString();
                    listBenhNhan.Add(BenhNhan);
                }
            }

            return listBenhNhan;
        }

        public static DbAck Insert(BenhNhanDTO BenhNhan)
        {

            string sql = "insert into BenhNhan(ma_benh_nhan,ho_ten,gioi_tinh,nam_sinh,dia_chi) values(@Ma,@Ten,@gioiTinh,@NamSinh,@DiaChi)";

            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter.Add("@Ma", BenhNhan.MaBN);
            parameter.Add("@Ten", BenhNhan.HoTen);
            parameter.Add("@gioiTinh", BenhNhan.GioiTinh);
            parameter.Add("@NamSinh", BenhNhan.NamSinh);
            parameter.Add("@DiaChi", BenhNhan.DiaChi);


            DbAck result = DataProvider.ExecNonQuery(sql, parameter);

            return result;
        }

    }
}
