using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phong_Mach_Tu.DAO;
using Phong_Mach_Tu.DTO;

namespace Phong_Mach_Tu.BUS
{
    class CTPhieuBUS
    {
        public static List<CTPhieuDTO> SelectAllCTPhieuKhamBenh()
        {
            List<CTPhieuDTO> listCTPhieuKhamBenh = null;

            // Doc thong tin danh sach hoc sinh
            listCTPhieuKhamBenh = CTPhieuDAO.SelectAllCTPhieuKhamBenh();

            return listCTPhieuKhamBenh;
        }
    }
}
