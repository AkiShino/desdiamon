using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Foundation.Data.Infrastructure
{
    public class Constants
    {
        public static string FORMAT_DATETIME { get { return "dd/MM/yyyy hh:MM"; } }
        public static string FORMAT_DATE { get { return "dd/MM/yyyy"; } }
        public static string FORMAT_MONTH { get { return "MM/yyyy"; } }
        public static string FORMAT_TIMETICKS { get { return "yyyyMMddHHmmssfff"; } }
    }
}
