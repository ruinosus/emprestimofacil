<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVCTelerik.Models.ModuloBasico.VOs.Lancamento>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Excluir
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
        
        <div class="display-label">data</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.data) %></div>
        
        <div class="display-label">fonte</div>
        <div class="display-field"><%: Model.fonte %></div>
        
        <div class="display-label">ID</div>
        <div class="display-field"><%: Model.ID %></div>
        
        <div class="display-label">lancamentotipo_id</div>
        <div class="display-field"><%: Model.lancamentotipo_id %></div>
        
        <div class="display-label">observacoes</div>
        <div class="display-field"><%: Model.observacoes %></div>
        
        <div class="display-label">outrasinfos</div>
        <div class="display-field"><%: Model.outrasinfos %></div>
        
        <div class="display-label">timeCreated</div>
        <div class="display-field"><%: Model.timeCreated %></div>
        
        <div class="display-label">timeUpdated</div>
        <div class="display-field"><%: Model.timeUpdated %></div>
        
        <div class="display-label">usuario_id</div>
        <div class="display-field"><%: Model.usuario_id %></div>
        
        <div class="display-label">valor</div>
        <div class="display-field"><%: Model.valor %></div>
        
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Confirmar" /> |
		    <%: Html.ActionLink("Voltar", "Index") %>
        </p>
    <% } %>

</asp:Content>

