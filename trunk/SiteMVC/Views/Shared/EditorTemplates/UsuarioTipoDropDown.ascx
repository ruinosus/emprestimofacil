<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<long?>" %>
<%

    IEnumerable<SelectListItem> UsuarioTipoSelectList;
   
    SiteMVC.ModuloUsuarioTipo.Processos.IUsuarioTipoProcesso processoUsuarioTipo = SiteMVC.ModuloUsuarioTipo.Processos.UsuarioTipoProcesso.Instance;
    List<SiteMVC.Models.ModuloBasico.VOs.UsuarioTipo> municipios = processoUsuarioTipo.Consultar();

    //ViewData["municipios"] = 
    SiteMVC.Models.ModuloBasico.VOs.UsuarioTipo municipioInicial = new SiteMVC.Models.ModuloBasico.VOs.UsuarioTipo();
    municipioInicial.descricao = "Selecione...";
    municipios.Insert(0, municipioInicial);
    UsuarioTipoSelectList = from m in municipios
                               select new SelectListItem
                               {
                                   Selected = (m.ID == Model.Value),
                                   Text = m.descricao,
                                   Value = m.ID.ToString()
                               };

 %>

 <%= Html.DropDownList("", UsuarioTipoSelectList,Model.Value)%>