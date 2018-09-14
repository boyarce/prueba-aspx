using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitario.app.util
{
    public class Empleado
    {
        private string nombre;
        private string apa;
        private string ama;
        private string remuneracion;
        private string telefono;
        private string email;
        private DateTime fecha;
        private TipoEmpleado tipoEmpleado;
        private Comuna direccion;

        public Empleado() { }

        public string Apa { get => apa; set => apa = value; }
        public string Ama { get => ama; set => ama = value; }
        public string Remuneracion { get => remuneracion; set => remuneracion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public TipoEmpleado TipoEmpleado { get => tipoEmpleado; set => tipoEmpleado = value; }
        public Comuna Direccion { get => direccion; set => direccion = value; }
    }
}
