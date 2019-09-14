using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Incidencia
{
    public  class AdjuntoModel
    {
        public int IdAdjunto { get; set; }
        public int? IdIncidencia { get; set; }
        public int? IdOrdenServicio { get; set; }
        public string Img { get; set; }
    }
}
