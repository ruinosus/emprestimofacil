<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SiteMVC.Models.ModuloBasico.VOs.Usuario>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Listar
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Principal" runat="server">

    <h2>Listar</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Nome
            </th>
            <th>
                Login
            </th>
            <th>
                Cpf
            </th>
            
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Alterar", "Alterar", new { id = item.ID })%> |
                <%: Html.ActionLink("Detalhar", "Detalhar", new { id = item.ID })%> |
                <%: Html.ActionLink("Excluir", "Excluir", new { id = item.ID })%>
            </td>
            <td>
                <%: item.nome %>
            </td>
            <td>
                <%: item.login %>
            </td>
            <td>
                <%: item.cpf %>
            </td>
         
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Incluir", "Incluir") %>
    </p>

</asp:Content>

