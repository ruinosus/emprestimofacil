<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<long?>" %>
<%

    IEnumerable<SelectListItem> EstadoCivilTipoSelectList;
   
    SiteMVCTelerik.ModuloEstadoCivilTipo.Processos.IEstadoCivilTipoProcesso processoEstadoCivilTipo = SiteMVCTelerik.ModuloEstadoCivilTipo.Processos.EstadoCivilTipoProcesso.Instance;
    List<SiteMVCTelerik.Models.ModuloBasico.VOs.EstadoCivilTipo> municipios = processoEstadoCivilTipo.Consultar();

    //ViewData["municipios"] = 
    SiteMVCTelerik.Models.ModuloBasico.VOs.EstadoCivilTipo municipioInicial = new SiteMVCTelerik.Models.ModuloBasico.VOs.EstadoCivilTipo();
    municipioInicial.descricao = "Selecione...";
    municipios.Insert(0, municipioInicial);
    EstadoCivilTipoSelectList = from m in municipios
                               select new SelectListItem
                               {
                                   Selected = (m.id == Model.Value),
                                   Text = m.descricao,
                                   Value = m.id.ToString()
                               };

 %>

 <%= Html.DropDownList("", EstadoCivilTipoSelectList,Model.Value)%>