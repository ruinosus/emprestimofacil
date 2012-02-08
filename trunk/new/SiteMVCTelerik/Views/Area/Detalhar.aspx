<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVCTelerik.Models.ModuloBasico.VOs.Area>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detalhar
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Detalhar</h2>

    <fieldset>
        <legend>Campos</legend>
        
        <div class="display-label">Descrição</div>
        <div class="display-field"><%: Model.descricao %></div>
        
        <div class="display-label">ID</div>
        <div class="display-field"><%: Model.id %></div>
        
        <div class="display-label">Município</div>
        <div class="display-field"><%: Model.municipio.nome %></div>
        
       
        
    </fieldset>
    <p>

        <%: Html.ActionLink("Alterar", "Alterar", new { id = Model.id })%> |
        <%: Html.ActionLink("Voltar", "Index") %>
    </p>

</asp:Content>

