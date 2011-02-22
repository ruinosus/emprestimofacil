<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<long>" %>
<%

    IEnumerable<SelectListItem> UsuarioTipoSelectList;
   
    SiteMVCTelerik.ModuloUsuarioTipo.Processos.IUsuarioTipoProcesso processoUsuarioTipo = SiteMVCTelerik.ModuloUsuarioTipo.Processos.UsuarioTipoProcesso.Instance;
    List<SiteMVCTelerik.Models.ModuloBasico.VOs.UsuarioTipo> municipios = processoUsuarioTipo.Consultar();

    //ViewData["municipios"] = 
    SiteMVCTelerik.Models.ModuloBasico.VOs.UsuarioTipo municipioInicial = new SiteMVCTelerik.Models.ModuloBasico.VOs.UsuarioTipo();
    municipioInicial.descricao = "Selecione...";
    municipios.Insert(0, municipioInicial);
    UsuarioTipoSelectList = from m in municipios
                               select new SelectListItem
                               {
                                   Selected = (m.ID == Model),
                                   Text = m.descricao,
                                   Value = m.ID.ToString()
                               };

 %>

 <%= Html.DropDownList("", UsuarioTipoSelectList,Model)%>