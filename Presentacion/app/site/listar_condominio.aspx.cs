using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitario.app.util;

namespace Presentacion.app.site
{
    public partial class listar_condominio : System.Web.UI.Page
    {
        private List<Condominio> condominios;
        protected void Page_Load(object sender, EventArgs e)
            {
                cargarCondominios();
                if (!IsPostBack)
                {
                    refreshTable();
                }
            }


        private void refreshTable()
            {
                tbl_condominios.DataSource = condominios;
                tbl_condominios.DataBind();
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

        protected void tbl_condominios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Obteniendo Fila seleccionada
            GridViewRow row = tbl_condominios.Rows[e.RowIndex];
            //Obteniendo nombre del condominio de la fila
            string nombre = row.Cells[0].Text;
            //Obteniendo objeto condominio que debe ser borrado de la lista
            Condominio deleteCondominio = condominios.FirstOrDefault(
                condominio => condominio.Nombre == nombre);
            //Borrando condominio de la lista
            condominios.Remove(deleteCondominio);
            //Refrescar tabla
            refreshTable();
        }

        protected void tbl_condominios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Obteniendo Fila seleccionada
            GridViewRow row = tbl_condominios.Rows[e.NewEditIndex];
            //Obteniendo Condominio de la fila
            string nombre = row.Cells[0].Text;
            string tipoCondominioS = row.Cells[1].Text;
            string cantidad = row.Cells[2].Text;
            string fechaInauguracion = row.Cells[3].Text;
            //Creando objeto con información
            Condominio updateCondominio = new Condominio();
            updateCondominio.Cantidad = Int32.Parse(cantidad);
            updateCondominio.FechaInauguracion = DateTime.Parse(fechaInauguracion);
            updateCondominio.Nombre = nombre;
            TipoCondominio tipoCondominio = new TipoCondominio();
            tipoCondominio.Nombre = tipoCondominioS;
            updateCondominio.TipoCondominio = tipoCondominio;

            //Agregando condominio a variable de session
            Session["updateCondominio"] = updateCondominio;
            Response.Redirect("registrar_condominio.aspx");
        }
    }
    
}