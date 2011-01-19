<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVC.Models.ModuloBasico.VOs.Parcela>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Visualizar Detalhe das Parcelas
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
        Visualizar Detalhe das Parcelas</h2>
    <% using (Html.BeginForm())
       { %>
    <div class="editor-label">
        <%: Html.LabelFor(model => model.data_pagamento) %>
    </div>
    <div class="editor-field">
        <div class="date-container">
            <%: Html.EditorFor(model => model.data_pagamento)%>
        </div>
        <div class="clear">
            <%: Html.ValidationMessageFor(model => model.data_pagamento)%>
        </div>
    </div>
    <p>
        <input type="submit" value="Pesquisar" />
        |
        <%: Html.ActionLink("Voltar", "Index") %>
    </p>
    <% } %>
    <%
        float valorEntradas = 0;
        float valorSaida = 0;

    %>
    <div id="divPrint">
        <fieldset>
            <legend>Entradas</legend>
            <table>
                <tr>
                    <th>
                        Data vencimento
                    </th>
                    <th>
                        Data Pagamento
                    </th>
                    <th>
                        Valor Parcela
                    </th>
                    <th>
                        Valor Pago
                    </th>
                    <th>
                        Cliente
                    </th>
                </tr>
                <% foreach (var item in (List<SiteMVC.Models.ModuloBasico.VOs.Parcela>)ViewData["parcelas"])
                   {
                       
                           valorEntradas += item.valor_pago.Value; 
                %>
                <tr>
                    <td>
                        <%: String.Format("{0:g}", item.data_vencimento)%>
                    </td>
                    <td>
                          <%: String.Format("{0:g}", item.data_pagamento)%>
                    </td>
                    <td>
                        <%: item.valor%>
                    </td>
                    <td>
                        <%: item.valor_pago%>
                    </td>
                    <td>
                        <%: item.emprestimo.cliente.nome%>
                    </td>
                    
                    
                </tr>
                <% 
               } %>
            </table>
        </fieldset>
        <fieldset>
            <legend>Totais de Parcelas Pagas</legend>
            <table>
                <tr>
                    <th>
                        Total
                    </th>
                </tr>
                <tr>
                    <td>
                        <%:valorEntradas %>
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
    <input type="image" src="../../Content/ui-lightness/images/impressora.jpg" onclick="CallPrint('divPrint');"
        style="width: 40px; height: 40px" />
</asp:Content>
