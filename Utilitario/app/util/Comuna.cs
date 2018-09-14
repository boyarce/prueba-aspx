using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitario.app.util
{
    public class Comuna
    {
        private string nombre;
        private string calle;
        private string enumeracion;

        public Comuna() { }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Calle { get => calle; set => calle = value; }
        public string Enumeracion { get => enumeracion; set => enumeracion = value; }
    }
}
