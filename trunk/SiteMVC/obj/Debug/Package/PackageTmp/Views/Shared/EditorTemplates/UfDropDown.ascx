﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<String>" %>

<%
    IEnumerable<SelectListItem> sl;
    //List<SiteMVC.Models.ModuloBasico.VOs.Municipio> lista = new List<SiteMVC.Models.ModuloBasico.VOs.Municipio>();

    //lista.Add(new SiteMVC.Models.ModuloBasico.VOs.Municipio
    //{
    //    nome = "Selecione...",
    //    uf = "0"
    //});
    //lista.Add(new SiteMVC.Models.ModuloBasico.VOs.Municipio
    //{
    //    nome = "Acre",
    //    uf = "AC"
    //});

    //lista.Add(new SiteMVC.Models.ModuloBasico.VOs.Municipio
    //{
    //    nome = "Alagoas",
    //    uf = "AL"
    //});


    sl = new SelectList(new[]{
  new SelectListItem{ Text="Selecione...", Value="0"},
  new SelectListItem{ Text="Acre", Value="AC"},
  new SelectListItem{ Text="Alagoas", Value="AL"},
  new SelectListItem{ Text="Amapá", Value="AP"},
  new SelectListItem{ Text="Bahia", Value="AM"},
  new SelectListItem{ Text="Ceará", Value="CE"},
  new SelectListItem{ Text="Distrito Federal", Value="DF"},
  new SelectListItem{ Text="Espírito Santo", Value="ES"},
  new SelectListItem{ Text="Goiás", Value="GO"},
  new SelectListItem{ Text="Maranhão", Value="MA"},
  new SelectListItem{ Text="Mato Grosso", Value="MT"},
  new SelectListItem{ Text="Mato Grosso do Sul", Value="MS"},
  new SelectListItem{ Text="Minas Gerais", Value="MG"},
  new SelectListItem{ Text="Pará", Value="PA"},
  new SelectListItem{ Text="Paraíba", Value="PB"},
  new SelectListItem{ Text="Paraná", Value="PR"},
  new SelectListItem{ Text="Pernambuco", Value="PE"},
  new SelectListItem{ Text="Piauí", Value="PI"},
  new SelectListItem{ Text="Rio de Janeiro", Value="RJ"},
  new SelectListItem{ Text="Rio Grande do Norte", Value="RN"},
  new SelectListItem{ Text="Rio Grande do Sul", Value="RS"},
  new SelectListItem{ Text="Rondônia", Value="RO"},
  new SelectListItem{ Text="Roraima", Value="RR"},
  new SelectListItem{ Text="Santa Catarina", Value="SC"},
  new SelectListItem{ Text="São Paulo", Value="SP"},
  new SelectListItem{ Text="Sergipe", Value="SE"},
  new SelectListItem{ Text="Tocantins", Value="TO"}}, "Value", "Text", Model);

    ////sl = null;

    //sl = from m in lista
    //     select new SelectListItem
    //     {
    //         Selected = (m.uf.Equals(Model)),
    //         Text = m.nome,
    //         Value = m.uf
    //     };
    
    
     %>

<%= Html.DropDownList("", sl)%>