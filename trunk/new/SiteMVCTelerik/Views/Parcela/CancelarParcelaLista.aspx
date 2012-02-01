<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SiteMVCTelerik.Models.ModuloBasico.VOs.Parcela>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Cancelar Parcela
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Cancelar Parcelas</h2>
    <% Html.Telerik().Grid(Model)
        .Name("Grid")
        .Columns(columns =>
        {
            columns.Bound(c => c.id).Width(100);
            columns.Bound(c => c.data_pagamento).Width(100);
            columns.Bound(c => c.valor_pago).Width(200);
            columns.Template(c =>
           { 
                
    %>
    <%: Html.ActionLink("Cancelar Parcela", "CancelarParcela", "Parcela", new { id = c.id }, null)%>
    |
    <%if (SiteMVCTelerik.Models.ModuloBasico.VOs.ClasseAuxiliar.UsuarioLogado.usuariotipo_id == 1)
      {%>
    
    <%: Html.ActionLink("Excluir", "Excluir","Parcela", new { id = c.id }, null)%>
    <%} %>
    <%
           }).Title("Ações");
        })
        .Groupable()
        .Sortable()
        .Pageable()
        .Filterable().Render();
    %>
</asp:Content>
