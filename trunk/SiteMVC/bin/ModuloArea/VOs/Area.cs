using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Objects.DataClasses;
using System.ComponentModel;
using System.Web.Mvc;
namespace SiteMVC.Models.ModuloBasico.VOs
{

    [MetadataType(typeof(AreaMetadata))]
    public partial class Area
    {

        internal class AreaMetadata
        {

            [Required(ErrorMessage = "A descrição é necessária para o cadastro.")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            [DisplayName("Descrição:")]
            public string descricao { get; set; }


            [RegularExpression(@"^[^0]+", ErrorMessage = "Escolha o Municipio")]
            [UIHint("MunicipioDropDown")]
            [DisplayName("Município:")]
            public long municipio_id { get; set; }

            // and if you don't want metadata for lastname, you can leave it out
        }
    }


    public class AreaFormViewModel
    {

        public Area Area { get; set; }

        public List<Municipio> Municipios { get; set; }

        public IEnumerable<SelectListItem> MunicipioSelectList { get; private set; }

        public SelectListItem MunicipioSelecionado { get; private set; }

        public AreaFormViewModel(Area area, List<Municipio> municipios)
        {
            this.Area = area;
            Municipio municipio = new Municipio();
            this.Municipios = municipios;
            this.CarregarMunicipioSelectList(Municipios, 0);

        }

        public AreaFormViewModel() { }

        public void CarregarMunicipioSelectList(List<Municipio> municipios, long  idSelecionado)
        {
            Municipio municipioInicial = new Municipio();
            municipioInicial.nome = "Selecione...";
            municipios.Insert(0, municipioInicial);
            this.MunicipioSelectList = from m in municipios
                                       select new SelectListItem
                                       {
                                           Selected = (m.ID == idSelecionado),
                                           Text = m.nome,
                                           Value = m.ID.ToString()
                                       };


        }

    }
}