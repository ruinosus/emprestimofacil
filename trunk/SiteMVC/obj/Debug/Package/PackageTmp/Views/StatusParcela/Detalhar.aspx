<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVC.Models.ModuloBasico.VOs.StatusParcela>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Principal" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">descricao</div>
        <div class="display-field"><%: Model.descricao %></div>
        
        <div class="display-label">ID</div>
        <div class="display-field"><%: Model.ID %></div>
        
        <div class="display-label">timeCreated</div>
        <div class="display-field"><%: Model.timeCreated %></div>
        
        <div class="display-label">timeUpdated</div>
        <div class="display-field"><%: Model.timeUpdated %></div>
        
    </fieldset>
    <p>

        <%: Html.ActionLink("Alterar", "Alterar", new { id = Model.ID })%> |
        <%: Html.ActionLink("Voltar", "Index") %>
    </p>

</asp:Content>

