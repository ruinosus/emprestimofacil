<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVC.Models.ModuloBasico.VOs.Municipio>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Excluir
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Principal" runat="server">

    <h2>Excluir</h2>
    <%
        string mensagem = "";
        if (ViewData["mensagem"] != null)
            mensagem = (string)ViewData["mensagem"];
    %>
   <h3 style="color:Red"><%:mensagem %></h3> 
    <h3>Você tem certeza que deseja excluir esse registro?</h3>
    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">ID</div>
        <div class="display-field"><%: Model.ID %></div>
        
        <div class="display-label">nome</div>
        <div class="display-field"><%: Model.nome %></div>
        
        <div class="display-label">timeCreated</div>
        <div class="display-field"><%: Model.timeCreated %></div>
        
        <div class="display-label">timeUpdated</div>
        <div class="display-field"><%: Model.timeCreated%></div>
        
        <div class="display-label">uf</div>
        <div class="display-field"><%: Model.uf %></div>
        
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
         <%: Html.HiddenFor(model => model.nome) %>
         <%: Html.HiddenFor(model => model.ID) %>
         <%: Html.HiddenFor(model => model.timeCreated)%>
         <%: Html.HiddenFor(model => model.timeCreated)%>
         <%: Html.HiddenFor(model => model.uf) %>
		    <input type="submit" value="Confirmar" /> |
		    <%: Html.ActionLink("Voltar", "Index") %>
        </p>
    <% } %>

</asp:Content>

