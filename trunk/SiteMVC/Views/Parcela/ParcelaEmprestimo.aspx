<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IPagedList<SiteMVC.Models.ModuloBasico.VOs.Parcela>>" %>
<%@ Import Namespace="SiteMVC"%>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ParcelaEmprestimo
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Principal" runat="server">

    <h2>ParcelaEmprestimo</h2>

    <table>
        <tr>
            <th></th>
            <th>
                data_pagamento
            </th>
            <th>
                data_vencimento
            </th>
            <th>
                emprestimo_id
            </th>
            <th>
                ID
            </th>
            <th>
                observacoes
            </th>
            <th>
                sequencial
            </th>
            <th>
                statusparcela_id
            </th>
           
            <th>
                valor
            </th>
            <th>
                valor_pago
            </th>
        </tr>
        <%
            bool entrou = false;
             %>
    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
            <%if (item.statusparcela_id == 2 && !entrou)
              {
                  entrou = true;
                  %>
                <%: Html.ActionLink("Efetuar Pagamento", "Alterar", new { id = item.ID })%> 
             
             <%} %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.data_pagamento) %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.data_vencimento) %>
            </td>
            <td>
                <%: item.emprestimo_id %>
            </td>
            <td>
                <%: item.ID %>
            </td>
            <td>
                <%: item.observacoes %>
            </td>
            <td>
                <%: item.sequencial %>
            </td>
            <td>
                <%: item.statusparcela_id %>
            </td>

            <td>
                <%: item.valor %>
            </td>
            <td>
                <%: item.valor_pago %>
            </td>
        </tr>
    
    <% } %>

    </table>
      <div class="pager">
		<%= Html.Pager(ViewData.Model.PageSize, ViewData.Model.PageNumber, ViewData.Model.TotalItemCount) %>
	</div>

</asp:Content>

