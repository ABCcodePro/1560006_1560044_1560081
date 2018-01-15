using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phong_Mach_Tu.DTO;
using Phong_Mach_Tu.DAO;
namespace Phong_Mach_Tu.BUS
{
    class TienKhamBUS
    {
        public static DbAck Update(TienKhamDTO TienKham)
        {

          
            DbAck result = DbAck.Unknown;

            result = TienKhamDAO.Update(TienKham);


            return result;
        }
    }
}
