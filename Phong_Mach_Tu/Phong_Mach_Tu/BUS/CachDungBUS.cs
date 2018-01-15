using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Phong_Mach_Tu.DTO;
using Phong_Mach_Tu.DAO;

namespace Phong_Mach_Tu.BUS
{
    class CachDungBUS
    {
        public static List<CachDungDTO> SelectAllCachDung()
        {
            List<CachDungDTO> listCachDung = null;

            
            listCachDung = CachDungDAO.SelectAllCachDung();

            return listCachDung;
        }

        public static DbAck Insert(CachDungDTO CachDung)
        {

           
            DbAck result = DbAck.Unknown;

            result = CachDungDAO.Insert(CachDung);


            return result;
        }

        public static DbAck Update(CachDungDTO CachDung)
        {

            
            DbAck result = DbAck.Unknown;

            result = CachDungDAO.Update(CachDung);


            return result;
        }

        public static DbAck Delete(CachDungDTO CachDung)
        {

            DbAck result = DbAck.Unknown;

            result = CachDungDAO.Delete(CachDung);

            return result;
        }
    }
}
