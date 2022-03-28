using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinFast.DATOS.DTOs
{
   public class ComunaDTO
    {
       
        public short   IDREGION { get; set; }
    
        public short IDCIUDAD { get; set; }
       
        public short ID { get; set; }
      
        public string NOMBRE { get; set; }
        public int CODIGOPOSTAL { get; set; }
    
    }
}
