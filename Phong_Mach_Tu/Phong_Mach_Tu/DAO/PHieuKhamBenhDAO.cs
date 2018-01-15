using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Phong_Mach_Tu.DTO;
using Phong_Mach_Tu.BUS;

namespace Phong_Mach_Tu.DAO
{
    class PhieuKhamBenhDAO
    {
        public static List<PhieuKhamBenhDTO> SelectAllCTPhieuKhamBenh()
        {
            List<PhieuKhamBenhDTO> listPhieuKhamBenh = null;

            // Doc thong tin danh sach hoc sinhDung
            string sql = "Select * from CT_PhieuKhamBenh";

            DataTable dt = DataProvider.ExecQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                listPhieuKhamBenh = new List<PhieuKhamBenhDTO>();

                foreach (DataRow row in dt.Rows)
                {
                    PhieuKhamBenhDTO PhieuKham = new PhieuKhamBenhDTO();
                    PhieuKham.MaPhieu = row.ItemArray[0].ToString();
                    PhieuKham.MaThuoc = row.ItemArray[1].ToString();
                    PhieuKham.SoLuong = int.Parse(row.ItemArray[2].ToString());
                    PhieuKham.Gia = int.Parse(row.ItemArray[3].ToString());
                   

                    listPhieuKhamBenh.Add(PhieuKham);
                }
            }

            return listPhieuKhamBenh;
        }



        public static DbAck Insert(PhieuKhamBenhDTO PhieuKhamBenh)
        {

            string sql = "insert into PhieuKhamBenh(ma_phieu_kham_benh,benh_nhan,ngay_lap_phieu,trieu_chung,du_doan_loai_benh) values(@Ma,@MaBN,@Ngay,@TrieuChung,@DuDoanBenh)";

            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter.Add("@Ma", PhieuKhamBenh.MaPhieu);
            parameter.Add("@MaBN", PhieuKhamBenh.MaBN);
            parameter.Add("@Ngay", PhieuKhamBenh.Ngay);
            parameter.Add("@TrieuChung", PhieuKhamBenh.TrieuChung);
            parameter.Add("@DuDoanBenh", PhieuKhamBenh.DuDoanBenh);


            DbAck result = DataProvider.ExecNonQuery(sql, parameter);

            return result;
        }

        public static DbAck InsertCTPhieu(PhieuKhamBenhDTO CTPhieuKhamBenh)
        {

            string sql = "insert into CT_PhieuKhamBenh(ma_phieu_kham_benh,thuoc,so_luong,don_gia) values(@MaPhieu,@MaThuoc,@Sl,@DonGia)";

            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter.Add("@MaPhieu", CTPhieuKhamBenh.MaPhieu);
            parameter.Add("@MaThuoc", CTPhieuKhamBenh.MaThuoc);
            parameter.Add("@Sl", CTPhieuKhamBenh.SoLuong);
            parameter.Add("@DonGia", CTPhieuKhamBenh.Gia);
       


            DbAck result = DataProvider.ExecNonQuery(sql, parameter);

            return result;
        }
        


    }
}
