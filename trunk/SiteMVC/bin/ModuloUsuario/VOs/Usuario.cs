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

    [MetadataType(typeof(UsuarioMetadata))]
    public partial class Usuario
    {

        internal class UsuarioMetadata
        {

            [Required(ErrorMessage = "O nome é necessário para o cadastro.")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            [DisplayName("Nome:")]
            public string nome { get; set; }

            [Required(ErrorMessage = "O login é necessário para o cadastro.")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            [DisplayName("Login:")]
            public string login { get; set; }

            [Required(ErrorMessage = "A Senha é necessária para o cadastro.")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            [DisplayName("Senha:")]
            public string senha { get; set; }

            [RegularExpression(@"^[^0]+", ErrorMessage = "Escolha a Area.")]
            [UIHint("AreaDropDown")]
            [DisplayName("Area:")]
            public long area_id { get; set; }

            [RegularExpression(@"^[^0]+", ErrorMessage = "Escolha o orgão expedidor.")]
            [UIHint("OrgaoExpedidorNomeDropDown")]
            [DisplayName("Orgão Expedidor:")]
            public long? orgaosexpedidoresnome_id { get; set; }

            [RegularExpression(@"^[^0]+", ErrorMessage = "Escolha o tipo do usuário.")]
            [UIHint("UsuarioTipoDropDown")]
            [DisplayName("Orgão Expedidor:")]
            public long? usuariotipo_id { get; set; }

            [RegularExpression(@"^[^0]+", ErrorMessage = "Escolha o estado civil.")]
            [UIHint("EstadoCivilTipoDropDown")]
            [DisplayName("Estado Civil:")]
            public long? estadoscivistipo_id { get; set; }

            [RegularExpression(@"^[^0]+", ErrorMessage = "Escolha a escolaridade.")]
            [UIHint("EscolaridadeDropDown")]
            [DisplayName("Escolaridade:")]
            public long? escolaridade_id { get; set; }

            [DisplayName("Bairro Residencial:")]
            public string bairro_resid { get; set; }

            [DisplayName("Celularl:")]
            public string celular { get; set; }

            [DisplayName("Cep Comercial:")]
            public string cep_comerc { get; set; }

            [DisplayName("Cep Residencial:")]
            public string cep_resid { get; set; }

            [DisplayName("Cep Residencial:")]
            public string cidade_resid { get; set; }

            [Required(ErrorMessage = "O cpf é necessário para o cadastro.")]
            [DisplayName("Cpf:")]
            public string cpf { get; set; }

            [DisplayName("Ctps:")]
            public string ctps { get; set; }

            [DisplayName("Data Expedição:")]
            public DateTime? data_expedicao { get; set; }

            [DisplayName("Endereço Residencial:")]
            public string endereco_resid { get; set; }


            [DisplayName("Telefone Residencial:")]
            public string fone_resid { get; set; }



            [DisplayName("Nome da Mãe:")]
            public string nome_mae { get; set; }

            [DisplayName("Nome do Pai:")]
            public string nome_pai { get; set; }


            [DisplayName("Rg:")]
            public string rg { get; set; }

            [DisplayName("Seção:")]
            public string secao { get; set; }

            [DisplayName("Sexo:")]
            public string sexo { get; set; }

            [DisplayName("Situação")]
            public string situacao { get; set; }

            [DisplayName("Título Eleitor:")]
            public string titulo_eleitor { get; set; }

            [RegularExpression(@"^[^0]+", ErrorMessage = "Escolha a Uf Residencial")]
            [UIHint("UfDropDown")]
            [DisplayName("Uf Residencial:")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            public String uf_resid { get; set; }

            [DisplayName("Zona:")]
            public string zona { get; set; }

        }
    }



}