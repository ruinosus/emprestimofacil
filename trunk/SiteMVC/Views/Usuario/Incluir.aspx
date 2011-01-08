<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVC.Models.ModuloBasico.VOs.Usuario>" %>

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
                <%: Html.LabelFor(model => model.area_id) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.area_id) %>
                <%: Html.ValidationMessageFor(model => model.area_id) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.bairro_resid) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.bairro_resid) %>
                <%: Html.ValidationMessageFor(model => model.bairro_resid) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.celular) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.celular) %>
                <%: Html.ValidationMessageFor(model => model.celular) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.cep_resid) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.cep_resid) %>
                <%: Html.ValidationMessageFor(model => model.cep_resid) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.cidade_resid) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.cidade_resid) %>
                <%: Html.ValidationMessageFor(model => model.cidade_resid) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.cpf) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.cpf) %>
                <%: Html.ValidationMessageFor(model => model.cpf) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ctps) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ctps) %>
                <%: Html.ValidationMessageFor(model => model.ctps) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.data_expedicao) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.data_expedicao) %>
                <%: Html.ValidationMessageFor(model => model.data_expedicao) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.endereco_resid) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.endereco_resid) %>
                <%: Html.ValidationMessageFor(model => model.endereco_resid) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.escolaridade_id) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.escolaridade_id)%>
                <%: Html.ValidationMessageFor(model => model.escolaridade_id) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.estadoscivistipo_id) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.estadoscivistipo_id)%>
                <%: Html.ValidationMessageFor(model => model.estadoscivistipo_id) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.fone_resid) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.fone_resid) %>
                <%: Html.ValidationMessageFor(model => model.fone_resid) %>
            </div>
            
  
            <div class="editor-label">
                <%: Html.LabelFor(model => model.login) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.login) %>
                <%: Html.ValidationMessageFor(model => model.login) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.nome) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.nome) %>
                <%: Html.ValidationMessageFor(model => model.nome) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.nome_mae) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.nome_mae) %>
                <%: Html.ValidationMessageFor(model => model.nome_mae) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.nome_pai) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.nome_pai) %>
                <%: Html.ValidationMessageFor(model => model.nome_pai) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.orgaosexpedidoresnome_id) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.orgaosexpedidoresnome_id)%>
                <%: Html.ValidationMessageFor(model => model.orgaosexpedidoresnome_id) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.rg) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.rg) %>
                <%: Html.ValidationMessageFor(model => model.rg) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.secao) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.secao) %>
                <%: Html.ValidationMessageFor(model => model.secao) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.senha) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.senha) %>
                <%: Html.ValidationMessageFor(model => model.senha) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.sexo) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.sexo) %>
                <%: Html.ValidationMessageFor(model => model.sexo) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.situacao) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.situacao) %>
                <%: Html.ValidationMessageFor(model => model.situacao) %>
            </div>
            

            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.titulo_eleitor) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.titulo_eleitor) %>
                <%: Html.ValidationMessageFor(model => model.titulo_eleitor) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.uf_resid) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.uf_resid)%>
                <%: Html.ValidationMessageFor(model => model.uf_resid) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.usuariotipo_id) %>
            </div>
            <div class="editor-field">
                <%: Html.EditorFor(model => model.usuariotipo_id)%>
                <%: Html.ValidationMessageFor(model => model.usuariotipo_id) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.zona) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.zona) %>
                <%: Html.ValidationMessageFor(model => model.zona) %>
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

