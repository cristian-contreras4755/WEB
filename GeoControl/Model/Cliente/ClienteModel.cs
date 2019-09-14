using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace Model.Cliente
{
    [DataContract (Name = "ClienteModel")]
   public class ClienteModel
    {
       
        [DataMember(Name = "cod_cliente")]
        public string CodCliente { get; set; }

        [DataMember(Name = "id_grupo_corp")]
        public int? IdGrCorp { get; set; }


        [DataMember(Name = "cod_tipdocidn")]
        public string Cd_TDI { get; set; }


        [DataMember(Name = "ruc_empresa")]
        public string RucE { get; set; }

        [DataMember(Name = "razon_social")]
        public string RSocial { get; set; }


        [DataMember(Name = "nombre_comercial")]
        public string NomComercial { get; set; }

  
        [DataMember(Name = "nombre_interno")]
        public string NomInterno { get; set; }


        [DataMember(Name = "nombres")]
        public string Nombres { get; set; }

        [DataMember(Name = "ap_paterno")]
        public string ApPaterno { get; set; }

   
        [DataMember(Name = "ap_materno")]
        public string ApMaterno { get; set; }


        [DataMember(Name = "direccion")]
        public string Direccion { get; set; }


        [DataMember(Name = "direccion2")]
        public string Direccion2 { get; set; }

        [DataMember(Name = "ib_geolocalizacion")]
        public bool? IB_Geolocalizacion { get; set; }

  
        [DataMember(Name = "lng")]
        public string Lng { get; set; }


        [DataMember(Name = "lat")]
        public string Lat { get; set; }



        [DataMember(Name = "usu_reg")]
        public string UsuReg { get; set; }

        [DataMember(Name = "felefono")]
        public string Telef { get; set; }


        [DataMember(Name = "color")]
        public string Color { get; set; }

        [DataMember(Name = "ibtip_cliente")]
        public bool TipoCliente { get; set; }
    }
}
