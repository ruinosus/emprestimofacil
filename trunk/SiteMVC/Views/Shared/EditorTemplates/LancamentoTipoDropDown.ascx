<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<long>" %>
<%

    IEnumerable<SelectListItem> LancamentoTipoSelectList;
   
    SiteMVC.ModuloLancamentoTipo.Processos.ILancamentoTipoProcesso processoLancamentoTipo = SiteMVC.ModuloLancamentoTipo.Processos.LancamentoTipoProcesso.Instance;
    List<SiteMVC.Models.ModuloBasico.VOs.LancamentoTipo> municipios = processoLancamentoTipo.Consultar();

    //ViewData["municipios"] = 
    SiteMVC.Models.ModuloBasico.VOs.LancamentoTipo municipioInicial = new SiteMVC.Models.ModuloBasico.VOs.LancamentoTipo();
    municipioInicial.descricao = "Selecione...";
    municipios.Insert(0, municipioInicial);
    LancamentoTipoSelectList = from m in municipios
                               select new SelectListItem
                               {
                                   Selected = (m.ID == Model),
                                   Text = m.descricao,
                                   Value = m.ID.ToString()
                               };

 %>

 <%= Html.DropDownList("", LancamentoTipoSelectList,Model)%>