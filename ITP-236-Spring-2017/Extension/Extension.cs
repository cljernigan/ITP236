using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension
{
    public static class Extension
    {
        public static string Left(this string name, int length)
        {
            if (name == null)
                return name;
            return length > name.Length ? name : name.Substring(0, length);
        }

        public static string Right(this string name, int length)
        {
            if (name == null)
                return name;
           
            return length > name.Length ? name : name.Substring(name.Length - length, length) ;
        }

    }
}
