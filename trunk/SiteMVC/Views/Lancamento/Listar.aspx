<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IPagedList<SiteMVC.Models.ModuloBasico.VOs.Lancamento>>" %>
<%@ Import Namespace="SiteMVC"%>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Listar
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Principal" runat="server">

    <h2>Listar</h2>

    <table>
        <tr>
            <th></th>
            <th>
                data
            </th>
            <th>
                fonte
            </th>
            <th>
                ID
            </th>
            <th>
                lancamentotipo_id
            </th>
            <th>
                observacoes
            </th>
            <th>
                outrasinfos
            </th>
         
            <th>
                usuario_id
            </th>
            <th>
                valor
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
   
                <%: Html.ActionLink("Detalhar", "Detalhar", new { id = item.ID })%> |
                <%: Html.ActionLink("Excluir", "Excluir", new { id = item.ID })%>
            </td>
            <td>
                <%: String.Format("{0:g}", item.data) %>
            </td>
            <td>
                <%: item.fonte %>
            </td>
            <td>
                <%: item.ID %>
            </td>
            <td>
                <%: item.lancamentotipo_id %>
            </td>
            <td>
                <%: item.observacoes %>
            </td>
            <td>
                <%: item.outrasinfos %>
            </td>
            
            <td>
                <%: item.usuario_id %>
            </td>
            <td>
                <%: item.valor %>
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

