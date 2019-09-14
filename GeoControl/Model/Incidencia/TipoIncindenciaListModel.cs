using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Model.Incidencia
{
    [DataContract(Name = "TipoIncindenciaListModel")]
    public class TipoIncindenciaListModel
    {


        [DataMember(Name = "id_tipoincidencia")]
        public int IdTipoIncidencia { get; set; }
        [DataMember(Name = "descripcion")]
        public string Descripcion { get; set; }
        [DataMember(Name = "ib_estado")]
        public bool IB_Estado { get; set; }
    }
}
