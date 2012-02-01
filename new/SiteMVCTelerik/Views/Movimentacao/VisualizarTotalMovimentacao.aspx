<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	VisualizarTotalMovimentacao
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

     <div id="divPrint">
        <fieldset>
            <legend>Prestacao de Contas</legend>
            <table>
                <tr>
                    <td>
                        Total dos Emprestimos:
                    </td>
                    <td>
                        <%: Convert.ToDecimal(ViewData["totalEmprestimo"].ToString())%>
                    </td>
                </tr>
                <tr>
                    <td>
                        Total dos Emprestimos(Juros):
                    </td>
                    <td>
                        <%: Convert.ToDecimal(ViewData["totalEmprestimoJuros"].ToString())%>
                    </td>
                </tr>
                <tr>
                    <td>
                        Total de Parcelas Pagas:
                    </td>
                    <td>
                        <%: Convert.ToDecimal(ViewData["totalParcelasPagas"].ToString())%>
                    </td>
                </tr>
                 <tr>
                    <td>
                        Total de Parcelas em Aberto:
                    </td>
                    <td>
                        <%: Convert.ToDecimal(ViewData["totalParcelasEmAberto"].ToString())%>
                    </td>
                </tr>
            </table>
            <%
                
                decimal totalEmprestimo = Convert.ToDecimal(ViewData["totalEmprestimo"].ToString());
                decimal totalEmprestimoJuros = Convert.ToDecimal(ViewData["totalEmprestimoJuros"].ToString());
                decimal totalParcelasPagas = Convert.ToDecimal(ViewData["totalParcelasPagas"].ToString());
                decimal totalParcelasEmAberto = Convert.ToDecimal(ViewData["totalParcelasEmAberto"].ToString());
                 %>
           


            <//fieldset>
            </div>
            <input alt="Clique aqui para imprimir" type="image" src="../../Content/ui-lightness/images/impressora.jpg"
        onclick="CallPrint('divPrint');" style="width: 40px; height: 40px" />
</asp:Content>
