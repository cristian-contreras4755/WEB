using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Model.Incidencia
{
    [DataContract(Name = "MedioSolicitud")]
    public  class MedioSolicitud
    {

        [DataMember(Name = "id_medsol")]
        public int? IdMedSol { get; set; }

        [DataMember(Name = "descripcion")]
        public string Descripcion { get; set; }

        [DataMember(Name = "ib_estado")]
        public bool IB_Estado { get; set; }


    }
}
