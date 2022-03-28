using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinFast.DATOS.DTOs
{
    public class CiudadDTO
    {
      
        [Key]
        public short ID { get; set; }
        [Required]
        [StringLength(50)]
        public string NOMBRE { get; set; }
     
    }
}
