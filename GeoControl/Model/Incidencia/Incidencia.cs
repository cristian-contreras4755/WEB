using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace Model.Incidencia
{
    [DataContract(Name = "Incidencia")]
    public class Incidencia
    {
 
        [DataMember(Name = "id_incidencia")]
        public int? IdIncidencia { get; set; }
        [DataMember(Name = "cod_cliente")]
        public string CodCliente { get; set; }

        [DataMember(Name = "id_sucursal")]
        public int IdSucursal { get; set; }
        [DataMember(Name = "id_tipoincidencia")]
        public int IdTipoIncidencia { get; set; }

        [DataMember(Name = "id_estincidencia")]
        public int? IdEstIncidencia { get; set; }
        [DataMember(Name = "id_medsol")]
        public int IdMedSol { get; set; }
        [DataMember(Name = "id_nivel")]
        public int IdNivel { get; set; }

        [DataMember(Name = "resumen")]
        public string Resumen { get; set; }

        [DataMember(Name = "descripcion")]
        public string Descrip { get; set; }

        [DataMember(Name = "descripcion_tec")]
        public string DescripTec { get; set; }


        [DataMember(Name = "descripcion_cancel")]
        public string DescripCancel { get; set; }


        [DataMember(Name = "nom_contacto")]
        public string NombreContacto { get; set; }
        
        [DataMember(Name = "id_usuario")]
        public int? IdUsuReg { get; set; }

        [DataMember(Name = "ib_geo")]
        public bool IB_Geo { get; set; }

        [DataMember(Name = "lng")]
        public string Lng { get; set; }

        [DataMember(Name = "lat")]
        public string Lat { get; set; }

    }
}
