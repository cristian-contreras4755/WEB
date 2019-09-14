using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Incidencia
{
   public class Asignacion
    {

        [Key]
        public int IdAsignacion { get; set; }

        public int IdEmpleado { get; set; }

        public int IdIncidencia { get; set; }

        public DateTime FecReg { get; set; }

        public int Id_Usuario { get; set; }

        public DateTime FecHoraAsignacion { get; set; }

        public bool? IB_llego { get; set; }

        public DateTime? FecHoraReporte { get; set; }

        public bool IB_Geo { get; set; }

        [StringLength(50)]
        public string Lat { get; set; }

        [StringLength(50)]
        public string Lng { get; set; }

        public bool IB_principal { get; set; }



    }
}
