using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Phong_Mach_Tu.DAO;
using Phong_Mach_Tu.DTO;

namespace Phong_Mach_Tu.BUS
{
    class ThuocBUS
    {
        public static List<ThuocDTO> SelectAllThuoc()
        {
            List<ThuocDTO> listThuoc = null;

            // Doc thong tin danh sach hoc sinh
            listThuoc = ThuocDAO.SelectAllThuoc();

            return listThuoc;
        }

        public static DbAck Insert(ThuocDTO Thuoc)
        {

            // Xu ly kiem tra va tinh toan
            DbAck result = DbAck.Unknown;

            result = ThuocDAO.Insert(Thuoc);


            return result;
        }

        public static DbAck Update(ThuocDTO Thuoc)
        {

            // Xu ly kiem tra va tinh toan
            DbAck result = DbAck.Unknown;

            result = ThuocDAO.Update(Thuoc);


            return result;
        }

        public static DbAck Delete(ThuocDTO Thuoc)
        {

            DbAck result = DbAck.Unknown;

            result = ThuocDAO.Delete(Thuoc);

            return result;
        }
    }
}
