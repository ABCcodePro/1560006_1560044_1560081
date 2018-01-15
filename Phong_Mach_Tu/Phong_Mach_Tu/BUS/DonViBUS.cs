using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phong_Mach_Tu.DTO;
using Phong_Mach_Tu.DAO;

namespace Phong_Mach_Tu.BUS
{
    class DonViBUS
    {
        public static List<DonViDTO> SelectAllDonVi()
        {
            List<DonViDTO> listDonVi = null;

            
            listDonVi = DonViDAO.SelectAllDonVi();

            return listDonVi;
        }

        public static DbAck Insert(DonViDTO DonVi)
        {

           
            DbAck result = DbAck.Unknown;

            result = DonViDAO.Insert(DonVi);


            return result;
        }

        

        public static DbAck Delete(DonViDTO DonVi)
        {

            DbAck result = DbAck.Unknown;

            result = DonViDAO.Delete(DonVi);

            return result;
        }
    }
}
