﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVC.Models.ModuloBasico.VOs.Cliente>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Incluir
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Incluir</h2>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Dados Pessoais</legend>
        <table>
            <tr>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.nome) %>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.nome) %>
                        <%: Html.ValidationMessageFor(model => model.nome) %>
                    </div>
                </td>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.cpf) %>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.cpf) %>
                        <%: Html.ValidationMessageFor(model => model.cpf) %>
                    </div>
                </td>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.rg) %>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.rg) %>
                        <%: Html.ValidationMessageFor(model => model.rg) %>
                    </div>
                </td>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.orgaosexpedidoresnome_id) %>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.EditorFor(model => model.orgaosexpedidoresnome_id)%>
                        <%: Html.ValidationMessageFor(model => model.orgaosexpedidoresnome_id) %>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.data_expedicao) %>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.EditorFor(model => model.data_expedicao)%>
                        <%: Html.ValidationMessageFor(model => model.data_expedicao) %>
                    </div>
                </td>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.titulo_eleitor) %>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.titulo_eleitor) %>
                        <%: Html.ValidationMessageFor(model => model.titulo_eleitor) %>
                    </div>
                </td>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.zona) %>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.zona) %>
                        <%: Html.ValidationMessageFor(model => model.zona) %>
                    </div>
                </td>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.secao) %>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.secao) %>
                        <%: Html.ValidationMessageFor(model => model.secao) %>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.ctps) %>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.ctps) %>
                        <%: Html.ValidationMessageFor(model => model.ctps) %>
                    </div>
                </td>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.sexo) %>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.sexo) %>
                        <%: Html.ValidationMessageFor(model => model.sexo) %>
                    </div>
                </td>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.escolaridade_id)%>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.EditorFor(model => model.escolaridade_id)%>
                        <%: Html.ValidationMessageFor(model => model.escolaridade_id)%>
                    </div>
                </td>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.estadoscivistipo_id)%>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.EditorFor(model => model.estadoscivistipo_id)%>
                        <%: Html.ValidationMessageFor(model => model.estadoscivistipo_id)%>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.nome_mae) %>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.nome_mae) %>
                        <%: Html.ValidationMessageFor(model => model.nome_mae) %>
                    </div>
                </td>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.nome_pai) %>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.nome_pai) %>
                        <%: Html.ValidationMessageFor(model => model.nome_pai) %>
                    </div>
                </td>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.numcartao) %>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.numcartao) %>
                        <%: Html.ValidationMessageFor(model => model.numcartao) %>
                    </div>
                </td>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.area_id) %>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.EditorFor(model => model.area_id) %>
                        <%: Html.ValidationMessageFor(model => model.area_id) %>
                    </div>
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <legend>Endereço Residêncial</legend>
        <table>
            <tr>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.endereco_resid) %>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.endereco_resid) %>
                        <%: Html.ValidationMessageFor(model => model.endereco_resid) %>
                    </div>
                </td>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.bairro_resid) %>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.bairro_resid) %>
                        <%: Html.ValidationMessageFor(model => model.bairro_resid) %>
                    </div>
                </td>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.cep_resid) %>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.cep_resid) %>
                        <%: Html.ValidationMessageFor(model => model.cep_resid) %>
                    </div>
                </td>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.cidade_resid) %>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.EditorFor(model => model.cidade_resid)%>
                        <%: Html.ValidationMessageFor(model => model.cidade_resid) %>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.fone_resid) %>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.fone_resid) %>
                        <%: Html.ValidationMessageFor(model => model.fone_resid) %>
                    </div>
                </td>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.uf_resid) %>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.EditorFor(model => model.uf_resid)%>
                        <%: Html.ValidationMessageFor(model => model.uf_resid) %>
                    </div>
                </td>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.celular) %>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.celular) %>
                        <%: Html.ValidationMessageFor(model => model.celular) %>
                    </div>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <legend>Endereço Comercial</legend>
        <table>
            <tr>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.endereco_comerc) %>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.endereco_comerc)%>
                        <%: Html.ValidationMessageFor(model => model.endereco_comerc)%>
                    </div>
                </td>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.bairro_comerc)%>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.bairro_comerc)%>
                        <%: Html.ValidationMessageFor(model => model.bairro_comerc)%>
                    </div>
                </td>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.cep_comerc)%>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.cep_comerc)%>
                        <%: Html.ValidationMessageFor(model => model.cep_comerc)%>
                    </div>
                </td>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.cidade_comerc)%>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.EditorFor(model => model.cidade_comerc)%>
                        <%: Html.ValidationMessageFor(model => model.cidade_comerc)%>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.fone_comerc)%>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.fone_comerc)%>
                        <%: Html.ValidationMessageFor(model => model.fone_comerc)%>
                    </div>
                </td>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.uf_comerc)%>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.EditorFor(model => model.uf_comerc)%>
                        <%: Html.ValidationMessageFor(model => model.uf_comerc)%>
                    </div>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <legend>Informações adicionais</legend>
        <table>
            <tr>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.fone_ref1) %>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.fone_ref1) %>
                        <%: Html.ValidationMessageFor(model => model.fone_ref1) %>
                    </div>
                </td>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.nome_ref1) %>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.nome_ref1) %>
                        <%: Html.ValidationMessageFor(model => model.nome_ref1) %>
                    </div>
                </td>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.fone_ref2) %>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.fone_ref2) %>
                        <%: Html.ValidationMessageFor(model => model.fone_ref2) %>
                    </div>
                </td>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.nome_ref2) %>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.nome_ref2) %>
                        <%: Html.ValidationMessageFor(model => model.nome_ref2) %>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.limite)%>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.limite) %>
                        <%: Html.ValidationMessageFor(model => model.limite) %>
                    </div>
                </td>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.situacao) %>
                    </div>
                </td>
                <td>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.situacao) %>
                        <%: Html.ValidationMessageFor(model => model.situacao) %>
                    </div>
                </td>
                <td>
                  <div class="editor-label">
                        <%: Html.LabelFor(model => model.observacao) %>
                    </div>
                </td>
                <td>
                   <div class="editor-field">
                        <%: Html.TextAreaFor(model => model.observacao)%>
                        <%: Html.ValidationMessageFor(model => model.observacao) %>
                    </div>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </fieldset>
    <p>
        <input type="submit" value="Incluir" />
    </p>
    <% } %>
    <div>
        <%: Html.ActionLink("Voltar", "Index") %>
    </div>
</asp:Content>
