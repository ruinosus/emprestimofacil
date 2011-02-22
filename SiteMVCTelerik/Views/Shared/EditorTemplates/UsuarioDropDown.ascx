<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<long>" %>
<%

    IEnumerable<SelectListItem> UsuarioSelectList;
   
    SiteMVCTelerik.ModuloUsuario.Processos.IUsuarioProcesso processoUsuario = SiteMVCTelerik.ModuloUsuario.Processos.UsuarioProcesso.Instance;
    List<SiteMVCTelerik.Models.ModuloBasico.VOs.Usuario> municipios = processoUsuario.Consultar();

    //ViewData["municipios"] = 
    SiteMVCTelerik.Models.ModuloBasico.VOs.Usuario municipioInicial = new SiteMVCTelerik.Models.ModuloBasico.VOs.Usuario();
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