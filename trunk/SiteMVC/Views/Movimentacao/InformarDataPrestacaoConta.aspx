﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVC.Models.ModuloBasico.VOs.PrestacaoContaPesquisa>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Informe a data da prestacao
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Informe a data da prestacao</h2>
     <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
           <fieldset>
            <legend>Fields</legend>
               <div class="editor-label">
                <%: Html.LabelFor(model => model.DataPrestacaoConta) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.DataPrestacaoConta.Date)%>
                <%: Html.ValidationMessageFor(model => model.DataPrestacaoConta)%>
            </div>

               <p>
                <input type="submit" value="Procurar" />
            </p>
        </fieldset>

    <% } %>
</asp:Content>
