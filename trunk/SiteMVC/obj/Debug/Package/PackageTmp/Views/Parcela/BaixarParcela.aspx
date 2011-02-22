<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVC.Models.ModuloBasico.VOs.Parcela>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Baixa de Parcela
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Baixa de Parcela</h2>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Fields</legend>
        <div class="editor-label">
            Nome:
            <%: Html.Label(Model.emprestimo.cliente.nome) %>
        </div>
        <div class="editor-label">
            Parcela de numero :<%: Html.Label(Model.sequencial.ToString()) %>
        </div>
        <div class="editor-label">
            valor:
            <%: Html.Label(Model.valor.ToString()) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.valor_pago) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.valor_pago) %>
            <%: Html.ValidationMessageFor(model => model.valor_pago) %>
        </div>
        <%-- <div class="editor-label">
                <%: Html.LabelFor(model => model.data_pagamento) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.data_pagamento)%>
                <%: Html.ValidationMessageFor(model => model.data_pagamento)%>
            </div>--%>
        <%: Html.HiddenFor(model => model.data_pagamento)%>
        <%if (!SiteMVC.Models.ModuloBasico.VOs.ClasseAuxiliar.IsPrestacaoConta)
          { %>
        <p>
            <input type="submit" value="Baixar Parcela" />
        </p>
        <%} %>
    </fieldset>
    <% } %>
    <div>
        <%: Html.ActionLink("Voltar", "Informar", "Parcela")%>
        |
    </div>
</asp:Content>
