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

    [MetadataType(typeof(DespesaMetadata))]
    public partial class Despesa
    {
        

       
        internal class DespesaMetadata
        {

            [Required(ErrorMessage = "O valor é necessário para o cadastro.")]
            [DisplayName("Valor:")]
            public float valor { get; set; }

            [DisplayName("Data:")]
            public DateTime data{ get; set; }

            [RegularExpression(@"^[^0]+", ErrorMessage = "Escolha o Usuário")]
            [UIHint("UsuarioDropDown")]
            [DisplayName("Usuário:")]
            public long usuario_id { get; set; }

            [RegularExpression(@"^[^0]+", ErrorMessage = "Escolha o tipo da despesa")]
            [UIHint("DespesaTipoDropDown")]
            [DisplayName("Tipo de Despesa:")]
            public long despesatipo_id { get; set; }

            [DisplayFormat(ConvertEmptyStringToNull = false)]
            [DisplayName("Justificativa:")]
            public string justificativa { get; set; }

            

        }
    }





}