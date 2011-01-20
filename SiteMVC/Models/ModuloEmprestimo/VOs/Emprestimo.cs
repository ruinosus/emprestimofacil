﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Objects.DataClasses;
using System.ComponentModel;
using System.Web.Mvc;
namespace SiteMVC.Models.ModuloBasico.VOs
{

    [MetadataType(typeof(EmprestimoMetadata))]
    public partial class Emprestimo
    {
   
        internal class EmprestimoMetadata
        {

            [Required(ErrorMessage = "A data do Emprestimo é necessária para o cadastro.")]
            [DisplayName("Data Emprestimo:")]
            public DateTime data_emprestimo { get; set; }

            [Required(ErrorMessage = "O juros é necessário para o cadastro.")]
            [DisplayName("Juros:")]
            public float juros { get; set; }

            [Required(ErrorMessage = "O valor é necessário para o cadastro.")]
            [DisplayName("Valor:")]
            public float valor { get; set; }


            [RegularExpression(@"^[^0]+", ErrorMessage = "Escolha o Cliente")]
            [UIHint("ClienteDropDown")]
            [DisplayName("Cliente:")]
            public long cliente_id { get; set; }

            [RegularExpression(@"^[^0]+", ErrorMessage = "Escolha o prazo do pagamento")]
            [UIHint("PrazoPagamentoDropDown")]
            [DisplayName("Prazo Pagamento:")]
            public long prazospagamento_id { get; set; }

            [RegularExpression(@"^[^0]+", ErrorMessage = "Escolha o Tipo do Emprestimo")]
            [UIHint("TipoEmprestimoDropDown")]
            [DisplayName("Tipo Emprestimo:")]
            public long? tipoemprestimo_id { get; set; }

            [RegularExpression(@"^[^0]+", ErrorMessage = "Escolha o Usuário")]
            [UIHint("UsuarioDropDown")]
            [DisplayName("Usuário:")]
            public long usuario_id { get; set; }

            // and if you don't want metadata for lastname, you can leave it out
        }
    }

    public class EmprestimoFormViewModel
    {

        public Emprestimo Emprestimo { get; set; }

        public Cliente Cliente { get; set; }


    }


}