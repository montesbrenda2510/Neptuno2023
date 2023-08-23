using Neptuno2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2023.Comun.Interfases
{
    public interface IRepositorioVentas
    {
        void Agregar(Ventas ventas);
        void Borrar(int ventaId);
     
        int GetCantidad();
        List<Ventas> GetVentas();
        List<Ventas> GetVentasPorPagina(int registrosPorPagina, int paginaActual);
    }
}
