using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2023.Entidades.Entidades
{
    public class Ventas
    {
        public int VentaId { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaVenta { get; set; }
        public Decimal Total{ get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }
}
