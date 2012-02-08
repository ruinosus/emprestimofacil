<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVCTelerik.Models.ModuloBasico.VOs.StatusParcela>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Campos</legend>
        
        <div class="display-label">descricao</div>
        <div class="display-field"><%: Model.descricao %></div>
        
        <div class="display-label">ID</div>
        <div class="display-field"><%: Model.id %></div>
        
      
        
    </fieldset>
    <p>

        <%: Html.ActionLink("Alterar", "Alterar", new { id = Model.id })%> |
        <%: Html.ActionLink("Voltar", "Index") %>
    </p>

</asp:Content>

