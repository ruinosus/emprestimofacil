using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Objects.DataClasses;
using System.ComponentModel;
 namespace SiteMVC.Models.ModuloBasico.VOs
{

    [MetadataType(typeof(StatusParcelaMetadata))]
    public partial class StatusParcela 
    {

        internal class StatusParcelaMetadata
        {

            [Required(ErrorMessage = "A descrição é necessária para o cadastro.")]            
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            [DisplayName("Descrição:")]
            public string descricao { get; set; }

            // and if you don't want metadata for lastname, you can leave it out
        }
    }

}