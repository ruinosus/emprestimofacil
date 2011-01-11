<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVC.Models.ModuloBasico.VOs.Municipio>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Incluir
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Incluir</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
                <div class="editor-label">
                <%: Html.LabelFor(model => model.nome) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.nome) %>
                <%: Html.ValidationMessageFor(model => model.nome) %>
            </div>
           
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.uf) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.uf) %>
                <%: Html.ValidationMessageFor(model => model.uf) %>
            </div>            
            <p>
                <input type="submit" value="Incluir" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Voltar", "Index")%>
    </div>

</asp:Content>

