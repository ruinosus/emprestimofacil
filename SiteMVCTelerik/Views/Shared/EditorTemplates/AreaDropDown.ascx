<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<long>" %>
<%

    IEnumerable<SelectListItem> AreaSelectList;
   
    SiteMVCTelerik.ModuloArea.Processos.IAreaProcesso processoArea = SiteMVCTelerik.ModuloArea.Processos.AreaProcesso.Instance;
    List<SiteMVCTelerik.Models.ModuloBasico.VOs.Area> municipios = processoArea.Consultar();

    //ViewData["municipios"] = 
    SiteMVCTelerik.Models.ModuloBasico.VOs.Area municipioInicial = new SiteMVCTelerik.Models.ModuloBasico.VOs.Area();
    municipioInicial.descricao = "Selecione...";
    municipios.Insert(0, municipioInicial);
    AreaSelectList = from m in municipios
                               select new SelectListItem
                               {
                                   Selected = (m.ID == Model),
                                   Text = m.descricao,
                                   Value = m.ID.ToString()
                               };

 %>

 <%= Html.DropDownList("", AreaSelectList,Model)%>