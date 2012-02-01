<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVCTelerik.Models.ModuloBasico.VOs.DespesaTipo>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detalhar
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Detalhar</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">ID</div>
        <div class="display-field"><%: Model.id %></div>
        
        <div class="display-label">nome</div>
        <div class="display-field"><%: Model.descricao %></div>
        
        <div class="display-label">timeCreated</div>
        <div class="display-field"><%: Model.timeCreated %></div>
        
        <div class="display-label">timeUpdated</div>
        <div class="display-field"><%: Model.timeUpdated %></div>
        
        <div class="display-label">uf</div>
        <div class="display-field"><%: Model.posdescricao %></div>
        
    </fieldset>
    <p>

        <%: Html.ActionLink("Alterar", "Alterar", new { id=Model.id }) %> |
        <%: Html.ActionLink("Voltar", "Index") %>
    </p>

</asp:Content>

