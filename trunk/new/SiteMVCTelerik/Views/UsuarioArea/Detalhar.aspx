<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVCTelerik.Models.ModuloBasico.VOs.UsuarioArea>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detalhar
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Detalhar</h2>

    <fieldset>
        <legend>Campos</legend>
        
        <div class="display-label">area_id</div>
        <div class="display-field"><%: Model.area_id %></div>
        
        <div class="display-label">ID</div>
        <div class="display-field"><%: Model.id %></div>
        
        <div class="display-label">timeCreated</div>
        <div class="display-field"><%: Model.timeCreated %></div>
        
        <div class="display-label">timeUpdated</div>
        <div class="display-field"><%: Model.timeUpdated %></div>
        
        <div class="display-label">usuario_id</div>
        <div class="display-field"><%: Model.usuario_id %></div>
        
    </fieldset>
    <p>

    </p>

</asp:Content>

