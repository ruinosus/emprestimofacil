<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<long?>" %>
<%

    IEnumerable<SelectListItem> TipoEmprestimoSelectList;
   
    SiteMVC.ModuloTipoEmprestimo.Processos.ITipoEmprestimoProcesso processoTipoEmprestimo = SiteMVC.ModuloTipoEmprestimo.Processos.TipoEmprestimoProcesso.Instance;
    List<SiteMVC.Models.ModuloBasico.VOs.TipoEmprestimo> municipios = processoTipoEmprestimo.Consultar();

    //ViewData["municipios"] = 
    SiteMVC.Models.ModuloBasico.VOs.TipoEmprestimo municipioInicial = new SiteMVC.Models.ModuloBasico.VOs.TipoEmprestimo();
    municipioInicial.descricao = "Selecione...";
    municipios.Insert(0, municipioInicial);
    TipoEmprestimoSelectList = from m in municipios
                               select new SelectListItem
                               {
                                   Selected = (m.ID == Model.Value),
                                   Text = m.descricao,
                                   Value = m.ID.ToString()
                               };

 %>

 <%= Html.DropDownList("", TipoEmprestimoSelectList,Model.Value)%>