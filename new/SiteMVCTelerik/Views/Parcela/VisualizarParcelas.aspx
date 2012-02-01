<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SiteMVCTelerik.Models.ModuloBasico.VOs.Parcela>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    VisualizarParcelas
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        VisualizarParcelas</h2>
    <table>
        <tr>
   
            <th>
                data_pagamento
            </th>
            <th>
                data_vencimento
            </th>
            <th>
                ID
            </th>

            <th>
                sequencial
            </th>
            <th>
                valor
            </th>
            <th>
                valor_pago
            </th>
            <th>
                cliente
            </th>
            <th>
                vendedor
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
         
            <td>
                <%: String.Format("{0:g}", item.data_pagamento) %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.data_vencimento) %>
            </td>
            <td>
                <%: item.id %>
            </td>

            <td>
                <%: item.sequencial %>
            </td>

            <td>
                <%: item.valor %>
            </td>
            <td>
                <%: item.valor_pago %>
            </td>
            <td>
                <%: item.emprestimo.cliente.nome %>
            </td>
            <td>
                <%: item.emprestimo.usuario.nome %>
            </td>
        </tr>
        <% } %>
    </table>

        <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Marcar Todas" /> |
		    <%: Html.ActionLink("Voltar", "Index","Home") %>
        </p>
    <% } %>

</asp:Content>
