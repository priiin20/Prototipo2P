using System;
using CapaControlador.ControladoresReporteador;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaModelo.Clases_Reporteador;

namespace CapaVista.Mantenimientos
{
    public partial class frmAplicativo : Form
    {
        private clsAplicativo aplicativo;
        private string sNombreAux, sDescAux, sApellidoAux, sDireccionAux, sfechaAux;
        private int iIDAux, iIDModAux, itelefono;
        clsControlAplicativo controlAplicativo=new clsControlAplicativo();
        public frmAplicativo()
        {
            InitializeComponent();
            cargarDatos();
            CargarBusqueda();
            BloquearBotones();
        }

 
        private void CargarBusqueda()
        {
            cmbBuscar.DisplayMember = "nombre_cliente";
            cmbBuscar.ValueMember = "pk_id_cliente";
            cmbBuscar.DataSource = controlAplicativo.obtenerCamposCombobox("pk_id_cliente", "nombre_cliente", "CLIENTE");
            cmbBuscar.SelectedIndex = -1;
            cmbBuscar.Refresh();
        }
        private void cargarDatos()
        {
            dgvVistaDatos.DataSource = controlAplicativo.obtenerTodo();
        }
        private void BloquearBotones()
        {
            btnGuardar.Enabled = true;
        }
        private clsAplicativo llenarCampos()
        {
            DateTime dtFechaIngreso = Dt_fecha.Value;
            clsAplicativo auxAplicativo = new clsAplicativo();
            auxAplicativo.NomCliente1 = txtNombre.Text;
            auxAplicativo.ApellCliente1 = txtApellido.Text;
            auxAplicativo.NitCliente1 = txtNit.Text;
            auxAplicativo.TelCliente = int.Parse(txtTelefono.Text);


            return auxAplicativo;
        }

        private void LimpiarComponentes()
        {
            txtNombre.Text= "";
            txtApellido.Text = "";
            txtTelefono.Text ="";
            txtNombre.Focus();
        }
        private clsAplicativo ObtenerModificaciones()
        {
            DateTime dtFechaIngreso = Dt_fecha.Value;
            
            clsAplicativo auxAplicativo = new clsAplicativo();
            auxAplicativo.NomCliente1 = txtNombre.Text;
            auxAplicativo.ApellCliente1 = txtApellido.Text;
            auxAplicativo.NitCliente1 = txtNit.Text;
            auxAplicativo.TelCliente = int.Parse(ToString());

            return auxAplicativo;
        }

        private bool guardarDatos()
        {
            this.aplicativo = llenarCampos();
            try
            {
                controlAplicativo.insertarAplicativo(this.aplicativo);
                cargarDatos();
                MessageBox.Show("Datos Correctamente Guardados", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Guardar los Datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (guardarDatos() == true)
            {
                LimpiarComponentes();
            }
            else
            {
                LimpiarComponentes();
            }
        }
        private bool ModificarDatos()
        {
            this.aplicativo = ObtenerModificaciones();
            try
            {
                controlAplicativo.modificarAplicativo(this.aplicativo);
                cargarDatos();
               /* MessageBox.Show("Datos Correctamente Modificados", "", MessageBoxButtons.OK, MessageBoxIcon.Information);*/
                return true;
            }
            catch (Exception ex)
            {
                /*MessageBox.Show("Error al Modificar los Datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error); */
                 Console.WriteLine(ex.Message);
                return false;
                throw;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (ModificarDatos() == true)
            {
                LimpiarComponentes();
                BloquearBotones();
            }
            else
            {
                LimpiarComponentes();
                BloquearBotones();
            }
        }

        private void cmsEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dgMensaje = MessageBox.Show("Una vez eliminados estos datos no se podrán recuperar, ¿Desea Continuar?", "¡ADVERTENCIA!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dgMensaje == DialogResult.Yes)
                {

                    this.controlAplicativo.eliminarAplicativo(iIDAux);
                    cargarDatos();
                    MessageBox.Show("Datos Correctamente Eliminados", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }else if (dgMensaje == DialogResult.No)
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Eliminar los Datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }
        }



        private void frmAplicativo_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult drResultadoMensaje;
            drResultadoMensaje = MessageBox.Show("¿Realmente desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (drResultadoMensaje == DialogResult.Yes)
            {
                this.Dispose();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "AyudasReporteador/AyudasObjetoReporteador.chm", "Aplicativo.html");
        }

        private void cmbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBuscar.SelectedIndex >= 0)
            {
                int iIDAux = int.Parse(cmbBuscar.SelectedValue.ToString());
                dgvVistaDatos.DataSource = controlAplicativo.obtenerDatos(iIDAux);
            }
            else if (cmbBuscar.SelectedIndex < 0)
            {
                cargarDatos();
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarBusqueda();
        }

        private void cmbModulo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvVistaDatos_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            /* if (e.Button == MouseButtons.Right)
             {
                 iIDAux = int.Parse(dgvVistaDatos.Rows[e.RowIndex].Cells["pk_id_cliente"].Value.ToString());
                 sNombreAux = dgvVistaDatos.Rows[e.RowIndex].Cells["nombre_cliente"].Value.ToString();
                 sApellidoAux = dgvVistaDatos.Rows[e.RowIndex].Cells["apellido_cliente"].Value.ToString();
                 sDireccionAux = dgvVistaDatos.Rows[e.RowIndex].Cells["direccion_cliente"].Value.ToString();
                 itelefono=int.Parse(dgvVistaDatos.Rows[e.RowIndex].Cells["telefono_cliente"].Value.ToString());
                sfechaAux = dgvVistaDatos.Rows[e.RowIndex].Cells["fecha_cliente"].Value.ToString();
                 this.cmsEM.Show(this.dgvVistaDatos, e.Location);
                 cmsEM.Show(Cursor.Position);
             }*/
        }

        private void cmsModificar_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = false;
            txtNombre.Text = sNombreAux;
        }
    }
}

// frmGestorReportes reporte = new frmGestorReportes(); poner en los botones
//      auxAplicativo.ApellCliente1 = int.Parse(cmbModulo.SelectedValue.ToString());