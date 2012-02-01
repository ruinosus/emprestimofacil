<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVCTelerik.Models.ModuloBasico.VOs.Despesa>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Incluir
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Incluir</h2>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Campos</legend>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.valor) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.valor)%>
            <%: Html.ValidationMessageFor(model => model.valor)%>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.justificativa) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.justificativa)%>
            <%: Html.ValidationMessageFor(model => model.justificativa)%>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.usuario_id) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.usuario_id)%>
            <%: Html.ValidationMessageFor(model => model.usuario_id)%>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.despesatipo_id) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.despesatipo_id)%>
            <%: Html.ValidationMessageFor(model => model.despesatipo_id)%>
        </div>
        <%-- <div class="editor-label">
            <%: Html.LabelFor(model => model.data) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.data.Date) %>
            <%: Html.ValidationMessageFor(model => model.data) %>
        </div>--%>
        <%if (!SiteMVCTelerik.Models.ModuloBasico.VOs.ClasseAuxiliar.IsPrestacaoConta)
          { %>
        <p>
            <input type="submit" value="Incluir" />
        </p>
        <%} %>
    </fieldset>
    <% } %>
    <div>
        <%: Html.ActionLink("Voltar", "Index")%>
    </div>
</asp:Content>
