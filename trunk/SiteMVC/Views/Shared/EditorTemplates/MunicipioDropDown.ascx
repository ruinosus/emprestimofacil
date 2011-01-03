<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<long>" %>
<%

    IEnumerable<SelectListItem> MunicipioSelectList;
   
    SiteMVC.ModuloMunicipio.Processos.IMunicipioProcesso processoMunicipio = SiteMVC.ModuloMunicipio.Processos.MunicipioProcesso.Instance;
    List<SiteMVC.Models.ModuloBasico.VOs.Municipio> municipios = processoMunicipio.Consultar();

    //ViewData["municipios"] = 
    SiteMVC.Models.ModuloBasico.VOs.Municipio municipioInicial = new SiteMVC.Models.ModuloBasico.VOs.Municipio();
    municipioInicial.nome = "Selecione...";
    municipios.Insert(0, municipioInicial);
   MunicipioSelectList = from m in municipios
                               select new SelectListItem
                               {
                                   Text = m.nome,
                                   Value = m.ID.ToString()
                               };

 %>

 <%= Html.DropDownList("", MunicipioSelectList,Model)%>