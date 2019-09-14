using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Model.Cliente
{
    [DataContract(Name = "SucursalxcodcliListModel")]
    public class SucursalxcodcliListModel
    {

        [DataMember(Name = "id_sucursal")]
        public int IdSucursal { get; set; }

        [DataMember(Name = "nom_sucursal")]
        public string NombreInterno { get; set; }

        [DataMember(Name = "ib_geo")]
        public bool? IB_Geolocalizacion { get; set; }

        [DataMember(Name = "lat")]
        public string Lat { get; set; }


        [DataMember(Name = "lng")]
        public string Lng { get; set; }
    }
}
