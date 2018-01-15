using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phong_Mach_Tu.DTO;
using Phong_Mach_Tu.DAO;

namespace Phong_Mach_Tu.BUS
{
    class LoaiBenhBUS
    {
        public static List<LoaiBenhDTO> SelectAllLoaiBenh()
        {
            List<LoaiBenhDTO> listLoaiBenh = null;

           
            listLoaiBenh = LoaiBenhDAO.SelectAllLoaiBenh();

            return listLoaiBenh;
        }

        public static DbAck Insert(LoaiBenhDTO LoaiBenh)
        {

            // Xu ly kiem tra va tinh toan
            DbAck result = DbAck.Unknown;

            result = LoaiBenhDAO.Insert(LoaiBenh);


            return result;
        }

        public static DbAck Update(LoaiBenhDTO LoaiBenh)
        {

            // Xu ly kiem tra va tinh toan
            DbAck result = DbAck.Unknown;

            result = LoaiBenhDAO.Update(LoaiBenh);


            return result;
        }

        public static DbAck Delete(LoaiBenhDTO LoaiBenh)
        {

            DbAck result = DbAck.Unknown;

            result = LoaiBenhDAO.Delete(LoaiBenh);

            return result;
        }
    }
}
