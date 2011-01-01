<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<RegraNegocio.ModuloBasico.VOs.StatusParcela>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Principal" runat="server">

    <h2>Edit</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.descricao) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.descricao) %>
                <%: Html.ValidationMessageFor(model => model.descricao) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ID) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ID) %>
                <%: Html.ValidationMessageFor(model => model.ID) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.timeCreated) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.timeCreated) %>
                <%: Html.ValidationMessageFor(model => model.timeCreated) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.timeUpdated) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.timeUpdated) %>
                <%: Html.ValidationMessageFor(model => model.timeUpdated) %>
            </div>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

