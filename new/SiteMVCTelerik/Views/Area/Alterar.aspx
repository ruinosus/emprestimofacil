<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVCTelerik.Models.ModuloBasico.VOs.Area>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Alterar
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Alterar</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Campos</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.descricao) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.descricao) %>
                <%: Html.ValidationMessageFor(model => model.descricao) %>
            </div>
                  
           <div class="editor-label">
               Municipio
            </div>
            <div class="editor-field">
            <%
           
                var teste = Model.municipio_id;
            %>
        <%: Html.EditorFor(model => model.municipio_id)%>
         <%--   <%= 
                Html.DropDownList("municipio_id", Model.MunicipioSelectList)%>--%>


                <%: Html.ValidationMessageFor(model => model.municipio_id)%>
            </div>

         
            
                  <%: Html.HiddenFor(model => model.timeCreated)%>
                  <%: Html.HiddenFor(model => model.timeUpdated)%>
            <p>
                <input type="submit" value="Salvar" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Voltar", "Index") %>
    </div>

</asp:Content>

