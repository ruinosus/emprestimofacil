<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

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
        <%:((DateTime)ViewData["dataSelecionada"]).ToString("dd/MM/yyyy")%></h2>
    <% using (Html.BeginForm())
       { %>
    <div id="divPrint">
        <fieldset>
            <legend>Prestacao de Contas</legend>
            <%
                
           decimal valorEntradas = 0, valorSaida = 0;


           valorEntradas = Convert.ToDecimal(ViewData["totalParcelas"].ToString()) + Convert.ToDecimal(ViewData["totalLancamentos"].ToString());
           valorSaida = Convert.ToDecimal(ViewData["totalEmprestimos"].ToString()) + Convert.ToDecimal(ViewData["totalDespesas"].ToString());
            %>
            <table width="100%">
                <tr>
                    <th colspan="4">
                        Entradas
                    </th>
                </tr>
                <tr>
                    <td>
                        Clientes:
                    </td>
                    <td>
                        <%: Convert.ToDecimal(ViewData["totalParcelas"].ToString())%>
                    </td>
                    <td>
                        Lançamentos:
                    </td>
                    <td>
                        <%: Convert.ToDecimal(ViewData["totalEmprestimos"].ToString())%>
                    </td>
                </tr>
                <tr>
                    <td>
                        Empresa:
                    </td>
                    <td>
                        <%: Convert.ToDecimal(ViewData["totalLancamentos"].ToString())%>
                    </td>
                    <td>
                        Despesas
                    </td>
                    <td>
                        <%: Convert.ToDecimal(ViewData["totalDespesas"].ToString().Replace(",", "."))%>
                    </td>
                </tr>
                <tr>
                    <td>
                        Total Entrada:
                    </td>
                    <td>
                        <%: valorEntradas%>
                    </td>
                    <td>
                        Total Saidas:
                    </td>
                    <td>
                        <%: valorSaida%>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        Total do dia:
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
                        valor
                    </th>
                </tr>
                <%
           List<SiteMVCTelerik.Models.ModuloBasico.VOs.Emprestimo> emprestimos = (List<SiteMVCTelerik.Models.ModuloBasico.VOs.Emprestimo>)ViewData["emprestimos"];
            
                %>
                <% foreach (var item in emprestimos)
                   { %>
                <tr>
                    <td>
                    </td>
                    <td>
                        <%: item.cliente.nome %>
                    </td>
                    <td>
                        <%: item.valor %>
                    </td>
                </tr>
                <% } %>
            </table>
        </fieldset>
        <fieldset>
            <legend>Despesas</legend>
            <table>
                <tr>
                    <th>
                        Descriçao
                    </th>
                    <th>
                        valor
                    </th>
                </tr>
                <%
           List<SiteMVCTelerik.Models.ModuloBasico.VOs.Despesa> despesas = (List<SiteMVCTelerik.Models.ModuloBasico.VOs.Despesa>)ViewData["despesas"];
                %>
                <% foreach (var item in despesas)
                   { %>
                <tr>
                    <td>
                        <%: item.despesatipo.descricao%>
                    </td>
                    <td>
                        <%: item.valor %>
                    </td>
                </tr>
                <% } %>
            </table>
        </fieldset>
        <fieldset>
            <legend>Peguei com a Empresa</legend>
            <table>
                <tr>
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
           List<SiteMVCTelerik.Models.ModuloBasico.VOs.Lancamento> lancamentos = (List<SiteMVCTelerik.Models.ModuloBasico.VOs.Lancamento>)ViewData["lancamentos"];
                %>
                <% foreach (var item in lancamentos)
                   { %>
                <tr>
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
        </fieldset>
    </div>
    <%: Html.ActionLink("Voltar", "PrestacaoContaLista", "Movimentacao",null,null)%>
    <input alt="Clique aqui para imprimir" type="image" src="../../Content/ui-lightness/images/impressora.jpg"
        onclick="CallPrint('divPrint');" style="width: 40px; height: 40px" />
    <%} %>
</asp:Content>
