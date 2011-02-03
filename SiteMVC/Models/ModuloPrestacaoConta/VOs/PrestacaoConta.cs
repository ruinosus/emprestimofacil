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

    [MetadataType(typeof(PrestacaoContaMetadata))]
    public partial class PrestacaoConta
    {
        
        internal class PrestacaoContaMetadata
        {

            
            [DisplayName("Valor de Parcelas em Aberto:")]
            [Range(1, 9999999999999, ErrorMessage = "Valor tem que ser maior que zero.")]
            public float? parcelareabertas { get; set; }

            [DisplayName("Valor do Total de despesas:")]
            [Range(1, 9999999999999, ErrorMessage = "Valor tem que ser maior que zero.")]
            public float totaldespesas { get; set; }

            [DisplayName("Valor Cancelado:")]
            [Range(1, 9999999999999, ErrorMessage = "Valor tem que ser maior que zero.")]
            public float valorcancelado { get; set; }

            [DisplayName("Valor Devolvido:")]
            [Range(1, 9999999999999, ErrorMessage = "Valor tem que ser maior que zero.")]
            public float valordevolvido { get; set; }

            [DisplayName("Valor Emprestado:")]
            [Range(1, 9999999999999, ErrorMessage = "Valor tem que ser maior que zero.")]
            public float valoremprestado { get; set; }

            [DisplayName("Valor Recebido:")]
            [Range(1, 9999999999999, ErrorMessage = "Valor tem que ser maior que zero.")]
            public float valorrecebido { get; set; }

            [DisplayName("Valor Saída:")]
            [Range(1, 9999999999999, ErrorMessage = "Valor tem que ser maior que zero.")]
            public float valorsaida { get; set; }

            [DisplayName("Data Expedição:")]
            [Required(ErrorMessage = "Informe a data da prestacao de contas")]
            public DateTime dataprestacao { get; set; }

            [RegularExpression(@"^[^0]+", ErrorMessage = "Escolha a Area.")]
            [UIHint("AreaDropDown")]
            [DisplayName("Area:")]
            public long area_id { get; set; }


        }
    }

    public class PrestacaoContaPesquisa
    {

        [Required(ErrorMessage = "A data inicial é necessária para a pesquisa.")]
        [DisplayName("Data Início:")]
        public DateTime DataInicio { get; set; }
        [Required(ErrorMessage = "A data final é necessária para a pesquisa.")]
        [DisplayName("Data Fim:")]
        public DateTime DataFim { get; set; }
    }








}