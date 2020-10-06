using CapaModelo;
using CapaModelo.Clases_Reporteador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaControlador.ControladoresReporteador
{
    public class clsControlAplicativo
    {
        clsSentencia sentencia = new clsSentencia();
        clsConexion conexion = new clsConexion();
        private DataTable tabla;
        private OdbcDataAdapter datos;
        public void insertarAplicativo(clsAplicativo aplicativo)
        {

            try
            {
                string sComando = string.Format("INSERT INTO CLIENTE(nombre_cliente, apellido_cliente, nit_cliente, telefono_cliente) VALUES ('{0}','{1}','{2}',{3});", aplicativo.NomCliente1, aplicativo.ApellCliente1, aplicativo.NitCliente1, aplicativo.TelCliente);
                this.sentencia.ejecutarQuery(sComando);
            }
            catch (Exception ex)
            {
                /*MessageBox.Show("Error al Ingresar Datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);*/
                Console.WriteLine(ex.Message);
            }
        }
        public void modificarAplicativo(clsAplicativo aplicativo)
        {
            try
            {
                string sComando = string.Format("UPDATE CLIENTE SET nombre_cliente='{1}', apellido_cliente='{2}',  nit_cliente='{3}', telefono_cliente={4} WHERE pk_id_cliente={0};", aplicativo.IdCliente, aplicativo.NomCliente1, aplicativo.ApellCliente1, aplicativo.NitCliente1, aplicativo.TelCliente);
                this.sentencia.ejecutarQuery(sComando);
            }
            catch (Exception ex)
            {
                /*MessageBox.Show("Error al Modificar Datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);*/
                Console.WriteLine(ex.Message);
            }
        }

        public void eliminarAplicativo(int iIDApp)
        {
            try
            {
                string sComando = string.Format("DELETE CLIENTE WHERE pk_id_cliente={0};", iIDApp.ToString());
                this.sentencia.ejecutarQuery(sComando);
            }
            catch (Exception ex)
            {
                /*MessageBox.Show("Error al Eliminar Datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);*/
                Console.WriteLine(ex.Message);
            }
        }

        public DataTable obtenerTodo()
        {
            
            try
            {
                string sComando = string.Format("SELECT pk_id_cliente, nombre_cliente,  apellido_cliente, nit_cliente, telefono_cliente FROM CLIENTE ");
                datos = new OdbcDataAdapter(sComando, conexion.conexion());
                tabla = new DataTable();
                datos.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                /*MessageBox.Show("Error al obtener datos");*/
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public DataTable obtenerCamposCombobox(string sCampo1, string sCampo2, string sTabla)
        {
            try
            {
                string sComando = string.Format("SELECT "+sCampo1 +" ,"+sCampo2+" FROM "+sTabla);
                datos = new OdbcDataAdapter(sComando, conexion.conexion());
                tabla = new DataTable();
                datos.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                /*MessageBox.Show("Error al obtener datos");*/
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public DataTable obtenerDatos(int iIDModulo)
        {
            try
            {
                string sComando = string.Format("SELECT pk_id_cliente, nombre_cliente, apellido_cliente, nit_cliente,telefono_cliente FROM CLIENTE WHERE pk_id_aplicativo={0};", iIDModulo.ToString());
                datos = new OdbcDataAdapter(sComando, conexion.conexion());
                tabla = new DataTable();
                datos.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
               /* MessageBox.Show("Error al obtener datos");*/
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
