<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVC.Models.ModuloBasico.VOs.Parcela>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Alterar
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Alterar</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>
            
          
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.valor) %>
            </div>
            <div class="editor-field">
        <%: Html.Label(Model.valor.ToString()) %>   
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.valor_pago) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.valor_pago) %>
                <%: Html.ValidationMessageFor(model => model.valor_pago) %>
            </div>
            
            <p>
                <input type="submit" value="Salvar" />
            </p>
        </fieldset>

    <% } %>

    <div>
   <%: Html.ActionLink("Voltar", "ParcelaEmprestimo", "Parcela", new { id =SiteMVC.Models.ModuloBasico.VOs.ClasseAuxiliar.EmprestimoSelecionado.ID },null)%> |
    </div>

</asp:Content>

