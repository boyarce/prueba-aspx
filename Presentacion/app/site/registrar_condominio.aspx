<%@ Page Title="" Language="C#" MasterPageFile="~/app/site/template/template.Master" AutoEventWireup="true" CodeBehind="registrar_condominio.aspx.cs" Inherits="Presentacion.app.site.registrar_condominio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
        <div class="row">
        <div class="col-50">
            <span>NOMBRE</span>
        </div>
        <div class="col-50">
            <asp:TextBox ID="txt_nombre" runat="server"
                value="" placeholder="Nombre">
            </asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-50">
            <span>TIPO CONDOMINIO</span>
        </div>
        <div class="col-50">
            <asp:DropDownList ID="cmb_tipo_condominio" runat="server" DataValueField="Codigo"
               DataTextField="Nombre">
            </asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-50">
            <span>CANTIDAD</span>
        </div>
        <div class="col-50">
            <asp:TextBox ID="txt_cantidad" runat="server" TextMode="Number"
                value="" placeholder="0">
            </asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-50">
            <span>FECHA INAUGURACION</span>
        </div>
        <div class="col-50">
            <asp:TextBox ID="txt_fecha_inauguracion" runat="server" TextMode="Date" >
            </asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-75">
            <span>&nbsp;</span>
        </div>
        <div class="col-25 green-button">
            <asp:Button ID="btn_create" runat="server"
                Text="CREATE"  OnClick="btn_create_Click"/>
        </div>
    </div>
    <div class="row">
        <div class="col-100">
            <asp:Label ID="lbl_mensaje" runat="server" />
        </div>
    </div>
</asp:Content>
