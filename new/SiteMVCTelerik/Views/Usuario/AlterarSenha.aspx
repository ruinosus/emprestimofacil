<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVCTelerik.Models.ModuloBasico.VOs.Usuario>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	AlterarSenha
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>AlterarSenha</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Campos</legend>
            
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.senha) %>
            </div>
            <div class="editor-field">
                <%: Html.PasswordFor(model => model.senha)%>
                <%: Html.ValidationMessageFor(model => model.senha)%>
            </div>
            
            <p>
                <input type="submit" value="Confirmar" />
            </p>
        </fieldset>

    <% } %>


</asp:Content>

