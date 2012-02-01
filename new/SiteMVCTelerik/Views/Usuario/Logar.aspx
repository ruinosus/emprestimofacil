<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVCTelerik.Models.ModuloBasico.VOs.Usuario>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
        Logar
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <h2>logar</h2>
    <p>
        Informe o seu login e a senha. 
    </p>
    <%= Html.ValidationSummary(true, "Login ou senha inválidos.") %>

    <% using (Html.BeginForm()) { %>
        <div>
            <fieldset>
                <legend>Informações da Conta</legend>
                
                <div class="editor-label">
                    <%= Html.LabelFor(m => m.login) %>
                </div>
                <div class="editor-field">
                    <%= Html.TextBoxFor(m => m.login)%>
                    <%= Html.ValidationMessageFor(m => m.login,"*")%>
                </div>
                
                <div class="editor-label">
                    <%= Html.LabelFor(m => m.senha) %>
                </div>
                <div class="editor-field">
                    <%= Html.PasswordFor(m => m.senha) %>
                    <%= Html.ValidationMessageFor(m => m.senha, "*")%>
                </div>
                
                <p>
                    <input type="submit" value="Entrar" />
                </p>
            </fieldset>
        </div>
    <% } %>

</asp:Content>

