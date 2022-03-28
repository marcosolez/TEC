using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinFast.DATOS.DTOs
{
  public  class PersonaPostDTO
    {

        public Guid Id { get; set; }
      
        public int RunCuerpo { get; set; }
        [Required]
        [StringLength(1)]
        public string RunDigito { get; set; }
  
        [Required]
        [StringLength(45)]
        public string Nombres { get; set; }
        [Required]
        [StringLength(25)]
        public string ApellidoPaterno { get; set; }
        [StringLength(25)]
        public string ApellidoMaterno { get; set; }
        [StringLength(256)]
        public string Email { get; set; }
        public short SexoCodigo { get; set; }
       
        public DateTime? FechaNacimiento { get; set; }
        public short? RegionCodigo { get; set; }
        public short? CiudadCodigo { get; set; }
        public short? ComunaCodigo { get; set; }
   
        public string Direccion { get; set; }
        public int? Telefono { get; set; }
       
        public string Observaciones { get; set; }

     
     

    }
}
