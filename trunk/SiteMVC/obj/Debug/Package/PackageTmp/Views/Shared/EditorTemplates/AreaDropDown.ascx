<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<long>" %>
<%

    IEnumerable<SelectListItem> AreaSelectList;
   
    SiteMVC.ModuloArea.Processos.IAreaProcesso processoArea = SiteMVC.ModuloArea.Processos.AreaProcesso.Instance;
    List<SiteMVC.Models.ModuloBasico.VOs.Area> municipios = processoArea.Consultar();

    //ViewData["municipios"] = 
    SiteMVC.Models.ModuloBasico.VOs.Area municipioInicial = new SiteMVC.Models.ModuloBasico.VOs.Area();
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