<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<long>" %>
<%

    IEnumerable<SelectListItem> PrazoPagamentoSelectList;
   
    SiteMVCTelerik.ModuloPrazoPagamento.Processos.IPrazoPagamentoProcesso processoPrazoPagamento = SiteMVCTelerik.ModuloPrazoPagamento.Processos.PrazoPagamentoProcesso.Instance;
    List<SiteMVCTelerik.Models.ModuloBasico.VOs.PrazoPagamento> municipios = processoPrazoPagamento.Consultar();

    //ViewData["municipios"] = 
    SiteMVCTelerik.Models.ModuloBasico.VOs.PrazoPagamento municipioInicial = new SiteMVCTelerik.Models.ModuloBasico.VOs.PrazoPagamento();
    municipioInicial.descricao = "Selecione...";
    municipios.Insert(0, municipioInicial);
    PrazoPagamentoSelectList = from m in municipios
                               select new SelectListItem
                               {
                                   Selected = (m.ID == Model),
                                   Text = m.descricao,
                                   Value = m.ID.ToString()
                               };

 %>

 <%= Html.DropDownList("", PrazoPagamentoSelectList,Model)%>