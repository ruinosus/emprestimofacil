<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<long>" %>
<%

    IEnumerable<SelectListItem> EstadoCivilTipoSelectList;
   
    SiteMVC.ModuloEstadoCivilTipo.Processos.IEstadoCivilTipoProcesso processoEstadoCivilTipo = SiteMVC.ModuloEstadoCivilTipo.Processos.EstadoCivilTipoProcesso.Instance;
    List<SiteMVC.Models.ModuloBasico.VOs.EstadoCivilTipo> municipios = processoEstadoCivilTipo.Consultar();

    //ViewData["municipios"] = 
    SiteMVC.Models.ModuloBasico.VOs.EstadoCivilTipo municipioInicial = new SiteMVC.Models.ModuloBasico.VOs.EstadoCivilTipo();
    municipioInicial.descricao = "Selecione...";
    municipios.Insert(0, municipioInicial);
    EstadoCivilTipoSelectList = from m in municipios
                               select new SelectListItem
                               {
                                   Selected = (m.ID == Model),
                                   Text = m.descricao,
                                   Value = m.ID.ToString()
                               };

 %>

 <%= Html.DropDownList("", EstadoCivilTipoSelectList,Model)%>