using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SiteMVC.Models.ModuloBasico.VOs
{
    public class CpfAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }
            var cpf = (string)value;
            return Validacoes.ValidaCPF(cpf);
        }
    }

    public class CnpjAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            var cnpj = (string)value;
            return Validacoes.ValidaCNPJ(cnpj);
        }
    }
}

//public class PriceAttribute : ValidationAttribute
//{
//    public double MinPrice { get; set; }

//    public override bool IsValid(object value)
//    {
//        if (value == null)
//        {
//            return true;
//        }
//        var price = (double)value;
//        if (price < MinPrice)
//        {
//            return false;
//        }
//        double cents = price - Math.Truncate(price);
//        if (cents < 0.99 || cents >= 0.995)
//        {
//            return false;
//        }

//        return true;
//    }
//}

//public class ProductViewModel
//{
//    [Price(MinPrice = 1.99)]
//    public double Price { get; set; }

//    [Required]
//    public string Title { get; set; }
//}