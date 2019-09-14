using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoControl.Models.Incidencias
{
    public class AsignacionViewModel
    {
        public int IdAsignacion { get; set; }
        public int IdPersona { get; set; }
        public int IdIncidencia { get; set; }
        public int IB_principal { get; set; }
    }
}
