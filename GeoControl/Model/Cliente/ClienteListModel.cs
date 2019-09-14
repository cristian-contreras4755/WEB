using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Model.Cliente
{
    [DataContract(Name = "grupocorplistmodel")]
    public class ClienteListModel
    {

        [DataMember(Name = "cod_cliente")]
        public string CodCliente { get; set; }


        [DataMember(Name = "grupo_corp")]
        public string GrupoCorporativo { get; set; }

        [DataMember(Name = "tipo_doc_idn")]
        public string TipDocIdn { get; set; }


        [DataMember(Name = "ruc")]
        public string RucE { get; set; }


        [DataMember(Name = "razon_social")]
        public string RSocial { get; set; }


        [DataMember(Name = "nom_comercial")]
        public string NomComercial { get; set; }


        [DataMember(Name = "nom_interno")]
        public string NomInterno { get; set; }


        [DataMember(Name = "direccion")]
        public string Direccion { get; set; }

        [DataMember(Name = "direccion2")]
        public string Direccion2 { get; set; }

        [DataMember(Name = "ib_geolocalizacion")]
        public bool IB_Geolocalizacion { get; set; }


        [DataMember(Name = "fecha_mdf")]
        public string FecMdf { get; set; }

        [DataMember(Name = "usu_mdf")]
        public string UsuMdf { get; set; }



        [DataMember(Name = "fecha_reg")]
        public string FecReg { get; set; }

        [DataMember(Name = "usu_reg")]
        public string UsuReg { get; set; }

        [DataMember(Name = "telefono")]
        public string Telef { get; set; }


        [DataMember(Name = "color")]
        public string Color { get; set; }


        [DataMember(Name = "ib_tipocliente")]
        public bool TipoCliente { get; set; }


        [DataMember(Name = "ib_estado")]
        public bool IB_Estado { get; set; }
    }
}
