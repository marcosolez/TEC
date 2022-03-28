using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace FinFast.DATOS.Model
{
    [Table("Comuna")]
    public partial class Comuna
    {
        public Comuna()
        {
            Personas = new HashSet<Persona>();
        }

        [Key]
        public short RegionCodigo { get; set; }
        [Key]
        public short CiudadCodigo { get; set; }
        [Key]
        public short Codigo { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        public int CodigoPostal { get; set; }
        public int CodigoLibroClaseElectronico { get; set; }

        [ForeignKey("RegionCodigo,CiudadCodigo")]
        [InverseProperty("Comunas")]
        public virtual Ciudad Ciudad { get; set; }
        [InverseProperty(nameof(Persona.Comuna))]
        public virtual ICollection<Persona> Personas { get; set; }
    }
}
