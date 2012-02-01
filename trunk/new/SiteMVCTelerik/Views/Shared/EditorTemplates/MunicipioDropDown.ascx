<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<long>" %>
<%

    IEnumerable<SelectListItem> MunicipioSelectList;
   
    SiteMVCTelerik.ModuloMunicipio.Processos.IMunicipioProcesso processoMunicipio = SiteMVCTelerik.ModuloMunicipio.Processos.MunicipioProcesso.Instance;
    List<SiteMVCTelerik.Models.ModuloBasico.VOs.Municipio> municipios = processoMunicipio.Consultar();

    //ViewData["municipios"] = 
    SiteMVCTelerik.Models.ModuloBasico.VOs.Municipio municipioInicial = new SiteMVCTelerik.Models.ModuloBasico.VOs.Municipio();
    municipioInicial.nome = "Selecione...";
    municipios.Insert(0, municipioInicial);
    MunicipioSelectList = from m in municipios
                               select new SelectListItem
                               {
                                   Selected = (m.id == Model),
                                   Text = m.nome,
                                   Value = m.id.ToString()
                               };

 %>

 <%= Html.DropDownList("", MunicipioSelectList,Model)%>