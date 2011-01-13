<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<long>" %>
<%

    IEnumerable<SelectListItem> ClienteSelectList;
   
    SiteMVC.ModuloCliente.Processos.IClienteProcesso processoCliente = SiteMVC.ModuloCliente.Processos.ClienteProcesso.Instance;
    List<SiteMVC.Models.ModuloBasico.VOs.Cliente> municipios = processoCliente.Consultar();

    //ViewData["municipios"] = 
    SiteMVC.Models.ModuloBasico.VOs.Cliente municipioInicial = new SiteMVC.Models.ModuloBasico.VOs.Cliente();
    municipioInicial.nome = "Selecione...";
    municipios.Insert(0, municipioInicial);
    ClienteSelectList = from m in municipios
                               select new SelectListItem
                               {
                                   Selected = (m.ID == Model),
                                   Text = m.nome,
                                   Value = m.ID.ToString()
                               };

 %>

 <%= Html.DropDownList("", ClienteSelectList,Model)%>