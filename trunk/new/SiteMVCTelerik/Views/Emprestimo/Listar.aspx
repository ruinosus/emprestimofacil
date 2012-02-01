<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IPagedList<SiteMVCTelerik.Models.ModuloBasico.VOs.Emprestimo>>" %>
<%@ Import Namespace="SiteMVCTelerik"%>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Listar
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Listar</h2>

    <table>
        <tr>
            <th></th>
            <th>
                cliente
            </th>
            <th>
                data_emprestimo
            </th>
            <th>
                ID
            </th>
            <th>
                juros
            </th>
            <th>
                prazos pagamento
            </th>
            <th>
                qtde_parcelas
            </th>
            
            <th>
                tipo emprestimo
            </th>
            <th>
                usuario
            </th>
            <th>
                valor
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Detalhar", "Detalhar", new { id=item.id })%> |
                <%: Html.ActionLink("Excluir", "Excluir", new { id=item.id })%>
            </td>
            <td>
                <%: item.cliente.nome %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.data_emprestimo) %>
            </td>
            <td>
                <%: item.id %>
            </td>
            <td>
                <%: item.juros %>
            </td>
            <td>
                <%: item.prazopagamento.descricao %>
            </td>
            <td>
                <%: item.qtde_parcelas %>
            </td>
           
            <td>
                <%: item.tipoemprestimo.descricao %>
            </td>
            <td>
                <%: item.usuario.nome %>
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

