﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVCTelerik.Models.ModuloBasico.VOs.Lancamento>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detalhar
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Detalhar</h2>

    <fieldset>
        <legend>Campos</legend>
        
        <div class="display-label">data</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.data) %></div>
        
        <div class="display-label">fonte</div>
        <div class="display-field"><%: Model.fonte %></div>
        
        <div class="display-label">ID</div>
        <div class="display-field"><%: Model.id %></div>
        
        <div class="display-label">lancamentotipo_id</div>
        <div class="display-field"><%: Model.lancamentotipo_id %></div>
        
        <div class="display-label">observacoes</div>
        <div class="display-field"><%: Model.observacoes %></div>
        
        <div class="display-label">outrasinfos</div>
        <div class="display-field"><%: Model.outrasinfos %></div>
        
        
        <div class="display-label">usuario_id</div>
        <div class="display-field"><%: Model.usuario_id %></div>
        
        <div class="display-label">valor</div>
        <div class="display-field"><%: Model.valor %></div>
        
    </fieldset>
    <p>

    
        <%: Html.ActionLink("Voltar", "Index") %>
    </p>

</asp:Content>

