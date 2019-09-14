using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Model.Incidencia
{
    [DataContract(Name = "IncidenciaListModel")]
  public  class IncidenciaListModel
    {

        [DataMember(Name = "id_incidencia")]
        public string IdIncidencia { get; set; }

        [DataMember(Name = "cod_incidencia")]
        public string Cod_Incidencia { get; set; }

        [DataMember(Name = "cliente")]
        public string Cliente { get; set; }
        [DataMember(Name = "sucursal")]
        public string Sucursal { get; set; }
        [DataMember(Name = "tipo_incidencia")]
        public string TipoInc { get; set; }
        [DataMember(Name = "estado")]
        public string Estado { get; set; }
        [DataMember(Name = "fecha")]
        public string Fecha { get; set; }

        [DataMember(Name = "contacto")]
        public string NombreContacto { get; set; }

        [DataMember(Name = "usu_reg")]
        public string UsuReg { get; set; }
        [DataMember(Name = "usu_mdf")]
        public string UsuMdf { get; set; }
        [DataMember(Name = "ib_geo")]
        public bool IB_Geo { get; set; }
        [DataMember(Name = "lng")]
        public string Lng { get; set; }
        [DataMember(Name = "lat")]
        public string Lat { get; set; }


    }
}
