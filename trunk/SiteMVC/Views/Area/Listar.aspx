<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IPagedList<SiteMVC.Models.ModuloBasico.VOs.Area>>" %>
<%@ Import Namespace="SiteMVC"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Listar
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Listar</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Descrição
            </th>
            <th>
                ID
            </th>
            <th>
                Municipio
            </th>
         
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Alterar", "Alterar", new { id = item.ID })%> |
                <%: Html.ActionLink("Detalhar", "Detalhar", new { id = item.ID })%> |
                <%: Html.ActionLink("Excluir", "Excluir", new { id=item.ID })%>
            </td>
            <td>
                <%: item.descricao %>
            </td>
            <td>
                <%: item.ID %>
            </td>
            <td>
                <%: item.municipio.nome %>
            </td>
          
        </tr>
    
    <% } %>

    </table>
    <div class="pager">
		<%= Html.Pager(ViewData.Model.PageSize, ViewData.Model.PageNumber, ViewData.Model.TotalItemCount) %>
	</div>
    <p>
        <%: Html.ActionLink("Incluir", "Incluir") %>
    </p>

</asp:Content>

