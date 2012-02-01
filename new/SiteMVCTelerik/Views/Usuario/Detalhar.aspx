<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVCTelerik.Models.ModuloBasico.VOs.Usuario>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detalhar
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Detalhar</h2>

    <fieldset>
        <legend>Fields</legend>
        

        
        <div class="display-label">bairro_resid</div>
        <div class="display-field"><%: Model.bairro_resid %></div>
        
        <div class="display-label">celular</div>
        <div class="display-field"><%: Model.celular %></div>
        
        <div class="display-label">cep_resid</div>
        <div class="display-field"><%: Model.cep_resid %></div>
        
        <div class="display-label">cidade_resid</div>
        <div class="display-field"><%: Model.cidade_resid %></div>
        
        <div class="display-label">cpf</div>
        <div class="display-field"><%: Model.cpf %></div>
        
        <div class="display-label">ctps</div>
        <div class="display-field"><%: Model.ctps %></div>
        
        <div class="display-label">data_expedicao</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.data_expedicao) %></div>
        
        <div class="display-label">endereco_resid</div>
        <div class="display-field"><%: Model.endereco_resid %></div>
        
        <div class="display-label">escolaridade_id</div>
        <div class="display-field"><%: Model.escolaridade.descricao %></div>
        
        <div class="display-label">estadoscivistipo_id</div>
        <div class="display-field"><%: Model.estadociviltipo.descricao %></div>
        
        <div class="display-label">fone_resid</div>
        <div class="display-field"><%: Model.fone_resid %></div>
        
        <div class="display-label">ID</div>
        <div class="display-field"><%: Model.id %></div>
        
        <div class="display-label">login</div>
        <div class="display-field"><%: Model.login %></div>
        
        <div class="display-label">nome</div>
        <div class="display-field"><%: Model.nome %></div>
        
        <div class="display-label">nome_mae</div>
        <div class="display-field"><%: Model.nome_mae %></div>
        
        <div class="display-label">nome_pai</div>
        <div class="display-field"><%: Model.nome_pai %></div>
        
        <div class="display-label">orgaosexpedidoresnome_id</div>
        <div class="display-field"><%: Model.orgaoexpedidornome.descricao %></div>
        
        <div class="display-label">rg</div>
        <div class="display-field"><%: Model.rg %></div>
        
        <div class="display-label">secao</div>
        <div class="display-field"><%: Model.secao %></div>
        
        <div class="display-label">senha</div>
   
        
        <div class="display-label">sexo</div>
        <div class="display-field"><%: Model.sexo %></div>
        
        <div class="display-label">situacao</div>
        <div class="display-field"><%: Model.situacao %></div>
        
        <div class="display-label">timeCreated</div>
        <div class="display-field"><%: Model.timeCreated %></div>
        
        <div class="display-label">timeUpdated</div>
        <div class="display-field"><%: Model.timeUpdated %></div>
        
        <div class="display-label">titulo_eleitor</div>
        <div class="display-field"><%: Model.titulo_eleitor %></div>
        
        <div class="display-label">uf_resid</div>
        <div class="display-field"><%: Model.uf_resid %></div>
        
        <div class="display-label">usuariotipo_id</div>
        <div class="display-field"><%: Model.usuariotipo.descricao%></div>
        
        <div class="display-label">zona</div>
        <div class="display-field"><%: Model.zona %></div>
        
    </fieldset>
    <p>

        <%: Html.ActionLink("Alterar", "Alterar", new { id = Model.id })%> |
        <%: Html.ActionLink("Voltar", "Index") %>
    </p>

</asp:Content>

