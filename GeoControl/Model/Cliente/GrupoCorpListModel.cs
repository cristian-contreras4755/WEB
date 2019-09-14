using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Model.Cliente
{
    [DataContract(Name = "grupocorplistmodel")]
    public class GrupoCorpListModel
    {
        [DataMember(Name = "id_grupocorp")]
        public int IdGrCorp { get; set; }
        [DataMember(Name = "descripcion")]
        public string Descrip { get; set; }
        [DataMember(Name = "color")]
        public string Color { get; set; }
        [DataMember(Name = "estado")]
        public bool IB_Estado { get; set; }
    }
}
