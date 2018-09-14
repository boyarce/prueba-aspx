using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitario.app.util
{
    public class Condominio
    {
        private string nombre;

        private TipoCondominio tipoCondominio;
        private int cantidad;
        private DateTime fechaInauguracion;

        public Condominio()
        {

        }

        public string Nombre
        {

            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }

        public TipoCondominio TipoCondominio
        {

            get
            {
                return tipoCondominio;
            }
            set
            {
                tipoCondominio = value;
            }
        }

        public int Cantidad
        {

            get
            {
                return cantidad;
            }
            set
            {
                cantidad = value;
            }
        }

        public DateTime FechaInauguracion
        {

            get
            {
                return fechaInauguracion;
            }
            set
            {
                fechaInauguracion = value;
            }
        }
    }
}
