<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<long>" %>
<%

    IEnumerable<SelectListItem> OrgaoExpedidorNomeSelectList;
   
    SiteMVC.ModuloOrgaoExpedidorNome.Processos.IOrgaoExpedidorNomeProcesso processoOrgaoExpedidorNome = SiteMVC.ModuloOrgaoExpedidorNome.Processos.OrgaoExpedidorNomeProcesso.Instance;
    List<SiteMVC.Models.ModuloBasico.VOs.OrgaoExpedidorNome> municipios = processoOrgaoExpedidorNome.Consultar();

    //ViewData["municipios"] = 
    SiteMVC.Models.ModuloBasico.VOs.OrgaoExpedidorNome municipioInicial = new SiteMVC.Models.ModuloBasico.VOs.OrgaoExpedidorNome();
    municipioInicial.descricao = "Selecione...";
    municipios.Insert(0, municipioInicial);
    OrgaoExpedidorNomeSelectList = from m in municipios
                               select new SelectListItem
                               {
                                   Selected = (m.ID == Model),
                                   Text = m.descricao,
                                   Value = m.ID.ToString()
                               };

 %>

 <%= Html.DropDownList("", OrgaoExpedidorNomeSelectList,Model)%>