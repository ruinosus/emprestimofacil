<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<long>" %>
<%

    IEnumerable<SelectListItem> DespesaTipoSelectList;
   
    SiteMVCTelerik.ModuloDespesaTipo.Processos.IDespesaTipoProcesso processoDespesaTipo = SiteMVCTelerik.ModuloDespesaTipo.Processos.DespesaTipoProcesso.Instance;
    List<SiteMVCTelerik.Models.ModuloBasico.VOs.DespesaTipo> municipios = processoDespesaTipo.Consultar();

    //ViewData["municipios"] = 
    SiteMVCTelerik.Models.ModuloBasico.VOs.DespesaTipo municipioInicial = new SiteMVCTelerik.Models.ModuloBasico.VOs.DespesaTipo();
    municipioInicial.descricao = "Selecione...";
    municipios.Insert(0, municipioInicial);
    DespesaTipoSelectList = from m in municipios
                               select new SelectListItem
                               {
                                   Selected = (m.ID == Model),
                                   Text = m.descricao,
                                   Value = m.ID.ToString()
                               };

 %>

 <%= Html.DropDownList("", DespesaTipoSelectList,Model)%>