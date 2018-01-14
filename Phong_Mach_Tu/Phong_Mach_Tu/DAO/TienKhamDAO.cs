using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phong_Mach_Tu.DTO;
using Phong_Mach_Tu.DAO;

namespace Phong_Mach_Tu.DAO
{
    class TienKhamDAO
    {
        public static DbAck Update(TienKhamDTO TienKham)
        {

            string sql = "update TienKham set tien_kham = @Tien";

            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter.Add("@Tien", TienKham.Tien);
           


            DbAck result = DataProvider.ExecNonQuery(sql, parameter);

            return result;
        }
    }
}
