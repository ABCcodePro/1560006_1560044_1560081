using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phong_Mach_Tu.DTO;
using Phong_Mach_Tu.DAO;

namespace Phong_Mach_Tu.BUS
{
    class BenhNhanBUS
    {
        public static List<BenhNhanDTO> SelectAllBenhNhan()
        {
            List<BenhNhanDTO> listBenhNhan = null;

            // Doc thong tin danh sach hoc sinh
            listBenhNhan = BenhNhanDAO.SelectAllBenhNhan();

            return listBenhNhan;
        }

        public static DbAck Insert(BenhNhanDTO BenhNhan)
        {

            // Xu ly kiem tra va tinh toan
            DbAck result = DbAck.Unknown;

            result = BenhNhanDAO.Insert(BenhNhan);


            return result;
        }
    }
}
