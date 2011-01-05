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

    [MetadataType(typeof(ClienteMetadata))]
    public partial class Cliente
    {

        internal class ClienteMetadata
        {

            [Required(ErrorMessage = "O nome é necessário para o cadastro.")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            [DisplayName("Descrição:")]
            public string nome { get; set; }

            [RegularExpression(@"^[^0]+", ErrorMessage = "Escolha a Area.")]
            [UIHint("AreaDropDown")]
            [DisplayName("Area:")]
            public long area_id { get; set; }

            [RegularExpression(@"^[^0]+", ErrorMessage = "Escolha o orgão expedidor.")]
            [UIHint("OrgaoExpedidorNomeDropDown")]
            [DisplayName("Orgão Expedidor:")]
            public long orgaosexpedidoresnome_id { get; set; }

            [RegularExpression(@"^[^0]+", ErrorMessage = "Escolha o estado civil.")]
            [UIHint("EstadoCivilTipoDropDown")]
            [DisplayName("Estado Civil:")]
            public long estadoscivistipo_id { get; set; }

            [RegularExpression(@"^[^0]+", ErrorMessage = "Escolha a escolaridade.")]
            [UIHint("EscolaridadeDropDown")]
            [DisplayName("Escolaridade:")]
            public long escolaridade_id { get; set; }

            // and if you don't want metadata for lastname, you can leave it out
        }
    }


   
}