<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<SiteMVCTelerik.Models.ModuloBasico.VOs.Cliente>>" %>
<%@ Import Namespace="SiteMVCTelerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	VisualizarClientesDevedores
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <table>
        <tr>

            <th>
                Nome
            </th>
            <th>
                Area
            </th>
            <th>
                Valor
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>

            <td>
                <%: item.nome %>
            </td>
            <td>
                <%: item.area.descricao %>
            </td>
            <td>
                <%: item.ValorDevedor %>
            </td>
        </tr>
        <% } %>
    </table>

</asp:Content>
