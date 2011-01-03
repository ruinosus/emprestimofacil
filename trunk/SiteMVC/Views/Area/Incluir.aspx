<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVC.Models.ModuloBasico.VOs.AreaFormViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Incluir
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Principal" runat="server">

    <h2>Incluir</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Area.descricao) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Area.descricao)%>
                <%: Html.ValidationMessageFor(model => model.Area.descricao)%>
            </div>
        
            
            <div class="editor-label">
               Municipio
            </div>
            <div class="editor-field">
        <%: Html.EditorFor(model => model.Area.municipio_id)%>
         <%--   <%= 
                Html.DropDownList("municipio_id", Model.MunicipioSelectList)%>--%>


                <%: Html.ValidationMessageFor(model => model.Area.municipio_id)%>
            </div>

            
           
            
            <p>
                <input type="submit" value="Incluir" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Voltar", "Index") %>
    </div>

</asp:Content>

