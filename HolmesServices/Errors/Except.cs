using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolmesServices.Errors
{
    public static class Except
    {
        public static Exception ThrowExcept(string eMsg)
        {
            throw new Exception(eMsg);
        }
    }
}
