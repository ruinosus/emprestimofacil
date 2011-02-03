<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVC.Models.ModuloBasico.VOs.PrestacaoConta>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    IncluirPrestacaoConta
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function CallPrint(strid) {

            var prtContent = document.getElementById(strid);

            var WinPrint = window.open('', '', 'letf=0,top=0,width=1,height=1,toolbar=0,scrollbars=0,status=0');

            WinPrint.document.write(prtContent.innerHTML);

            WinPrint.document.close();

            WinPrint.focus();

            WinPrint.print();

            WinPrint.close();

            prtContent.innerHTML = strOldOne;

        }
    </script>
    <h2>
        Prestacao de Contas do dia : <%:SiteMVC.Models.ModuloBasico.VOs.ClasseAuxiliar.DataPrestacaoContaSelecionada.ToString("dd/MM/yyyy") %></h2>
    <% using (Html.BeginForm())
       { %>
    <div id="divPrint">
        <fieldset>
            <legend>Prestacao de Contas</legend>
            <table>
                <tr>
                    <td>
                        Valores Recebidos dos Clientes:
                    </td>
                    <td>
                        {valorRecebidoCliente}
                    </td>
                </tr>
                <tr>
                    <td>
                        Valores Emprestados:
                    </td>
                    <td>
                        {valorEmprestados}
                    </td>
                </tr>
                <tr>
                    <td>
                        Valores Devolvidos:
                    </td>
                    <td>
                        {valorDevolvido}
                    </td>
                </tr>
            </table>
        </fieldset>
        <fieldset>
            <legend>Lancamentos</legend>
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
                <%
           List<SiteMVC.Models.ModuloBasico.VOs.Emprestimo> emprestimos = (List<SiteMVC.Models.ModuloBasico.VOs.Emprestimo>)ViewData["emprestimos"];
            
                %>
                <% foreach (var item in emprestimos)
                   { %>
                <tr>
                    <td>
                        <%: Html.ActionLink("Visualizar Parcelas", "ParcelaEmprestimo", "Parcela", new { id = item.ID },null)%>
                        |
                        <%: Html.ActionLink("Imprimir Parcelas", "ImprimirParcelas", "Parcela", new { id = item.ID },null)%>
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
            <p>
                <%: Html.ActionLink("Criar Emprestimo", "Incluir","Emprestimo") %>
            </p>
        </fieldset>
    </div>
    <input type="image" src="../../Content/ui-lightness/images/impressora.jpg" onclick="CallPrint('divPrint');"
        style="width: 40px; height: 40px" />
    <%} %>
</asp:Content>
