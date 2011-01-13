<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<long>" %>
<%

    IEnumerable<SelectListItem> UsuarioSelectList;
   
    SiteMVC.ModuloUsuario.Processos.IUsuarioProcesso processoUsuario = SiteMVC.ModuloUsuario.Processos.UsuarioProcesso.Instance;
    List<SiteMVC.Models.ModuloBasico.VOs.Usuario> municipios = processoUsuario.Consultar();

    //ViewData["municipios"] = 
    SiteMVC.Models.ModuloBasico.VOs.Usuario municipioInicial = new SiteMVC.Models.ModuloBasico.VOs.Usuario();
    municipioInicial.nome = "Selecione...";
    municipios.Insert(0, municipioInicial);
    UsuarioSelectList = from m in municipios
                               select new SelectListItem
                               {
                                   Selected = (m.ID == Model),
                                   Text = m.nome,
                                   Value = m.ID.ToString()
                               };

 %>

 <%= Html.DropDownList("", UsuarioSelectList,Model)%>