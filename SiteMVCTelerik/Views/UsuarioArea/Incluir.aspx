<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVCTelerik.Models.ModuloBasico.VOs.UsuarioArea>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Incluir
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Incluir</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
               Area
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.area_id) %>
                <%: Html.ValidationMessageFor(model => model.area_id) %>
            </div>
            
          
            
           
            <div class="editor-label">
               Usuario
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.usuario_id)%>
                <%: Html.ValidationMessageFor(model => model.usuario_id) %>
            </div>
            
            <p>
                <input type="submit" value="Incluir" />
            </p>
        </fieldset>

    <% } %>

   

</asp:Content>

