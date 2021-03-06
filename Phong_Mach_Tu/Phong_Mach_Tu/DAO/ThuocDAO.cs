﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Phong_Mach_Tu.BUS;
using Phong_Mach_Tu.DTO;

namespace Phong_Mach_Tu.DAO
{
    class ThuocDAO
    {
        public static List<ThuocDTO> SelectAllThuoc()
        {
            List<ThuocDTO> listThuoc = null;

           
            string sql = "Select * from Thuoc";

            DataTable dt = DataProvider.ExecQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                listThuoc = new List<ThuocDTO>();

                foreach (DataRow row in dt.Rows)
                {
                    ThuocDTO Thuoc = new ThuocDTO();
                    Thuoc.MaThuoc = row.ItemArray[0].ToString();
                    Thuoc.TenThuoc = row.ItemArray[1].ToString();
                    Thuoc.DonVi = row.ItemArray[2].ToString();
                    Thuoc.CachDung = row.ItemArray[3].ToString();
                    Thuoc.SoLuong = int.Parse(row.ItemArray[4].ToString());
                    Thuoc.GiaThuoc = int.Parse(row.ItemArray[5].ToString());
                    Thuoc.MoTa = row.ItemArray[6].ToString();

                    listThuoc.Add(Thuoc);
                }
            }

            return listThuoc;
        }

        public static DbAck Insert(ThuocDTO Thuoc)
        {

            string sql = "insert into Thuoc(ma_thuoc,ten_thuoc,don_vi,cach_dung,so_luong,gia_thuoc,mo_ta) values(@Ma,@Ten,@DonVi,@CachDung,@Sl,@Gia,@Mota)";

            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter.Add("@Ma", Thuoc.MaThuoc);
            parameter.Add("@Ten", Thuoc.TenThuoc);
            parameter.Add("@DonVi", Thuoc.DonVi);
            parameter.Add("@CachDung", Thuoc.CachDung);
            parameter.Add("@SL", Thuoc.SoLuong);
            parameter.Add("@Gia", Thuoc.GiaThuoc);
            parameter.Add("@Mota", Thuoc.MoTa);


            DbAck result = DataProvider.ExecNonQuery(sql, parameter);

            return result;
        }

        public static DbAck Update(ThuocDTO Thuoc)
        {

            string sql = "update Thuoc set gia_thuoc = @Gia where ma_thuoc= @Ma";

            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter.Add("@Ma", Thuoc.MaThuoc);
            parameter.Add("@Gia", Thuoc.GiaThuoc);


            DbAck result = DataProvider.ExecNonQuery(sql, parameter);

            return result;
        }

        public static DbAck Delete(ThuocDTO Thuoc)
        {
            string sql = "delete from Thuoc where ma_thuoc = @Ma";
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter.Add("@Ma", Thuoc.MaThuoc);

            DbAck result = DataProvider.ExecNonQuery(sql, parameter);

            return DbAck.Ok;
        }

        
    }
}
