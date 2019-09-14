using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Model.Incidencia
{
    [DataContract(Name ="Nivel")]
    public  class NivelListModel
    {


        [DataMember(Name = "id_nivel")]
        public int? IdNivel { get; set; }

        [DataMember(Name = "descripcion")]
        public string Descrip { get; set; }

        [DataMember(Name = "ib_estado")]
        public bool IB_Estado { get; set; }




    }
}
