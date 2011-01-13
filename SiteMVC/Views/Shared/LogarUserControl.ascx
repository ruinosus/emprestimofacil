<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (SiteMVC.Models.ModuloBasico.VOs.ClasseAuxiliar.UsuarioLogado!= null) {
%>
        Bem Vindo, <b><%= Html.Encode(SiteMVC.Models.ModuloBasico.VOs.ClasseAuxiliar.UsuarioLogado.nome)%></b>!
        [ <%= Html.ActionLink("Deslogar", "Deslogar", "Usuario") %> ]
        [ <%= Html.ActionLink("Alterar Senha", "AlterarSenha/"+SiteMVC.Models.ModuloBasico.VOs.ClasseAuxiliar.UsuarioLogado.ID, "Usuario") %> ]
<%
    }
    else {
%> 
        [ <%= Html.ActionLink("Logar", "Logar", "Usuario")%> ]
<%
    }
%>
