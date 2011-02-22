<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (SiteMVC.Models.ModuloBasico.VOs.ClasseAuxiliar.UsuarioLogado != null)
    {
%>
Bem Vindo, <b>
    <%= Html.Encode(SiteMVC.Models.ModuloBasico.VOs.ClasseAuxiliar.UsuarioLogado.nome)%></b>!
[
<%= Html.ActionLink("Deslogar", "Deslogar", "Usuario") %>
] [
<%= Html.ActionLink("Alterar Senha", "AlterarSenha/"+SiteMVC.Models.ModuloBasico.VOs.ClasseAuxiliar.UsuarioLogado.ID, "Usuario") %>
]
<br />
<%if (SiteMVC.Models.ModuloBasico.VOs.ClasseAuxiliar.AreaSelecionada != null)
  {
%>
Area Selecionada - <b>
    <%:SiteMVC.Models.ModuloBasico.VOs.ClasseAuxiliar.AreaSelecionada.descricao %></b><br />
<%}
  if (SiteMVC.Models.ModuloBasico.VOs.ClasseAuxiliar.DataSelecionada != default(DateTime))
  {
                      
%>
Data Selecionada - <b>
    <%:SiteMVC.Models.ModuloBasico.VOs.ClasseAuxiliar.DataSelecionada.ToString("dd/MM/yyyy")%></b><br />
<%} %>
<%if (SiteMVC.Models.ModuloBasico.VOs.ClasseAuxiliar.IsPrestacaoConta)
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
