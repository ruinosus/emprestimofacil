<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IPagedList<SiteMVCTelerik.Models.ModuloBasico.VOs.Emprestimo>>" %>

<%@ Import Namespace="SiteMVCTelerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    EmprestimoCliente
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Emprestimos do Cliente:
        <%:SiteMVCTelerik.Models.ModuloBasico.VOs.ClasseAuxiliar.ClienteSelecionado.nome %></h2>
    <table>
        <tr>
            <th>
            </th>
            <th>
                cliente_id
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
                prazospagamento_id
            </th>
            <th>
                qtde_parcelas
            </th>
           
            <th>
                tipoemprestimo_id
            </th>
            <th>
                usuario_id
            </th>
            <th>
                valor
            </th>
            <th>
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%: Html.ActionLink("Visualizar Parcelas", "ParcelaEmprestimo", "Parcela", new { id = item.id },null)%>
                <%if (!item.EmprestimoQuitado)
                  {%>
                |
                <%: Html.ActionLink("Imprimir Parcelas", "ImprimirParcelas", "Parcela", new { id = item.id }, null)%>
                <%} %>

                 <%if (item.NenhumaParcelaPaga && item.data_emprestimo.Date.Equals(SiteMVCTelerik.Models.ModuloBasico.VOs.ClasseAuxiliar.DataSelecionada.Date))
                  {%>
                |
                <%: Html.ActionLink("Excluir Emprestimo", "Excluir", "Emprestimo", new { id = item.id }, null)%>
                <%} %>

                <%-- <%: Html.ActionLink("Edit", "Edit", new { id=item.id }) %> |
                <%: Html.ActionLink("Details", "Details", new { id=item.id })%> |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.id })%>--%>
            </td>
            <td>
                <%: item.cliente_id %>
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
                <%: item.prazospagamento_id %>
            </td>
            <td>
                <%: item.qtde_parcelas %>
            </td>
           
            <td>
                <%: item.tipoemprestimo_id %>
            </td>
            <td>
                <%: item.usuario_id %>
            </td>
            <td>    
                <%: item.valor %>
            </td>
            <td>
                <%if (item.EmprestimoQuitado)
                  {%>
                emprestimo já quitado.
                <%} %>
            </td>
        </tr>
        <% } %>
    </table>
    <div class="pager">
        <%= Html.Pager(ViewData.Model.PageSize, ViewData.Model.PageNumber, ViewData.Model.TotalItemCount) %>
    </div>
    <p>
        <%: Html.ActionLink("Criar Emprestimo", "IncluirEmprestimoCliente") %>
    </p>
</asp:Content>
