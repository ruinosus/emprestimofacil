<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVCTelerik.Models.ModuloBasico.VOs.ParcelaPesquisa>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    VisualizarParcelasPorPeriodo
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        VisualizarParcelasPorPeriodo</h2>
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
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true)%>
    <div class="editor-label">
        <%: Html.LabelFor(model => model.DataInicio)%>
    </div>
    <div class="editor-field">
        <%: Html.EditorFor(model => model.DataInicio)%>
        <%: Html.ValidationMessageFor(model => model.DataInicio)%>
    </div>
    <div class="editor-label">
        <%: Html.LabelFor(model => model.DataFim)%>
    </div>
    <div class="editor-field">
        <%: Html.EditorFor(model => model.DataFim)%>
        <%: Html.ValidationMessageFor(model => model.DataFim)%>
    </div>
    <p>
        <input type="submit" value="Pesquisar" />
    </p>
    <%
           float total = 0;
           List<SiteMVCTelerik.Models.ModuloBasico.VOs.Parcela> lista = (List<SiteMVCTelerik.Models.ModuloBasico.VOs.Parcela>)ViewData["parcelas"];

if (lista.Count > 0)
{
         %>    <div id="divPrint">
     <table>
        <tr>
   

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
                cliente
            </th>
            <th>
                Area
            </th>
            <th>
                vendedor
            </th>
        </tr>
        <% foreach (var item in lista)
           {
               total += item.valor; %>
        <tr>
         
   
            <td>
                <%: String.Format("{0:g}", item.data_vencimento) %>
            </td>
            <td>
                <%: item.ID %>
            </td>

            <td>
                <%: item.sequencial %>
            </td>

            <td>
                <%: item.valor %>
            </td>
 
            <td>
                <%: item.emprestimo.cliente.nome %>
            </td>
               <td>
                <%: item.emprestimo.cliente.area.descricao%>
            </td>
            <td>
                <%: item.emprestimo.usuario.nome %>
            </td>
        </tr>
        <% } %>
    </table>
        <br />
        <table>
            <tr>
                <th>
                    Total
                </th>
            </tr>
            <tr>
                <td>
                <%:total%>
                </td>
            </tr>
        </table>
        </div>
        <input type="image" src="../../Content/ui-lightness/images/impressora.jpg" onclick="CallPrint('divPrint');"
        style="width: 40px; height: 40px" />
        <% }
       } %>
</asp:Content>
