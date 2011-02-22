<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<long>" %>
<%

    IEnumerable<SelectListItem> DespesaTipoSelectList;
   
    SiteMVC.ModuloDespesaTipo.Processos.IDespesaTipoProcesso processoDespesaTipo = SiteMVC.ModuloDespesaTipo.Processos.DespesaTipoProcesso.Instance;
    List<SiteMVC.Models.ModuloBasico.VOs.DespesaTipo> municipios = processoDespesaTipo.Consultar();

    //ViewData["municipios"] = 
    SiteMVC.Models.ModuloBasico.VOs.DespesaTipo municipioInicial = new SiteMVC.Models.ModuloBasico.VOs.DespesaTipo();
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