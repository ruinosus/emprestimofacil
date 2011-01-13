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

    [MetadataType(typeof(ParcelaMetadata))]
    public partial class Parcela
    {

        internal class ParcelaMetadata
        {

            [Required(ErrorMessage = "Informe o valor a ser pago.")]
            [DisplayName("Valor Pago:")]
            [Range(1, 9999999999999, ErrorMessage = "Valor tem que ser maior que zero.")]
            public long? valor_pago { get; set; }

        }
    }





}