﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitario.app.util
{
    public class TipoCondominio
    {
        private string codigo;
        private string nombre;

        public TipoCondominio()
        {

        }

        public string Codigo
        {

            get
            {
                return codigo;
            }
            set
            {
                codigo = value;
            }
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
    }
}
