<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<long?>" %>
<%

    IEnumerable<SelectListItem> TipoEmprestimoSelectList;
   
    SiteMVCTelerik.ModuloTipoEmprestimo.Processos.ITipoEmprestimoProcesso processoTipoEmprestimo = SiteMVCTelerik.ModuloTipoEmprestimo.Processos.TipoEmprestimoProcesso.Instance;
    List<SiteMVCTelerik.Models.ModuloBasico.VOs.TipoEmprestimo> municipios = processoTipoEmprestimo.Consultar();

    //ViewData["municipios"] = 
    SiteMVCTelerik.Models.ModuloBasico.VOs.TipoEmprestimo municipioInicial = new SiteMVCTelerik.Models.ModuloBasico.VOs.TipoEmprestimo();
    municipioInicial.descricao = "Selecione...";
    municipios.Insert(0, municipioInicial);
    TipoEmprestimoSelectList = from m in municipios
                               select new SelectListItem
                               {
                                   Selected = (m.id == Model.Value),
                                   Text = m.descricao,
                                   Value = m.id.ToString()
                               };

 %>

 <%= Html.DropDownList("", TipoEmprestimoSelectList,Model.Value)%>