<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVC.Models.ModuloBasico.VOs.Lancamento>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Incluir
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Incluir</h2>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
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
    <div class="editor-label">
        <%: Html.LabelFor(model => model.fonte) %>
    </div>
    <div class="editor-field">
        <%: Html.TextBoxFor(model => model.fonte) %>
        <%: Html.ValidationMessageFor(model => model.fonte) %>
    </div>
    <div class="editor-label">
        <%: Html.LabelFor(model => model.lancamentotipo_id) %>
    </div>
    <div class="editor-field">
        <%: Html.EditorFor(model => model.lancamentotipo_id) %>
        <%: Html.ValidationMessageFor(model => model.lancamentotipo_id) %>
    </div>
    <div class="editor-label">
        <%: Html.LabelFor(model => model.observacoes) %>
    </div>
    <div class="editor-field">
        <%: Html.TextBoxFor(model => model.observacoes) %>
        <%: Html.ValidationMessageFor(model => model.observacoes) %>
    </div>
    <div class="editor-label">
        <%: Html.LabelFor(model => model.outrasinfos) %>
    </div>
    <div class="editor-field">
        <%: Html.TextBoxFor(model => model.outrasinfos) %>
        <%: Html.ValidationMessageFor(model => model.outrasinfos) %>
    </div>
    <div class="editor-label">
        <%: Html.LabelFor(model => model.usuario_id) %>
    </div>
    <div class="editor-field">
        <%: Html.EditorFor(model => model.usuario_id)%>
        <%: Html.ValidationMessageFor(model => model.usuario_id) %>
    </div>
    <div class="editor-label">
        <%: Html.LabelFor(model => model.valor) %>
    </div>
    <div class="editor-field">
        <%: Html.TextBoxFor(model => model.valor) %>
        <%: Html.ValidationMessageFor(model => model.valor) %>
    </div>
    <p>
        <input type="submit" value="Incluir" />
    </p>
    <% } %>
    <div>
        <%: Html.ActionLink("Voltar", "Index") %>
    </div>
</asp:Content>
