<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<long?>" %>
<%

    IEnumerable<SelectListItem> EscolaridadeSelectList;
   
    SiteMVC.ModuloEscolaridade.Processos.IEscolaridadeProcesso processoEscolaridade = SiteMVC.ModuloEscolaridade.Processos.EscolaridadeProcesso.Instance;
    List<SiteMVC.Models.ModuloBasico.VOs.Escolaridade> municipios = processoEscolaridade.Consultar();

    //ViewData["municipios"] = 
    SiteMVC.Models.ModuloBasico.VOs.Escolaridade municipioInicial = new SiteMVC.Models.ModuloBasico.VOs.Escolaridade();
    municipioInicial.descricao = "Selecione...";
    municipios.Insert(0, municipioInicial);
    EscolaridadeSelectList = from m in municipios
                               select new SelectListItem
                               {
                                   Selected = (m.ID == Model.Value),
                                   Text = m.descricao,
                                   Value = m.ID.ToString()
                               };

 %>

 <%= Html.DropDownList("", EscolaridadeSelectList,Model.Value)%>