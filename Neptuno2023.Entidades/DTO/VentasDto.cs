using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2023.Entidades.DTO
{
    public class VentasDto
    {
        public int VentasId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaVenta { get; set; }
        public int Total { get; set; }


        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
