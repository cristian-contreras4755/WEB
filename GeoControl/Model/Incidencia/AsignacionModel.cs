using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Incidencia
{
    public class AsignacionModel
    {
        public int IdAsignacion { get; set; }
        public int IdPersona { get; set; }
        public int IdIncidencia { get; set; }
        public int IdUsuario { get; set; }
       public int IB_llego { get; set; }

        public int FecHoraReporte { get; set; }
        public int IB_Geo { get; set; }
        public int Lat { get; set; }
        public int Lng { get; set; }
        public int IB_principal { get; set; }

    }
}
