using System;
using System.Collections.Generic;

namespace Common
{
    public class CommonResult<T>
    {
        public string MsjDB { get; set; }
        public string MsjError { get; set; }
        public bool Exito { get; set; }
        public  List<T> Lista { get; set; }
        public T Entidad { get; set; }
        public bool Val { get; set; }

    }
}
