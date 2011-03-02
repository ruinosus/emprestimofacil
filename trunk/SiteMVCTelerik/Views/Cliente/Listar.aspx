<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SiteMVCTelerik.Models.ModuloBasico.VOs.Cliente>>" %>

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

            columns.Bound(c => c.nome).Width(100);
            columns.Bound(c => c.endereco_resid).Width(200);
            columns.Bound(c => c.cpf);
            columns.Template(c =>
           { 
                
    %>
    <%: Html.ActionLink("Visualizar Emprestimos", "EmprestimoCliente", "Emprestimo", new { id = c.ID }, null)%>
    |
    <%: Html.ActionLink("Alterar", "Alterar", new { id = c.ID })%>
    |
    <%: Html.ActionLink("Detalhar", "Detalhar", new { id = c.ID })%>
    <%if (SiteMVCTelerik.Models.ModuloBasico.VOs.ClasseAuxiliar.UsuarioLogado.usuariotipo_id == 1)
      {%>
    |
    <%: Html.ActionLink("Excluir", "Excluir", new { id = c.ID })%>
    <%} %>
    <%
            }).Title("Ações");
        })
        .Groupable()
        .Sortable()
        .Pageable()
        .Filterable().Render();
    %>
    <p>
        <%: Html.ActionLink("Incluir", "Incluir")%>
    </p>
</asp:Content>
