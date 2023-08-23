using Neptuno2023.Comun.Interfases;
using Neptuno2023.Datos.Repositorios;
using Neptuno2023.Entidades.Entidades;
using Neptuno2023.Servicios.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2023.Servicios.Servicios
{
    public class ServiciosVentas : IServicioVentas 
    {
        private readonly IRepositorioVentas _repositorio;
        public ServiciosVentas()
        {
        _repositorio = new RepositorioVentas();
        }
        public void Agregar(Ventas ventas)
        {
            throw new NotImplementedException();
        }

        public void Borrar(int ventaId)
        {
            try
            {
                _repositorio.Borrar(ventaId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCantidad()
        {
            try
            {
                return _repositorio.GetCantidad();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Ventas> GetVentas()
        {
            try
            {
                return _repositorio.GetVentas();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Ventas> GetVentasPorPagina(int registrosPorPagina, int paginaActual)
        {
            try
            {
                return _repositorio.GetVentasPorPagina(registrosPorPagina, paginaActual);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}
