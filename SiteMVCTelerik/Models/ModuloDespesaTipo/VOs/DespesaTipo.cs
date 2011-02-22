using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Objects.DataClasses;
using System.ComponentModel;
using System.Web.Mvc;
using SiteMVCTelerik.Helpers;
namespace SiteMVCTelerik.Models.ModuloBasico.VOs
{

    [MetadataType(typeof(DespesaTipoMetadata))]
    public partial class DespesaTipo
    {
        
        internal class DespesaTipoMetadata
        {
            [Required(ErrorMessage = "A descriçao é necessária para o cadastro.")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            [DisplayName("Descriçao:")]
            public string descricao { get; set; }

            [Required(ErrorMessage = "A pós descriçao é necessária para o cadastro.")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            [DisplayName("Pós Descriçao:")]
            public string posdescricao { get; set; }

        }
    }





}