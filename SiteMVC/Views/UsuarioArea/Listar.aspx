<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IPagedList<SiteMVC.Models.ModuloBasico.VOs.UsuarioArea>>" %>
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
                area_id
            </th>
            <th>
                ID
            </th>
            <th>
                timeCreated
            </th>
            <th>
                timeUpdated
            </th>
            <th>
                usuario_id
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Selecionar", "SelecionarArea", new { id = item.ID })%>
            </td>
            <td>
                <%: item.area_id %>
            </td>
            <td>
                <%: item.ID %>
            </td>
            <td>
                <%: item.timeCreated %>
            </td>
            <td>
                <%: item.timeUpdated %>
            </td>
            <td>
                <%: item.usuario_id %>
            </td>
        </tr>
    
    <% } %>

    </table>

   <div class="pager">
		<%= Html.Pager(ViewData.Model.PageSize, ViewData.Model.PageNumber, ViewData.Model.TotalItemCount) %>
	</div>

</asp:Content>

