<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<long?>" %>
<%

    IEnumerable<SelectListItem> EscolaridadeSelectList;
   
    SiteMVCTelerik.ModuloEscolaridade.Processos.IEscolaridadeProcesso processoEscolaridade = SiteMVCTelerik.ModuloEscolaridade.Processos.EscolaridadeProcesso.Instance;
    List<SiteMVCTelerik.Models.ModuloBasico.VOs.Escolaridade> municipios = processoEscolaridade.Consultar();

    //ViewData["municipios"] = 
    SiteMVCTelerik.Models.ModuloBasico.VOs.Escolaridade municipioInicial = new SiteMVCTelerik.Models.ModuloBasico.VOs.Escolaridade();
    municipioInicial.descricao = "Selecione...";
    municipios.Insert(0, municipioInicial);
    EscolaridadeSelectList = from m in municipios
                               select new SelectListItem
                               {
                                   Selected = (m.id == Model.Value),
                                   Text = m.descricao,
                                   Value = m.id.ToString()
                               };

 %>

 <%= Html.DropDownList("", EscolaridadeSelectList,Model.Value)%>