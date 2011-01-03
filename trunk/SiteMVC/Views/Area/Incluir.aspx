<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVC.Models.ModuloBasico.VOs.Area>" %>

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
                <%: Html.LabelFor(model => model.descricao) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.descricao)%>
                <%: Html.ValidationMessageFor(model => model.descricao)%>
            </div>
        
            
            <div class="editor-label">
               Municipio
            </div>
            <div class="editor-field">
        <%: Html.EditorFor(model => model.municipio_id)%>
         <%--   <%= 
                Html.DropDownList("municipio_id", Model.MunicipioSelectList)%>--%>


                <%: Html.ValidationMessageFor(model => model.municipio_id)%>
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

