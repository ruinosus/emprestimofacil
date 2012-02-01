<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IPagedList<SiteMVCTelerik.Models.ModuloBasico.VOs.Lancamento>>" %>

<%@ Import Namespace="SiteMVCTelerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Movimentacao
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Movimentacao</h2>
    
   
     <p>
        <%: Html.ActionLink("Prestacao de Contas", "IncluirPrestacaoConta")%>

    </p>

    <p>
        <%: Html.ActionLink("Total Movimentacao", "VisualizarTotalMovimentacao")%>
    </p>
    <p>
        <%: Html.ActionLink("Visualizar Lancamentos Detalhados", "VisualizarDetalheLancamento")%>
    </p>
     <p>
        <%: Html.ActionLink("Visualizar Resumo dos Lancamentos", "VisualizarResumoLancamento") %>
    </p>
    <p>
        <%: Html.ActionLink("Visualizar Parcelas Pagas", "VisualizarDetalheParcelas")%>
    </p>
    <p>
        <%: Html.ActionLink("Visualizar Clientes Devedores", "VisualizarClientesDevedores")%>
    </p>

     <p>
        <%: Html.ActionLink("Visualizar Emprestimos por período", "VisualizarEmprestimosPorPeriodo")%>
    </p>

       <p>
        <%: Html.ActionLink("Visualizar Parcelas por período", "VisualizarParcelasPorPeriodo")%>
    </p>

     <p>
        <%: Html.ActionLink("Visualizar Clientes por Area", "VisualizarListaClientesPorArea")%>
    </p>
</asp:Content>
