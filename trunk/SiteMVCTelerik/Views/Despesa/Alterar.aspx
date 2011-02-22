<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVCTelerik.Models.ModuloBasico.VOs.Despesa>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Alterar
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Alterar</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>
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
            <%: Html.LabelFor(model => model.data) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.data.Date) %>
            <%: Html.ValidationMessageFor(model => model.data) %>
        </div>
        
         <div class="editor-label">
            <%: Html.LabelFor(model => model.despesatipo_id) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.despesatipo_id)%>
            <%: Html.ValidationMessageFor(model => model.despesatipo_id)%>
        </div>

            <p>
                <input type="submit" value="Salvar" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Voltar", "Index")%>
    </div>

</asp:Content>

