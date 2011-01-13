<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Informar Parcela
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Informar Parcela</h2>
     <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
           <fieldset>
            <legend>Fields</legend>
            <div class="editor-label">
                <%: Html.Label("Número da Parcela:") %>
            </div>
            <div class="editor-field">
                <%: Html.TextBox("id") %>
                <%: Html.ValidationMessage("id") %>
            </div>

               <p>
                <input type="submit" value="Procurar" />
            </p>
        </fieldset>

    <% } %>
</asp:Content>
