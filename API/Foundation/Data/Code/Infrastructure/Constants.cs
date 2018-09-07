using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Foundation.Data.Infrastructure
{
    public class Constants
    {
        #region DATEFORMAT
        public static string FORMAT_DATETIME { get { return "dd/MM/yyyy hh:MM"; } }
        public static string FORMAT_DATE { get { return "dd/MM/yyyy"; } }
        public static string FORMAT_MONTH { get { return "MM/yyyy"; } }
        public static string FORMAT_TIMETICKS { get { return "yyyyMMddHHmmssfff"; } }
        #endregion

        #region UserRole
        public static string NORMAL_USER { get { return "Normal user"; } }
        public static string ADMIN_USER { get { return "Admin"; } }
        #endregion

        #region TOKEN
        public static string TOKEN_TYPE_REGIST { get { return "01"; } }
        public static string TOKEN_TYPE_FORGOT { get { return "02"; } }
        #endregion

        #region ExpireMinute
        public static double EXPIRE_MINUTE { get { return 30; } }
        #endregion
    }
}
