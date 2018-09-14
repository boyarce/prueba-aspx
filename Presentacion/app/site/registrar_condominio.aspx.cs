using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitario.app.util;

namespace Presentacion.app.site
{
    public partial class registrar_condominio : System.Web.UI.Page
    {
        private List<Condominio> condominios;
        private List<TipoCondominio> tipoCondominios;

        protected void Page_Load(object sender, EventArgs e)
        {
            //cargando condominios existentes en sessión
            cargarCondominios();

            //Código ejecutado solo si la página web es llamada por otra página
            if (!IsPostBack)
            {
                //Cargando tipo de condominios
                cargarTipoCondominios();

                //Condominio que se debe actualizar
                Condominio updateCondominio = (Condominio)Session["updateCondominio"];

                if (updateCondominio != null) {
                    txt_cantidad.Text = updateCondominio.Cantidad.ToString();
                    //Se debe setear siempre con formato yyyy-MM-dd por HTML 5
                    txt_fecha_inauguracion.Text = updateCondominio.FechaInauguracion.ToString("yyyy-MM-dd");
                    txt_fecha_inauguracion.DataBind();
                    txt_nombre.Text = updateCondominio.Nombre;
                    //deshabilitando nombre
                    txt_nombre.Enabled = false;
                    cmb_tipo_condominio.Items.FindByText(updateCondominio.TipoCondominio.Nombre).Selected = true;
                    lbl_mensaje.Text = "EDITANDO CONDOMINIO";
                    lbl_mensaje.CssClass = "skyblue-message";
                }
            }
        }

        /// <summary>
        /// Método encargado de cargar los tipos de condominios
        /// </summary>
        public void cargarTipoCondominios()
        {

            TipoCondominio departamento = new TipoCondominio();
            departamento.Codigo = "01";
            departamento.Nombre = "DEPARTAMENTO";

            TipoCondominio casa = new TipoCondominio();
            casa.Codigo = "02";
            casa.Nombre = "CASA";

            TipoCondominio mixto = new TipoCondominio();
            mixto.Codigo = "03";
            mixto.Nombre = "MIXTO";

            tipoCondominios = new List<TipoCondominio>();
            tipoCondominios.Add(departamento);
            tipoCondominios.Add(casa);
            tipoCondominios.Add(mixto);
            cmb_tipo_condominio.DataSource = tipoCondominios;
            cmb_tipo_condominio.DataBind();
            Session["tipoCondominios"] = tipoCondominios;
        }

        /// <summary>
        /// Método encargado de cargar condominios siempre que
        /// se encuentre en sessión
        /// </summary>
        private void cargarCondominios()
        {

            List<Condominio> condominiosSession = (List<Condominio>)Session["condominios"];

            if (condominiosSession != null)
            {

                condominios = condominiosSession;
            }
            else
            {
                condominios = new List<Condominio>();
            }
        }

        /// <summary>
        /// Método encargado de crear un condominio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_create_Click(object sender, EventArgs e)
        {
            try
            {
                validate();
                //Creación de nuevo condominio obteniendo datos desde el formulario
                Condominio newCondominio = new Condominio();
                newCondominio.Nombre = txt_nombre.Text;
                newCondominio.Cantidad = Int32.Parse(txt_cantidad.Text);
                TipoCondominio tipoCondominioSelected = ((List<TipoCondominio>)Session["tipoCondominios"]).
                    FirstOrDefault
                    (tipoCondominio => tipoCondominio.Codigo == cmb_tipo_condominio.SelectedValue);
                TipoCondominio newTipoCondominio = new TipoCondominio();
                newTipoCondominio.Codigo = tipoCondominioSelected.Codigo;
                newTipoCondominio.Nombre = tipoCondominioSelected.Nombre;
                newCondominio.TipoCondominio = newTipoCondominio;
                newCondominio.FechaInauguracion = DateTime.Parse(txt_fecha_inauguracion.Text);
                
                //Verificando si lista de condominios existe en session
                List<Condominio> condominiosSession = (List<Condominio>)Session["condominios"];


                //Condominio que se debe actualizar
                Condominio updateCondominio = (Condominio)Session["updateCondominio"];

                if (updateCondominio == null)
                {
                    if (condominiosSession != null)
                    {

                        condominios = condominiosSession;
                        condominios.Add(newCondominio);
                    }
                    else
                    {
                        condominios = new List<Condominio>();
                        condominios.Add(newCondominio);
                    }

                    lbl_mensaje.Text = "Condominio creado de forma correcta";
                }
                else {
                    condominios.FirstOrDefault(
                        condominio => condominio.Nombre == 
                        newCondominio.Nombre).TipoCondominio = newCondominio.TipoCondominio;
                    condominios.FirstOrDefault(
                        condominio => condominio.Nombre == 
                        newCondominio.Nombre).Cantidad = newCondominio.Cantidad;
                    condominios.FirstOrDefault(
                        condominio => condominio.Nombre == newCondominio.Nombre).FechaInauguracion = 
                        newCondominio.FechaInauguracion;

                    lbl_mensaje.Text = "Condominio actualizado de forma correcta";
                    //Borrar Condominio en sessión
                    Session["updateCondominio"] = null;
                    //Habilitando nombre
                    txt_nombre.Enabled = true;
                }

                Session["condominios"] = condominios;
                lbl_mensaje.CssClass = "green-message";

                clear();
            }
            catch (Exception ex) {
                //Escribimos los errores del formulario en label de mensaje
                lbl_mensaje.Text = ex.Message;
                lbl_mensaje.CssClass = "red-message";
            }

        }

        /// <summary>
        /// Método encargado de limpiar formulario
        /// </summary>
        public void clear() {
            txt_cantidad.Text = "";
            txt_fecha_inauguracion.Text = "";
            txt_nombre.Text = "";
        }

        /// <summary>
        /// Método encargado de validar formulario
        /// </summary>
        public void validate() {

            string error = "";

            if ("".Equals(txt_nombre.Text)) {

                error = error + "<p>- Debe ingresar información en campo Nombre </p>";
            }
            else if (txt_nombre.Text.Length > 20) {
                error = error + "<p>- Nombre debe poseer máximo 20 caracteres</p>";
            }

            if ("".Equals(txt_cantidad.Text))
            {

                error = error + "<p>- Debe ingresar información en campo Cantidad </p>";
            }
            else if ("0".Equals(txt_cantidad.Text)) {
                error = error + "<p>- Cantidad debe ser mayor a 0</p>";
            }

            if ("".Equals(txt_fecha_inauguracion.Text))
            {

                error = error + "<p>- Debe ingresar información en campo Fecha de Inauguración </p>";
            }
            else if (DateTime.Parse("01-01-1990").CompareTo(DateTime.Parse(txt_fecha_inauguracion.Text)) > 0) {
                error = error + "<p>- Fecha de Inauguración debe ser mayor o igual a 01-01-1990</p>";
            }

            if (!"".Equals(error)) {
                throw new Exception(error);
            }
        }
    }
}