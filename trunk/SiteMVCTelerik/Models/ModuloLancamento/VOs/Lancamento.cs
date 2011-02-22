using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Objects.DataClasses;
using System.ComponentModel;
using System.Web.Mvc;
namespace SiteMVCTelerik.Models.ModuloBasico.VOs
{

    [MetadataType(typeof(LancamentoMetadata))]
    public partial class Lancamento
    {

      
        internal class LancamentoMetadata
        {
            [Required(ErrorMessage = "A fonte é necessária para o cadastro.")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            [DisplayName("Fonte:")]
            public string fonte { get; set; }

            
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            [DisplayName("observações:")]
            public string observacoes { get; set; }

            [DisplayFormat(ConvertEmptyStringToNull = false)]
            [DisplayName("Outras Informações:")]
            public string outrasinfos { get; set; }



            [Required(ErrorMessage = "Informe a data do Lançamento.")]
            [DisplayName("Data do Lancamento:")]
            public DateTime data { get; set; }

            [Required(ErrorMessage = "O valor é necessário para o cadastro.")]
            [DisplayName("Valor:")]
            public float valor { get; set; }
            
           [RegularExpression(@"^[^0]+", ErrorMessage = "Escolha o Tipo do Lancamento")]
           [UIHint("LancamentoTipoDropDown")]
            [DisplayName("Tipo Lancamento:")]
            public long lancamentotipo_id { get; set; }

            [RegularExpression(@"^[^0]+", ErrorMessage = "Escolha o Usuário")]
            [UIHint("UsuarioDropDown")]
            [DisplayName("Usuário:")]
            public long usuario_id { get; set; }

            // and if you don't want metadata for lastname, you can leave it out
        }
    }


}