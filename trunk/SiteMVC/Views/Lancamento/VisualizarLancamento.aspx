<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVC.Models.ModuloBasico.VOs.Lancamento>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Visualizar Lancamento
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Visualizar Lancamento</h2>
    <% using (Html.BeginForm())
       { %>
    <div class="editor-label">
        <%: Html.LabelFor(model => model.data) %>
    </div>
    <div class="editor-field">
        <div class="date-container">
            <%: Html.EditorFor(model => model.data.Date)%>
        </div>
        <div class="clear">
            <%: Html.ValidationMessageFor(model => model.data)%>
        </div>
    </div>
    <p>
        <input type="submit" value="Pesquisar" />
        |
        <%: Html.ActionLink("Voltar", "Index") %>
    </p>
    <% } %>
    <table>
        <tr>

            <th>
                data
            </th>
            <th>
                fonte
            </th>
            <th>
                ID
            </th>
            <th>
                lancamentotipo_id
            </th>
            <th>
                observacoes
            </th>
            <th>
                outrasinfos
            </th>
            <th>
                usuario_id
            </th>
            <th>
                valor
            </th>
        </tr>
        <% foreach (var item in (List<SiteMVC.Models.ModuloBasico.VOs.Lancamento>)ViewData["lancamentos"])
           { %>
        <tr>
            <td>
                <%: String.Format("{0:g}", item.data) %>
            </td>
            <td>
                <%: item.fonte %>
            </td>
            <td>
                <%: item.ID %>
            </td>
            <td>
                <%: item.lancamentotipo_id %>
            </td>
            <td>
                <%: item.observacoes %>
            </td>
            <td>
                <%: item.outrasinfos %>
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
</asp:Content>
