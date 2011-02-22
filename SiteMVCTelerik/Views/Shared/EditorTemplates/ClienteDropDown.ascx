<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<long>" %>
<%

    IEnumerable<SelectListItem> ClienteSelectList;
   
    SiteMVCTelerik.ModuloCliente.Processos.IClienteProcesso processoCliente = SiteMVCTelerik.ModuloCliente.Processos.ClienteProcesso.Instance;
    SiteMVCTelerik.Models.ModuloBasico.VOs.Cliente c = new SiteMVCTelerik.Models.ModuloBasico.VOs.Cliente();
    c.area_id = SiteMVCTelerik.Models.ModuloBasico.VOs.ClasseAuxiliar.AreaSelecionada.ID;
    List<SiteMVCTelerik.Models.ModuloBasico.VOs.Cliente> municipios = processoCliente.Consultar(c,SiteMVCTelerik.ModuloBasico.Enums.TipoPesquisa.E);

    //ViewData["municipios"] = 
    SiteMVCTelerik.Models.ModuloBasico.VOs.Cliente municipioInicial = new SiteMVCTelerik.Models.ModuloBasico.VOs.Cliente();
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