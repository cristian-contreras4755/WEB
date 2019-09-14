using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Model.Incidencia
{
    [DataContract(Name = "EstadoIncidencia")]
    public  class EstadoIncidencia
    {

        [DataMember(Name = "id_estinc")]
        public int? IdEstIncidencia { get; set; }

        [DataMember(Name = "descripcion")]
        public string Descripcion { get; set; }
        [DataMember(Name = "ib_estado")]
        public bool IB_Estado { get; set; }


    }
}
