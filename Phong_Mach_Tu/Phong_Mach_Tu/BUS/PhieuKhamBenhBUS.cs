using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phong_Mach_Tu.DTO;
using Phong_Mach_Tu.DAO;
namespace Phong_Mach_Tu.BUS
{
    class PhieuKhamBenhBUS
    {
        public static List<PhieuKhamBenhDTO> SelectAllCTPhieuKhamBenh()
        {
            List<PhieuKhamBenhDTO> listCTPhieuKhamBenh = null;

            
            listCTPhieuKhamBenh = PhieuKhamBenhDAO.SelectAllCTPhieuKhamBenh();

            return listCTPhieuKhamBenh;
        }



        public static DbAck Insert(PhieuKhamBenhDTO PhieuKham)
        {

            // Xu ly kiem tra va tinh toan
            DbAck result = DbAck.Unknown;

            result = PhieuKhamBenhDAO.Insert(PhieuKham);


            return result;
        }

        public static DbAck InsertCTPhieu(PhieuKhamBenhDTO CTPhieuKham)
        {

            // Xu ly kiem tra va tinh toan
            DbAck result = DbAck.Unknown;

            result = PhieuKhamBenhDAO.InsertCTPhieu(CTPhieuKham);


            return result;
        }
    }
}
