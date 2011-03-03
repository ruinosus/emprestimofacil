<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SiteMVCTelerik.Models.ModuloBasico.VOs.PrestacaoConta>>" %>

<%@ Import Namespace="SiteMVCTelerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Listar
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>
        Listar</h2>
    <% Html.Telerik().Grid(Model)
        .Name("Grid")
        .Columns(columns =>
        {

            columns.Bound(c => c.dataprestacao).Width(100);
           
            columns.Template(c =>
           { 
                
    %>
    <%: Html.ActionLink("Visualizar Prestação de Contas", "VisualizarPrestacaoConta", "Movimentacao", new { id = c.ID }, null)%>
   
    <%
            }).Title("Ações");
        })
        .Sortable()
        .Pageable()
        .Filterable().Render();
    %>
   
</asp:Content>
