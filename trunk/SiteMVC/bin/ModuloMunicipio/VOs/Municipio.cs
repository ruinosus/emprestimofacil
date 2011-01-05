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

    [MetadataType(typeof(MunicipioMetadata))]
    public partial class Municipio
    {
        
        internal class MunicipioMetadata
        {
            
            [Required(ErrorMessage = "O nome é necessário para o cadastro.")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            [DisplayName("Nome:")]
            public string nome { get; set; }


            [RegularExpression(@"^[^0]+", ErrorMessage = "Escolha a Uf")]
            [UIHint("UfDropDown")]
            [DisplayName("Uf:")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            public String uf { get; set; }

            // and if you don't want metadata for lastname, you can leave it out
        }
    }


   

    
}