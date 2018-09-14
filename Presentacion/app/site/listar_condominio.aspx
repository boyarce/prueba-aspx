<%@ Page Title="" Language="C#" MasterPageFile="~/app/site/template/template.Master" AutoEventWireup="true" CodeBehind="listar_condominio.aspx.cs" Inherits="Presentacion.app.site.listar_condominio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
        <div class="row">
        <asp:GridView ID="tbl_condominios" runat="server"
            OnRowDeleting="tbl_condominios_RowDeleting"
            OnRowEditing="tbl_condominios_RowEditing"
            AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="NOMBRE" DataField="Nombre" />
                <asp:BoundField HeaderText="TIPO CONDOMINIO" DataField="TipoCondominio.Nombre" />
                <asp:BoundField HeaderText="CANTIDAD" DataField="Cantidad" />
                <asp:BoundField HeaderText="FECHA INAUGURACION" DataField="FechaInauguracion"
                    DataFormatString="{0:dd/MM/yyyy}"/>
                <asp:TemplateField HeaderText="" ItemStyle-CssClass="skyblue-button">
                    <ItemTemplate>
                        <asp:Button ID="btn_edit" runat="server"
                            Text="EDIT" CommandName="Edit" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="" ItemStyle-CssClass="red-button">
                    <ItemTemplate>
                        <asp:Button ID="btn_delete" runat="server"
                            Text="DELETE" CommandName="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
