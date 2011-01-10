<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SiteMVC.Models.ModuloBasico.VOs.Parcela>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ImprimirParcelas
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        ImprimirParcelas</h2>
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
        <table border="1" width="100%">
            <% foreach (var item in Model)
               { %>
            <tr>
                <td style="width: 50%">
                    <table border="1">
                        <tr>
                            <td style="width: 250px">
                                Sequencial:<b>
                                    <%: item.sequencial %></b>
                            </td>
                            <td style="width: 200px">
                                Data Vencimento:<b><%: item.data_vencimento.ToString("dd/MM/yyyy")%></b>
                            </td>
                            <td colspan="2">
                                Valor:<b>
                                    <%: item.valor %></b>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                Data Pagamento:&nbsp;&nbsp;
                            </td>
                            <td colspan="2">
                                Valor Pago:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 50%">
                    <table border="1">
                        <tr>
                            <td style="width: 250px">
                                Sequencial:<b>
                                    <%: item.sequencial %></b>
                            </td>
                            <td style="width: 200px">
                                Data Vencimento:<b><%:  item.data_vencimento.ToString("dd/MM/yyyy") %></b>
                            </td>
                            <td colspan="2">
                                Valor:<b>
                                    <%: item.valor %></b>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Identificador:<b>
                                    <%: item.ID %></b>
                            </td>
                            <td>
                                Data Pagamento:&nbsp;&nbsp;
                            </td>
                            <td colspan="2">
                                Valor Pago:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <% } %>
        </table>
    </div>
        <input type="image" src="../../Content/ui-lightness/images/impressora.jpg"
 onclick="CallPrint('divPrint');" style="width:40px; height:40px"  />
</asp:Content>
