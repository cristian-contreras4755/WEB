using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Model.Cliente
{
    [DataContract(Name = "SucursalModellista")]
    public class SucursalListModel
    {

   

        [DataMember(Name = "id_sucursal")]
        public int IdSucursal { get; set; }

        [DataMember(Name = "nom_cliente")]
        public string Nombre { get; set; }

        [DataMember(Name = "nom_sucursal")]
        public string NombreInterno { get; set; }

        [DataMember(Name = "dir")]
        public string Direccion { get; set; }

        [DataMember(Name = "tel")]
        public string Telefono { get; set; }
        [DataMember(Name = "tel2")]
        public string Telefono2 { get; set; }

        [DataMember(Name = "correo")]
        public string Correo { get; set; }

        [DataMember(Name = "ib_geo")]
        public bool? IB_Geolocalizacion { get; set; }

        
       [DataMember(Name = "fec_reg")]
        public string FecReg { get; set; }

        [DataMember(Name = "usu_reg")]
        public string UsuReg { get; set; }
        [DataMember(Name = "usu_mdf")]

        public string UsuMdf { get; set; }
        [DataMember(Name = "fec_mdf")]
        public string FecMdf { get; set; }
        [DataMember(Name = "ib_esprim")]

        public bool? IB_EsPrinc { get; set; }
        [DataMember(Name = "estado")]
        public bool? IB_Estado { get; set; }


    }
}
