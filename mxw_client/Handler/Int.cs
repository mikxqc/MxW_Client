using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mxw_client.Handler
{
    class Int
    {
        public static string ZeroPad(int i)
        {
            if (i < 10)
            {
                return string.Format("0{0}",i);
            }
            return i.ToString();
        }
    }
}
