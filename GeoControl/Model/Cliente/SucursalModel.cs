using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Model.Cliente
{
    [DataContract(Name = "SucursalModel")]
    public class SucursalModel
    {

        [DataMember(Name = "id_cliente")]
        public int IdSucursal { get; set; }

        [DataMember(Name = "cod_cliente")]
        public string CodCliente { get; set; }

        [DataMember(Name = "nom_int")]
        public string NombreInterno { get; set; }

        [DataMember(Name = "dir")]
        public string Direccion { get; set; }

        [DataMember(Name = "tlf")]
        public string Telefono { get; set; }

        [DataMember(Name = "tlf2")]
        public string Telefono2 { get; set; }

        [DataMember(Name = "correo")]
        public string Correo { get; set; }

        [DataMember(Name = "ib_geo")]
        public bool? IB_Geolocalizacion { get; set; }

        [DataMember(Name = "lng")]
        public string Lng { get; set; }

        [DataMember(Name = "lat")]
        public string Lat { get; set; }

        public string UsuReg { get; set; }

        [DataMember(Name = "ib_esprin")]
        public bool? IB_EsPrinc { get; set; }

    }
}
