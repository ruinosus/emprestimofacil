<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVC.Models.ModuloBasico.VOs.Area>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detalhar
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Detalhar</h2>

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
    <p>

        <%: Html.ActionLink("Alterar", "Alterar", new { id = Model.ID })%> |
        <%: Html.ActionLink("Voltar", "Index") %>
    </p>

</asp:Content>

