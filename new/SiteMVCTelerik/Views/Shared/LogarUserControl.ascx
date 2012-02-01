<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (SiteMVCTelerik.Models.ModuloBasico.VOs.ClasseAuxiliar.UsuarioLogado != null)
    {
%>
Bem Vindo, <b>
    <%= Html.Encode(SiteMVCTelerik.Models.ModuloBasico.VOs.ClasseAuxiliar.UsuarioLogado.nome)%></b>!
[
<%= Html.ActionLink("Deslogar", "Deslogar", "Usuario") %>
] [
<%= Html.ActionLink("Alterar Senha", "AlterarSenha/"+SiteMVCTelerik.Models.ModuloBasico.VOs.ClasseAuxiliar.UsuarioLogado.id, "Usuario") %>
]
<br />
<%if (SiteMVCTelerik.Models.ModuloBasico.VOs.ClasseAuxiliar.AreaSelecionada != null)
  {
%>
Area Selecionada - <b>
    <%:SiteMVCTelerik.Models.ModuloBasico.VOs.ClasseAuxiliar.AreaSelecionada.descricao %></b><br />
<%}
  if (SiteMVCTelerik.Models.ModuloBasico.VOs.ClasseAuxiliar.DataSelecionada != default(DateTime))
  {
                      
%>
Data Selecionada - <b>
    <%:SiteMVCTelerik.Models.ModuloBasico.VOs.ClasseAuxiliar.DataSelecionada.ToString("dd/MM/yyyy")%></b><br />
<%} %>
<%if (SiteMVCTelerik.Models.ModuloBasico.VOs.ClasseAuxiliar.IsPrestacaoConta)
  { %>
  [Já Prestado Contas] <br />
<%} %>

<%
    }
    else
    {
%>
[
<%= Html.ActionLink("Logar", "Logar", "Usuario")%>
]
<%
    }
%>
