using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Seguridad
{
   public class Persona
    {

        public int IdPersona { get; set; }

        public int IdTipPersona { get; set; }

        public int? IdSucursal { get; set; }

        [StringLength(10)]
        public string CodCliente { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombres { get; set; }

        [StringLength(100)]
        public string ApPat { get; set; }

        [StringLength(100)]
        public string ApMat { get; set; }

        [Required]
        [StringLength(2)]
        public string Cd_TDI { get; set; }

        [Required]
        [StringLength(15)]
        public string NroDoc { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaIngreso { get; set; }

        [StringLength(15)]
        public string Tlf_pesonal { get; set; }

        [StringLength(15)]
        public string Tlf_corporativo { get; set; }

        [StringLength(50)]
        public string CorreoPersonal { get; set; }

        [StringLength(50)]
        public string CorreoCorporativo { get; set; }

        [StringLength(100)]
        public string Direccion { get; set; }

        [StringLength(100)]
        public string img { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FecMdf { get; set; }

        public int? IdUsuMdf { get; set; }

        public int? IdUsuReg { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FecReg { get; set; }

        public bool? IB_Estado { get; set; }
    }
}
