using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Incidencia.api
{
   public class IncidenciaModelApi
    {

        public int? IdIncidencia { get; set; }

        public string Cod_Incidencia { get; set; }
   
        public string CodCliente { get; set; }

        public int? IdSucursal { get; set; }

        public int IdTipoIncidencia { get; set; }

        public int IdEstIncidencia { get; set; }

        public int IdMedSol { get; set; }

        public int IdNivel { get; set; }
        public DateTime Fecha { get; set; }
        public string Resumen { get; set; }
        public string Descrip { get; set; }
        public string DescripTec { get; set; }
        public string DescripCancel { get; set; }
        public string NombreContacto { get; set; }
        public int? IdUsuReg { get; set; }
        public int? IdUsuMdf { get; set; }
        public bool IB_Geo { get; set; }
        public string Lng { get; set; }
        public string Lat { get; set; }

    }
}
