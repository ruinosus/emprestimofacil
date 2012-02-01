<%@ Import Namespace = "System.Data" %>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SiteMVCTelerik.Models.ModuloBasico.VOs.StatusParcela>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            <th>
                descricao
            </th>
            <th>
                id
            </th>
            <th>
                timeCreated
            </th>
            <th>
                timeUpdated
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Alterar", "Alterar", new { id = item.id })%> |
                <%: Html.ActionLink("Detalhar", "Detalhar", new { id = item.id })%> |
                <%: Html.ActionLink("Excluir", "Excluir", new { id = item.id })%>
            </td>
            <td>
                <%: item.descricao %>
            </td>
            <td>
                <%: item.id %>
            </td>
            <td>
                <%: item.timeCreated %>
            </td>
            <td>
                <%: item.timeUpdated %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Incluir", "Incluir") %>
    </p>

</asp:Content>

