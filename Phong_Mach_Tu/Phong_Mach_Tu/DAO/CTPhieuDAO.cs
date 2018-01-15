using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phong_Mach_Tu.DTO;
using Phong_Mach_Tu.BUS;
using System.Data;
namespace Phong_Mach_Tu.DAO
{
    class CTPhieuDAO
    {
        public static List<CTPhieuDTO> SelectAllCTPhieuKhamBenh()
        {
            List<CTPhieuDTO> listCTPhieu = null;

            // Doc thong tin danh sach hoc sinhDung
            string sql = "Select * from CT_PhieuKhamBenh";

            DataTable dt = DataProvider.ExecQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                listCTPhieu = new List<CTPhieuDTO>();

                foreach (DataRow row in dt.Rows)
                {
                    CTPhieuDTO CTPhieu = new CTPhieuDTO();
                    CTPhieu.MaPhieu = row.ItemArray[0].ToString();
                    CTPhieu.MaThuoc = row.ItemArray[1].ToString();
                    CTPhieu.Sl = int.Parse(row.ItemArray[2].ToString());
                    CTPhieu.DonGia = int.Parse(row.ItemArray[3].ToString());
                   

                    listCTPhieu.Add(CTPhieu);
                }
            }

            return listCTPhieu;
        }
    }
}
