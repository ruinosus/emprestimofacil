<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<long?>" %>
<%

    IEnumerable<SelectListItem> OrgaoExpedidorNomeSelectList;
   
    SiteMVCTelerik.ModuloOrgaoExpedidorNome.Processos.IOrgaoExpedidorNomeProcesso processoOrgaoExpedidorNome = SiteMVCTelerik.ModuloOrgaoExpedidorNome.Processos.OrgaoExpedidorNomeProcesso.Instance;
    List<SiteMVCTelerik.Models.ModuloBasico.VOs.OrgaoExpedidorNome> municipios = processoOrgaoExpedidorNome.Consultar();

    //ViewData["municipios"] = 
    SiteMVCTelerik.Models.ModuloBasico.VOs.OrgaoExpedidorNome municipioInicial = new SiteMVCTelerik.Models.ModuloBasico.VOs.OrgaoExpedidorNome();
    municipioInicial.descricao = "Selecione...";
    municipios.Insert(0, municipioInicial);
    OrgaoExpedidorNomeSelectList = from m in municipios
                               select new SelectListItem
                               {
                                   Selected = (m.id == Model.Value),
                                   Text = m.descricao,
                                   Value = m.id.ToString()
                               };

 %>

 <%= Html.DropDownList("", OrgaoExpedidorNomeSelectList,Model.Value)%>