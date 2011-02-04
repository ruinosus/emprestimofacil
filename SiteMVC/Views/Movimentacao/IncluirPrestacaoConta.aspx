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
        Prestacao de Contas do dia :
        <%:SiteMVC.Models.ModuloBasico.VOs.ClasseAuxiliar.DataPrestacaoContaSelecionada.ToString("dd/MM/yyyy") %></h2>
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
                        <%: Convert.ToInt32( ViewData["totalParcelas"].ToString()) %>
                    </td>
                </tr>
                <tr>
                    <td>
                        Valores Emprestados:
                    </td>
                    <td>
                        <%: Convert.ToInt32(ViewData["totalEmprestimos"].ToString())%>
                    </td>
                </tr>
                <tr>
                    <td>
                        Peguei com a empresa:
                    </td>
                    <td>
                       <%: Convert.ToInt32(ViewData["totalLancamentos"].ToString())%>
                    </td>
                </tr>
            </table>
            <%
                
           float valorEntradas = 0,valorSaida = 0;
           valorEntradas = Convert.ToInt32(ViewData["totalParcelas"].ToString());
           valorSaida = Convert.ToInt32(ViewData["totalEmprestimos"].ToString()) + Convert.ToInt32(ViewData["totalLancamentos"].ToString());
                 %>
            <table>
            <tr>
                <th>
                    Total Valor Entrada
                </th>
                <th>
                    Total Valor Saída
                </th>
                <th>
                    Total do dia
                </th>
            </tr>
            <tr>
                <td>
                    <%: valorEntradas%>
                </td>
                <td>
                     <%: valorSaida%>
                </td>
                <td>
                    <%:valorEntradas - valorSaida %>
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
                        cliente
                    </th>
                    <th>
                        ID
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
                        
                        <%: Html.ActionLink("Imprimir Parcelas", "ImprimirParcelas", "Parcela", new { id = item.ID },null)%>
                    </td>
                    <td>
                        <%: item.cliente.nome %>
                    </td>
                    <td>
                        <%: item.ID %>
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
        <fieldset>
            <legend>Despesas</legend>
            <table>
                <tr>
                    <th>
                        ID
                    </th>
                    <th>
                        Descriçao
                    </th>
                    <th>
                        valor
                    </th>
                </tr>
                <%
           List<SiteMVC.Models.ModuloBasico.VOs.Despesa> despesas = (List<SiteMVC.Models.ModuloBasico.VOs.Despesa>)ViewData["despesas"];
                %>
                <% foreach (var item in despesas)
                   { %>
                <tr>
                    <td>
                        <%: item.ID %>
                    </td>
                    <td>
                        <%: item.despesatipo.descricao%>
                    </td>
                    <td>
                        <%: item.valor %>
                    </td>
                </tr>
                <% } %>
            </table>
            <p>
                <%: Html.ActionLink("Incluir Despesas", "Incluir","Despesa")%>
            </p>
        </fieldset>
        <fieldset>
            <legend>Peguei com a Empresa</legend>
            <table>
                <tr>
                    <th>
                        data
                    </th>
                    <th>
                        ID
                    </th>
                    <th>
                        lancamentotipo
                    </th>
                    <th>
                        usuario
                    </th>
                    <th>
                        valor
                    </th>
                </tr>
                <%
           List<SiteMVC.Models.ModuloBasico.VOs.Lancamento> lancamentos = (List<SiteMVC.Models.ModuloBasico.VOs.Lancamento>)ViewData["lancamentos"];
                %>
                <% foreach (var item in lancamentos)
                   { %>
                <tr>
                    <td>
                        <%: String.Format("{0:g}", item.data) %>
                    </td>
                    <td>
                        <%: item.ID %>
                    </td>
                    <td>
                        <%: item.lancamentotipo.descricao %>
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
            <p>
                <%: Html.ActionLink("Peguei com a empresa", "Incluir","Movimentacao")%>
            </p>
        </fieldset>
    </div>
    <%--<p>
        <input type="submit" value="Confirmar" />
    </p>--%>
    <input alt="Clique aqui para imprimir" type="image" src="../../Content/ui-lightness/images/impressora.jpg"
        onclick="CallPrint('divPrint');" style="width: 40px; height: 40px" />
    <%} %>
</asp:Content>
