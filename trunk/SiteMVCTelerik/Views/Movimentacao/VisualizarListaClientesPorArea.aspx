<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVCTelerik.Models.ModuloBasico.VOs.ClientePesquisa>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    VisualizarListaClientesPorArea
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        VisualizarListaClientesPorArea</h2>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true)%>
    <div class="editor-label">
        <%: Html.LabelFor(model => model.area)%>
    </div>
    <div class="editor-field">
        <%: Html.EditorFor(model => model.area)%>
        <%: Html.ValidationMessageFor(model => model.area)%>
    </div>
    <p>
        <input type="submit" value="Pesquisar" />
    </p>
    <%
List<SiteMVCTelerik.Models.ModuloBasico.VOs.Cliente> lista = (List<SiteMVCTelerik.Models.ModuloBasico.VOs.Cliente>)ViewData["clientes"];

if (lista.Count > 0)
{
    %>
    <div id="divPrint">
        <table>
            <tr>
                <th>
                    Nome
                </th>
                <th>
                    Area
                </th>
            </tr>
            <% foreach (var item in lista)
               { %>
            <tr>
                <td>
                    <%: item.nome%>
                </td>
                <td>
                    <%: item.area.descricao%>
                </td>
            </tr>
            <% } %>
        </table>
    </div>
    <input type="image" src="../../Content/ui-lightness/images/impressora.jpg" onclick="CallPrint('divPrint');"
        style="width: 40px; height: 40px" />
    <% }
       } %>
</asp:Content>
