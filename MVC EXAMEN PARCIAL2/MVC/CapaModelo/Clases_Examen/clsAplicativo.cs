using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo.Clases_Reporteador
{
    public class clsAplicativo
    {
        private int idCliente;
        private string NomCliente;
        private string ApellCliente;
        private string NitCliente;
        private int telCliente;

        public int IdCliente { get => idCliente; set => idCliente = value; }
        public string NomCliente1 { get => NomCliente; set => NomCliente = value; }
        public string ApellCliente1 { get => ApellCliente; set => ApellCliente = value; }
        public string NitCliente1 { get => NitCliente; set => NitCliente = value; }
        public int TelCliente { get => telCliente; set => telCliente = value; }
    }
}
