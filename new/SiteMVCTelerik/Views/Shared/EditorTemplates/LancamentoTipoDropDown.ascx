<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<long>" %>
<%

    IEnumerable<SelectListItem> LancamentoTipoSelectList;
   
    SiteMVCTelerik.ModuloLancamentoTipo.Processos.ILancamentoTipoProcesso processoLancamentoTipo = SiteMVCTelerik.ModuloLancamentoTipo.Processos.LancamentoTipoProcesso.Instance;
    List<SiteMVCTelerik.Models.ModuloBasico.VOs.LancamentoTipo> municipios = processoLancamentoTipo.Consultar();

    //ViewData["municipios"] = 
    SiteMVCTelerik.Models.ModuloBasico.VOs.LancamentoTipo municipioInicial = new SiteMVCTelerik.Models.ModuloBasico.VOs.LancamentoTipo();
    municipioInicial.descricao = "Selecione...";
    municipios.Insert(0, municipioInicial);
    LancamentoTipoSelectList = from m in municipios
                               select new SelectListItem
                               {
                                   Selected = (m.id == Model),
                                   Text = m.descricao,
                                   Value = m.id.ToString()
                               };

 %>

 <%= Html.DropDownList("", LancamentoTipoSelectList,Model)%>