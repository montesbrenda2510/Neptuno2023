using Neptuno2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2023.Entidades.DTO
{
    public class ProveedorDto
    {
        public int ProveedorId { get; set; }
        public string NombreProveedor { get; set; }
        public string Direccion { get; set; }
        public string CodPostal { get; set; }
        public int PaisId { get; set; }
        public Pais Pais { get; set; }
        public int CiudadId { get; set; }
        public Ciudad Ciudad { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
