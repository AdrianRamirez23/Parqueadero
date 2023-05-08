using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Parqueadero.DTOs
{
    public class ResultDTO
    {
        public bool estado { get; set; }
        public string mensaje { get; set; }
        public Object Result { get; set; } 
    }
}
