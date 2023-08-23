using Neptuno2023.Entidades.Entidades;
using Neptuno2023.Servicios.Interfases;
using Neptuno2023.Servicios.Servicios;
using Neptuno2023.Windows.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neptuno2023.Windows
{
    public partial class frmVentas : Form
    {
        public frmVentas()
        {
            InitializeComponent();
        }
        private IServicioVentas _servicio;
        private List<Ventas> _lista;


        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            _servicio = new ServiciosVentas();
            try
            {
                _lista = _servicio.GetVentas();
                MostrarDatosEnGrilla();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            foreach (var ventas in _lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, ventas);
                GridHelper.AgregarFila(dgvDatos, r);
            }

        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
        }

    }
}
