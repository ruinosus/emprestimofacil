﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IPagedList<SiteMVC.Models.ModuloBasico.VOs.Emprestimo>>" %>
<%@ Import Namespace="SiteMVC"%>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	EmprestimoCliente
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Principal" runat="server">

    <h2>Emprestimos do Cliente: <%:SiteMVC.Models.ModuloBasico.VOs.ClasseAuxiliar.ClienteSelecionado.nome %></h2>

    <table>
        <tr>
            <th></th>
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
                timeCreated
            </th>
            <th>
                timeUpdated
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
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                 <%: Html.ActionLink("Visualizar Parcelas", "ParcelaEmprestimo", "Parcela", new { id = item.ID },null)%> |
               <%-- <%: Html.ActionLink("Edit", "Edit", new { id=item.ID }) %> |
                <%: Html.ActionLink("Details", "Details", new { id=item.ID })%> |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.ID })%>--%>
            </td>
            <td>
                <%: item.cliente_id %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.data_emprestimo) %>
            </td>
            <td>
                <%: item.ID %>
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
                <%: item.timeCreated %>
            </td>
            <td>
                <%: item.timeUpdated %>
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

