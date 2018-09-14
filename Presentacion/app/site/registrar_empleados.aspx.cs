using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitario.app.util;

namespace Presentacion.app.site
{
    public partial class registrar_empleados : System.Web.UI.Page
    {
        private List<Empleado> empleados;
        private List<TipoEmpleado> tipoEmpleados;
        private List<Comuna> comunas;
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarEmpleados();
            if (!IsPostBack) {
                cargarTipoEmpleados();

                Empleado updateEmpleado = (Empleado)Session["updateEmpleado"];

                if (updateEmpleado != null)
                {
                    txt_remuneracion.Text = updateEmpleado.Remuneracion.ToString();
                    //Se debe setear siempre con formato yyyy-MM-dd por HTML 5
                    txt_fecha.Text = updateEmpleado.Fecha.ToString("yyyy-MM-dd");
                    txt_fecha.DataBind();
                    txt_nombres.Text = updateEmpleado.Nombre;
                    //deshabilitando nombre
                    txt_nombres.Enabled = false;
                    cmb_tipoEmpleado.Items.FindByText(updateEmpleado.TipoEmpleado.Nombre).Selected = true;
                    lbl_mensaje.Text = "EDITANDO empleado";
                    lbl_mensaje.CssClass = "alert alert-success";
                }
            }
        }

        public void cargarTipoEmpleados()
        {
            TipoEmpleado jefe = new TipoEmpleado();
            jefe.Codigo = "01";
            jefe.Nombre = "JEFE TI";
            TipoEmpleado programador = new TipoEmpleado();
            programador.Codigo = "02";
            programador.Nombre = "PROGRAMADOR";
            TipoEmpleado cajera = new TipoEmpleado();
            cajera.Codigo = "03";
            cajera.Nombre = "CAJERA";
            TipoEmpleado supervisor = new TipoEmpleado();
            supervisor.Codigo = "04";
            supervisor.Nombre = "SUPERVISOR";

            tipoEmpleados = new List<TipoEmpleado>();
            tipoEmpleados.Add(jefe);
            tipoEmpleados.Add(programador);
            tipoEmpleados.Add(cajera);
            tipoEmpleados.Add(supervisor);
            cmb_tipoEmpleado.DataSource = tipoEmpleados;
            cmb_tipoEmpleado.DataBind();
            Session["tipoEmpleados"] = tipoEmpleados;


        }

        private void cargarEmpleados()
        {

            List<Empleado> empleadosSession = (List<Empleado>)Session["empleados"];

            if (empleadosSession != null)
            {

                empleados = empleadosSession;
            }
            else
            {
                empleados = new List<Empleado>();
            }
        }

        protected void btn_create_Click(object sender, EventArgs e)
        {
            try
            {
                Empleado newEmpleado = new Empleado();
                newEmpleado.Nombre = txt_nombres.Text;
                newEmpleado.Apa = txt_apa.Text;
                newEmpleado.Ama = txt_ama.Text;
                newEmpleado.Telefono = txt_telefono.Text;
                newEmpleado.Remuneracion = txt_remuneracion.Text;
                newEmpleado.Fecha = DateTime.Parse(txt_fecha.Text);
                Comuna newComuna = new Comuna();
                newComuna.Nombre = txt_comuna.Text;
                newComuna.Calle = txt_direccion.Text;
                newComuna.Enumeracion = txt_numero.Text;
                TipoEmpleado tipoEmpleadoSelected = ((List<TipoEmpleado>)Session["tipoEmpleados"]).
                    FirstOrDefault(tipoEmpleado => tipoEmpleado.Codigo == cmb_tipoEmpleado.SelectedValue);
                TipoEmpleado newTipoEmpleados = new TipoEmpleado();
                newTipoEmpleados.Codigo = tipoEmpleadoSelected.Codigo;
                newTipoEmpleados.Nombre = tipoEmpleadoSelected.Nombre;
                newEmpleado.TipoEmpleado = tipoEmpleadoSelected;
                newEmpleado.Direccion = newComuna;
                List<Empleado> empleadoSession = (List<Empleado>)Session["empleados"];
                List<Empleado> updateEmpleado = (List<Empleado>)Session["updateEmpleado"];

                if (updateEmpleado == null)
                {
                    if (empleadoSession != null)
                    {

                        empleados = empleadoSession;
                        empleados.Add(newEmpleado);
                    }
                    else
                    {

                        empleados = new List<Empleado>();
                        empleados.Add(newEmpleado);
                    }
                    lbl_mensaje.Text = "Empleado registrado correctamente";
                }
                else {

                    empleados.FirstOrDefault(
                        empleado=>empleado.Nombre==newEmpleado.Nombre).TipoEmpleado=newEmpleado.TipoEmpleado;
                    empleados.FirstOrDefault(
                        empleado => empleado.Nombre == newEmpleado.Nombre).Remuneracion = newEmpleado.Remuneracion;
                    empleados.FirstOrDefault(
                       empleado => empleado.Nombre == newEmpleado.Nombre).Fecha = newEmpleado.Fecha;

                    lbl_mensaje.Text = "Actualizacion correcta";

                    Session["updateEmpleado"] = null;
                    txt_nombres.Enabled = true;
                }

                Session["empleados"] = empleados;
                lbl_mensaje.CssClass = "alert alert-success";
                clear();
            }
            catch (Exception ex)
            {
                lbl_mensaje.Text = ex.Message;
                lbl_mensaje.CssClass = "alert alert-danger";
                throw;
            }

            
        }

        public void clear()
        {
            txt_nombres.Text = "";
            txt_apa.Text = "";
            txt_ama.Text = "";
            txt_comuna.Text = "";
            txt_direccion.Text = "";
            txt_numero.Text = "";
            txt_telefono.Text = "";

        }
    }
}