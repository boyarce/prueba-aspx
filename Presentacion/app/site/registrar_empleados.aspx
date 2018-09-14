<%@ Page Title="" Language="C#" MasterPageFile="~/app/site/template/template.Master" AutoEventWireup="true" CodeBehind="registrar_empleados.aspx.cs" Inherits="Presentacion.app.site.registrar_empleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="container">
        <h1 class="text-center">Registro de empleados</h1>
        <br/>
        <div class="row">
            <div class="col-sm-2">
                <span>NOMBRES</span>
            </div>
            <div class="col-sm-4">
                <asp:TextBox ID="txt_nombres" runat="server" required="required" value="" MaxLength="18" placeholder="NOMBRES" CssClass="form-control form-control-sm"></asp:TextBox>
            </div>                    
        </div>
        <br/>    
        <div class="row">
            <div class="col-sm-2">
                <span>APELLIDO PATERNO</span>
            </div>
            <div class="col-sm-4">
                <asp:TextBox ID="txt_apa" runat="server" required="required" MaxLength="60"  value="" placeholder="APELLIDO PATERNO" CssClass="form-control form-control-sm"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
             <div class="col-sm-2">
                <span>APELLIDO MATERNO</span>
            </div>
            <div class="col-sm-4">
                <asp:TextBox ID="txt_ama" runat="server" required="required" MaxLength="60"  value="" placeholder="APELLIDO MATERNO" CssClass="form-control form-control-sm"></asp:TextBox>
            </div>
        </div>
        <br/>
        <div class="row">
            <div class="col-sm-2">
                <span>TIPO EMPLEADO</span>
            </div>
            <div class="col-sm-4">
                <asp:DropDownList ID="cmb_tipoEmpleado" runat="server" 
                    DataValueField="codigo" DataTextField="nombre" CssClass="btn btn-primary dropdown-toggle"></asp:DropDownList>
            </div>
        </div>
        <br />
        <div class="row">
             <div class="col-sm-2">
                <span>TELEFONO</span>
            </div>
            <div class="col-sm-4">
                <asp:TextBox ID="txt_telefono" runat="server" TextMode="Number" MaxLength="9"  value="" placeholder="TELEFONO" CssClass="form-control form-control-sm"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
             <div class="col-sm-2">
                <span>REMUNERACION</span>
            </div>
            <div class="col-sm-4">
                <asp:TextBox ID="txt_remuneracion" runat="server" TextMode="Number" MaxLength="9"  value="" placeholder="TELEFONO" CssClass="form-control form-control-sm"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
             <div class="col-sm-2">
                <span>FECHA NACIMIENTO</span>
            </div>
            <div class="col-sm-4">
                <asp:TextBox ID="txt_fecha" runat="server" TextMode="Date" value="" placeholder="dd/mm/yyy" CssClass="form-control form-control-sm"></asp:TextBox>
            </div>
        </div>
         <br />
        <div class="row">
             <div class="col-sm-2">
                <span>CALLE</span>
            </div>
            <div class="col-sm-4">
                <asp:TextBox ID="txt_direccion" runat="server" required="required" MaxLength="100"  value="" placeholder="CALLE" CssClass="form-control form-control-sm"></asp:TextBox>
            </div>
            <div class="col-sm-2">
                <span>NUMERACION</span>
            </div>
            <div class="col-sm-4">
                <asp:TextBox ID="txt_numero" runat="server" required="required" MaxLength="9"  value="" placeholder="NUMERACION" CssClass="form-control form-control-sm"></asp:TextBox>
            </div>
            <div class="col-sm-2">
                <span>COMUNA</span>
            </div>
            <div class="col-sm-4">
                <asp:TextBox ID="txt_comuna" runat="server" required="required" MaxLength="200"  value="" placeholder="COMUNA" CssClass="form-control form-control-sm"></asp:TextBox>
            </div>
        </div>
        <br/>
        <div class="row">
             <div class="col-sm-2">
                <span>EMAIL</span>
            </div>
            <div class="col-sm-4">
                <asp:TextBox ID="txt_email" runat="server" required="required" TextMode="Email" value="" placeholder="EMAIL@MAIL.COM" CssClass="form-control form-control-sm"></asp:TextBox>
            </div>
        </div>
        <br/>
        <div class="row">
            <div class="col-sm-2">
                <span>&nbsp;</span>
            </div>
            <div class="col-sm-4">
                <asp:Button ID="btn_create" runat="server" text="CREATE" OnClick="btn_create_Click" CssClass="btn btn-primary" />
            </div>
        </div>
        <br />
        <div class="row">
        <div class="col-sm-6">
            <asp:Label ID="lbl_mensaje" runat="server" />
        </div>
    </div>
    </div>
</asp:Content>
