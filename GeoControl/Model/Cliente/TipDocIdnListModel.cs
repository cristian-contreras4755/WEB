using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Model.Cliente
{
    [DataContract (Name ="tipo_doc_idn")]
   public class TipDocIdnListModel
    {

        [DataMember(Name ="cod_tipodocidn")]
        public string Cd_TDI { get; set; }
        [DataMember(Name = "descripcion")]
        public string Descrip { get; set; }
        [DataMember(Name = "nom_corto")]
        public string NCorto { get; set; }
        [DataMember(Name = "estado")]
        public bool Estado { get; set; }
    }
}
