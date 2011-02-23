<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVCTelerik.Models.ModuloBasico.VOs.Lancamento>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Visualizar Lancamento
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
        Visualizar Lancamento</h2>
    <% using (Html.BeginForm())
       { %>
    <div class="editor-label">
        <%: Html.LabelFor(model => model.data) %>
    </div>
    <div class="editor-field">
        <div class="date-container">
            <%: Html.EditorFor(model => model.data)%>
        </div>
        <div class="clear">
            <%: Html.ValidationMessageFor(model => model)%>
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
                    Data
                </th>
                <th>
                    Fonte
                </th>
                <th>
                    ID
                </th>
                  <th>
                    Tipo do lançamento
                </th>
                <th>
                    Observações
                </th>
                <th>
                    Outras Informações
                </th>
                <th>
                    Usuário
                </th>
                <th>
                    Valor
                </th>
            </tr>
            <% foreach (var item in (List<SiteMVCTelerik.Models.ModuloBasico.VOs.Lancamento>)ViewData["lancamentos"])
               {
                   if (item.lancamentotipo.sinal.Equals("+"))
                   {
                       valorEntradas += item.valor; 
            %>
            <tr>
                <td>
                    <%: String.Format("{0:g}", item.data)%>
                </td>
                <td>
                    <%: item.fonte%>
                </td>
                <td>
                    <%: item.ID%>
                </td>
                <td>
                    <%: item.lancamentotipo.descricao%>
                </td>
                <td>
                    <%: item.observacoes%>
                </td>
                <td>
                    <%: item.outrasinfos%>
                </td>
                <td>
                    <%: item.usuario.nome%>
                </td>
                <td>
                    <%: item.valor%>
                </td>
            </tr>
            <% }
               } %>
        </table>
    </fieldset>
    <fieldset>
        <legend>Saidas</legend>
        <table>
            <tr>
                <th>
                    Data
                </th>
                <th>
                    Fonte
                </th>
                <th>
                    ID
                </th>
                  <th>
                    Tipo do lançamento
                </th>
                <th>
                    Observações
                </th>
                <th>
                    Outras Informações
                </th>
                <th>
                    Usuário
                </th>
                <th>
                    Valor
                </th>
            </tr>
            <% foreach (var item in (List<SiteMVCTelerik.Models.ModuloBasico.VOs.Lancamento>)ViewData["lancamentos"])
               {
                   if (item.lancamentotipo.sinal.Equals("-"))
                   {
                       valorSaida += item.valor; 
            %>
            <tr>
                <td>
                    <%: String.Format("{0:g}", item.data)%>
                </td>
                <td>
                    <%: item.fonte%>
                </td>
                <td>
                    <%: item.ID%>
                </td>
                <td>
                    <%: item.lancamentotipo.descricao%>
                </td>
                <td>
                    <%: item.observacoes%>
                </td>
                <td>
                    <%: item.outrasinfos%>
                </td>
                <td>
                    <%: item.usuario.nome%>
                </td>
                <td>
                    <%: item.valor%>
                </td>
            </tr>
            <% }
               } %>
        </table>
    </fieldset>
    <fieldset>
        <legend>Totais do dia</legend>
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
                    <%:valorEntradas %>
                </td>
                <td>
                    <%:valorSaida %>
                </td>
                <td>
                    <%:valorEntradas - valorSaida %>
                </td>
            </tr>
        </table>
    </fieldset>
    </div>
        <input type="image" src="../../Content/ui-lightness/images/impressora.jpg"
 onclick="CallPrint('divPrint');" style="width:40px; height:40px"  />
</asp:Content>
