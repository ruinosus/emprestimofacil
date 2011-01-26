﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteMVC.Models.ModuloBasico.VOs.EmprestimoPesquisa>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    VisualizarEmprestimosPorPeriodo
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        VisualizarEmprestimosPorPeriodo</h2>
    <% using (Html.BeginForm())
       {%>
    <%: Html.ValidationSummary(true)%>
    <div class="editor-label">
        <%: Html.LabelFor(model => model.DataInicio)%>
    </div>
    <div class="editor-field">
        <%: Html.EditorFor(model => model.DataInicio)%>
        <%: Html.ValidationMessageFor(model => model.DataInicio)%>
    </div>
    <div class="editor-label">
        <%: Html.LabelFor(model => model.DataFim)%>
    </div>
    <div class="editor-field">
        <%: Html.EditorFor(model => model.DataFim)%>
        <%: Html.ValidationMessageFor(model => model.DataFim)%>
    </div>
    <p>
        <input type="submit" value="Pesquisar" />
    </p>
    <%
        
List<SiteMVC.Models.ModuloBasico.VOs.Emprestimo> lista = (List<SiteMVC.Models.ModuloBasico.VOs.Emprestimo>)ViewData["emprestimos"];

if (lista.Count > 0)
{
         %>
    <table>
        <tr>
            <th>
                cliente
            </th>
            <th>
                data_emprestimo
            </th>
            <th>
                ID
            </th>
            <th>
                juros
            </th>
            <th>
                prazospagamento_id
            </th>
            <th>
                qtde_parcelas
            </th>
            <th>
                timeCreated
            </th>
            <th>
                timeUpdated
            </th>
            <th>
                tipoemprestimo_id
            </th>
            <th>
                usuario_id
            </th>
            <th>
                valor
            </th>
        </tr>
        <% 
    float total = 0;

    foreach (var item in lista)
    {
        total += item.valor;
        %>
        <tr>
            <td>
                <%: item.cliente.nome%>
            </td>
            <td>
                <%: String.Format("{0:g}", item.data_emprestimo)%>
            </td>
            <td>
                <%: item.ID%>
            </td>
            <td>
                <%: item.juros%>
            </td>
            <td>
                <%: item.prazospagamento_id%>
            </td>
            <td>
                <%: item.qtde_parcelas%>
            </td>
            <td>
                <%: item.timeCreated%>
            </td>
            <td>
                <%: item.timeUpdated%>
            </td>
            <td>
                <%: item.tipoemprestimo_id%>
            </td>
            <td>
                <%: item.usuario_id%>
            </td>
            <td>
                <%: item.valor%>
            </td>
        </tr>
        <% } %>
        </table>
        <table>
            <tr>
                <th>
                    Total
                </th>
            </tr>
            <tr>
                <td>
                <%:total%>
                </td>
            </tr>
        </table>
        <% }
       } %>
</asp:Content>
