<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVC.Models.ModuloBasico.VOs.Emprestimo>" %>

<%@ Import Namespace="SiteMVC.ModuloBasico.Enums" %>
<%@ Import Namespace="SiteMVC.Helpers" %>
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
        <legend>Fields</legend>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.qtde_parcelas) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.qtde_parcelas)%>
            <%: Html.ValidationMessageFor(model => model.qtde_parcelas)%>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.data_emprestimo) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.data_emprestimo.Date)%>
            <%: Html.ValidationMessageFor(model => model.data_emprestimo) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.juros) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.juros) %>
            <%: Html.ValidationMessageFor(model => model.juros) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.prazospagamento_id) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.prazospagamento_id)%>
            <%: Html.ValidationMessageFor(model => model.prazospagamento_id) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.tipoemprestimo_id) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.tipoemprestimo_id)%>
            <%: Html.ValidationMessageFor(model => model.tipoemprestimo_id) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.valor) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.valor) %>
            <%: Html.ValidationMessageFor(model => model.valor) %>
        </div>
         <div class="editor-label">
            Dias Úteis
        </div>
        <div class="editor-field">
            <%= Html.CheckBoxList("dias", (List<CheckBoxListInfo>)ViewData["DiasUteis"])%></div>
        <%: Html.HiddenFor(model => model.cliente_id) %>
        <%: Html.HiddenFor(model => model.usuario_id) %>
        <p>
            <input type="submit" value="Incluir" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%: Html.ActionLink("Voltar", "Index") %>
    </div>
</asp:Content>
