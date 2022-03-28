using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinFast.DATOS.DTOs
{
   public class RegionDTO
    {
   
        public short ID { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMBRE { get; set; }

        [Required]
        [StringLength(40)]
        public string NOMBREOFICIAL { get; set; }

    }
}
