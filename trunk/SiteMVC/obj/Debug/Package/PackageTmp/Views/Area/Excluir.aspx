<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVC.Models.ModuloBasico.VOs.Area>" %>

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
        
        <div class="display-label">Descrição</div>
        <div class="display-field"><%: Model.descricao %></div>
        
        <div class="display-label">ID</div>
        <div class="display-field"><%: Model.ID %></div>
        
        <div class="display-label">Município</div>
        <div class="display-field"><%: Model.municipio.nome %></div>
        
        <div class="display-label">Data Criação</div>
        <div class="display-field"><%: Model.timeCreated %></div>
        
        <div class="display-label">Data Atualização</div>
        <div class="display-field"><%: Model.timeUpdated %></div>
        
        
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
                 <%: Html.HiddenFor(model => model.descricao) %>
         <%: Html.HiddenFor(model => model.ID) %>
         <%: Html.HiddenFor(model => model.timeCreated)%>
         <%: Html.HiddenFor(model => model.timeCreated)%>
         <%: Html.HiddenFor(model => model.municipio_id) %>
		    <input type="submit" value="Confirmar" /> |
		    <%: Html.ActionLink("Voltar", "Index") %>
        </p>
    <% } %>

</asp:Content>

