﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVCTelerik.Models.ModuloBasico.VOs.Emprestimo>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Excluir
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Excluir</h2>

    <h3>Are you sure you want to delete this?</h3>
    <fieldset>
        <legend>Campos</legend>
        
        <div class="display-label">cliente_id</div>
        <div class="display-field"><%: Model.cliente.nome %></div>
        
        <div class="display-label">data_emprestimo</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.data_emprestimo) %></div>
        
        <div class="display-label">ID</div>
        <div class="display-field"><%: Model.id %></div>
        
        <div class="display-label">juros</div>
        <div class="display-field"><%: Model.juros %></div>
        
        <div class="display-label">prazospagamento_id</div>
        <div class="display-field"><%: Model.prazopagamento.descricao%></div>
        
        <div class="display-label">qtde_parcelas</div>
        <div class="display-field"><%: Model.qtde_parcelas %></div>
        
      
        <div class="display-label">tipoemprestimo_id</div>
        <div class="display-field"><%: Model.tipoemprestimo.descricao %></div>
        
        <div class="display-label">usuario_id</div>
        <div class="display-field"><%: Model.usuario.nome %></div>
        
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

