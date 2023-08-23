using Neptuno2023.Comun.Interfases;
using Neptuno2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2023.Datos.Repositorios
{
   public class RepositorioVentas:IRepositorioVentas 
    {
        private readonly string cadenaConexion;
        public RepositorioVentas()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }

        public void Agregar(Ventas ventas)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string insertQuery = "INSERT INTO Categorias (VentaId, ClienteId, FechaVenta, Total) VALUES(@VentaId, @ClienteId, @FechaVenta, @Total); SELECT SCOPE_IDENTITY()";
                using (var comando = new SqlCommand(insertQuery, conn))
                {
                    comando.Parameters.Add("@FechaVenta", SqlDbType.NVarChar);
                    comando.Parameters["@FechaVenta"].Value = ventas.FechaVenta;

                    comando.Parameters.Add("@Total", SqlDbType.NVarChar);
                    comando.Parameters["@Total"].Value = ventas.Total;

                    comando.Parameters.Add("@ClienteId", SqlDbType.NVarChar);
                    comando.Parameters["@ClienteId"].Value = ventas.ClienteId;

                    int id = Convert.ToInt32(comando.ExecuteScalar());
                    ventas.VentaId = id;

                }
            }
        }

        public void Borrar(int ventaId)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string deleteQuery = "DELETE FROM Categorias WHERE VentaId=@VentaId";
                using (var comando = new SqlCommand(deleteQuery, conn))
                {
                    comando.Parameters.Add("@VentaId", SqlDbType.Int);
                    comando.Parameters["@VentaId"].Value = ventaId;

                    comando.ExecuteNonQuery();
                }
            }
        }

   

        public int GetCantidad()
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string selectQuery = "SELECT COUNT(*) FROM Ventas";
                using (var comando = new SqlCommand(selectQuery, conn))
                {
                    cantidad = (int)comando.ExecuteScalar();
                }
            }
            return cantidad;
        }

        public List<Ventas> GetVentas()
        {
            List<Ventas> lista = new List<Ventas>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string selectQuery = "SELECT VentaId, FechaVenta, ClienteId FROM Ventas ORDER BY VentaId";
                using (var comando = new SqlCommand(selectQuery, conn))
                {
                    using (var reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var ventas = ConstruirVentas(reader);
                            lista.Add(ventas);
                        }
                    }
                }
            }
            return lista;
        }

        private Ventas ConstruirVentas(SqlDataReader reader)
        {
            return new Ventas()
            {
                VentaId = reader.GetInt32(0),
                FechaVenta= reader.GetDateTime(1),
                ClienteId= reader.GetInt32(2),
                Total=  reader.GetDecimal(3),
            
            };
        }

        public List<Ventas> GetVentasPorPagina(int registrosPorPagina, int paginaActual)
        {
            List<Ventas> lista = new List<Ventas>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string selectQuery = @"ccccccc
                    ORDER BY VeentaId
                    OFFSET @cantidadRegistros ROWS 
                    FETCH NEXT @cantidadPorPagina ROWS ONLY";
                using (var comando = new SqlCommand(selectQuery, conn))
                {
                    comando.Parameters.Add("@cantidadRegistros", SqlDbType.Int);
                    comando.Parameters["@cantidadRegistros"].Value = registrosPorPagina * (paginaActual - 1);

                    comando.Parameters.Add("@cantidadPorPagina", SqlDbType.Int);
                    comando.Parameters["@cantidadPorPagina"].Value = registrosPorPagina;
                    using (var reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var categoria = ConstruirVentas(reader);
                            lista.Add(categoria);
                        }
                    }
                }
            }
            return lista;
        }

        public void Editar(Ventas ventas)
        {
            throw new NotImplementedException();
        }
    }
}
