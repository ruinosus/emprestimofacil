<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVCTelerik.Models.ModuloBasico.VOs.Cliente>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Excluir
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Excluir</h2>
       <%
        string mensagem = "";
        if (ViewData["mensagem"] != null)
            mensagem = (string)ViewData["mensagem"];
    %>
   <h3 style="color:Red"><%:mensagem %></h3> 
       <h3>Você tem certeza que deseja excluir esse registro?</h3>
    <fieldset>
        <legend>Campos</legend>
        
        <div class="display-label">area_id</div>
        <div class="display-field"><%: Model.area.descricao %></div>
        
        <div class="display-label">bairro_comerc</div>
        <div class="display-field"><%: Model.bairro_comerc %></div>
        
        <div class="display-label">bairro_resid</div>
        <div class="display-field"><%: Model.bairro_resid %></div>
        
        <div class="display-label">celular</div>
        <div class="display-field"><%: Model.celular %></div>
        
        <div class="display-label">cep_comerc</div>
        <div class="display-field"><%: Model.cep_comerc %></div>
        
        <div class="display-label">cep_resid</div>
        <div class="display-field"><%: Model.cep_resid %></div>
        
        <div class="display-label">cidade_comerc</div>
        <div class="display-field"><%: Model.cidade_comerc %></div>
        
        <div class="display-label">cidade_resid</div>
        <div class="display-field"><%: Model.cidade_resid %></div>
        
        <div class="display-label">cpf</div>
        <div class="display-field"><%: Model.cpf %></div>
        
        <div class="display-label">ctps</div>
        <div class="display-field"><%: Model.ctps %></div>
        
        <div class="display-label">data_expedicao</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.data_expedicao) %></div>
        
        <div class="display-label">endereco_comerc</div>
        <div class="display-field"><%: Model.endereco_comerc %></div>
        
        <div class="display-label">endereco_resid</div>
        <div class="display-field"><%: Model.endereco_resid %></div>
        
        <div class="display-label">escolaridade_id</div>
        <div class="display-field"><%: Model.escolaridade.descricao %></div>
        
        <div class="display-label">estadoscivistipo_id</div>
        <div class="display-field"><%: Model.estadociviltipo.descricao %></div>
        
        <div class="display-label">fone_comerc</div>
        <div class="display-field"><%: Model.fone_comerc %></div>
        
        <div class="display-label">fone_ref1</div>
        <div class="display-field"><%: Model.fone_ref1 %></div>
        
        <div class="display-label">fone_ref2</div>
        <div class="display-field"><%: Model.fone_ref2 %></div>
        
        <div class="display-label">fone_resid</div>
        <div class="display-field"><%: Model.fone_resid %></div>
        
        <div class="display-label">ID</div>
        <div class="display-field"><%: Model.id %></div>
        
        <div class="display-label">limite</div>
        <div class="display-field"><%: Model.limite %></div>
        
        <div class="display-label">nome</div>
        <div class="display-field"><%: Model.nome %></div>
        
        <div class="display-label">nome_mae</div>
        <div class="display-field"><%: Model.nome_mae %></div>
        
        <div class="display-label">nome_pai</div>
        <div class="display-field"><%: Model.nome_pai %></div>
        
        <div class="display-label">nome_ref1</div>
        <div class="display-field"><%: Model.nome_ref1 %></div>
        
        <div class="display-label">nome_ref2</div>
        <div class="display-field"><%: Model.nome_ref2 %></div>
        
        <div class="display-label">numcartao</div>
        <div class="display-field"><%: Model.numcartao %></div>
        
        <div class="display-label">orgaosexpedidoresnome_id</div>
        <div class="display-field"><%: Model.orgaoexpedidornome.descricao %></div>
        
        <div class="display-label">rg</div>
        <div class="display-field"><%: Model.rg %></div>
        
        <div class="display-label">secao</div>
        <div class="display-field"><%: Model.secao %></div>
        
        <div class="display-label">sexo</div>
        <div class="display-field"><%: Model.sexo %></div>
        
        <div class="display-label">situacao</div>
        <div class="display-field"><%: Model.situacao %></div>
        
      
        
        <div class="display-label">titulo_eleitor</div>
        <div class="display-field"><%: Model.titulo_eleitor %></div>
        
        <div class="display-label">uf_comerc</div>
        <div class="display-field"><%: Model.uf_comerc %></div>
        
        <div class="display-label">uf_resid</div>
        <div class="display-field"><%: Model.uf_resid %></div>
        
        <div class="display-label">zona</div>
        <div class="display-field"><%: Model.zona %></div>
        
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Confirmar" /> |
		    <%: Html.ActionLink("Voltar", "Index") %>
        </p>
    <% } %>

</asp:Content>

