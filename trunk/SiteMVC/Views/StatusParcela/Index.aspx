<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<RegraNegocio.ModuloBasico.StatusParcela>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Principal" runat="server">

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
                <%: Html.ActionLink("Edit", "Edit", new { id=item.id }) %> |
                <%: Html.ActionLink("Details", "Details", new { id=item.id })%> |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.id })%>
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
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

