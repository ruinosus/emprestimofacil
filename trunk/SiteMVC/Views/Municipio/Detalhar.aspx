<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVC.Models.ModuloBasico.VOs.Municipio>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detalhar
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Principal" runat="server">

    <h2>Detalhar</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">ID</div>
        <div class="display-field"><%: Model.ID %></div>
        
        <div class="display-label">nome</div>
        <div class="display-field"><%: Model.nome %></div>
        
        <div class="display-label">timeCreated</div>
        <div class="display-field"><%: Model.timeCreated %></div>
        
        <div class="display-label">timeUpdated</div>
        <div class="display-field"><%: Model.timeUpdated %></div>
        
        <div class="display-label">uf</div>
        <div class="display-field"><%: Model.uf %></div>
        
    </fieldset>
    <p>

        <%: Html.ActionLink("Edit", "Edit", new { id=Model.ID }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

