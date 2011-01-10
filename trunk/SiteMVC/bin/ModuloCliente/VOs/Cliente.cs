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
            [DisplayName("Nome:")]
            public string nome { get; set; }

            [RegularExpression(@"^[^0]+", ErrorMessage = "Escolha a Area.")]
            [UIHint("AreaDropDown")]
            [DisplayName("Area:")]
            public long area_id { get; set; }

            [RegularExpression(@"^[^0]+", ErrorMessage = "Escolha o orgão expedidor.")]
            [UIHint("OrgaoExpedidorNomeDropDown")]
            [DisplayName("Orgão Expedidor:")]
            public long? orgaosexpedidoresnome_id { get; set; }

            [RegularExpression(@"^[^0]+", ErrorMessage = "Escolha o estado civil.")]
            [UIHint("EstadoCivilTipoDropDown")]
            [DisplayName("Estado Civil:")]
            public long? estadoscivistipo_id { get; set; }

            [RegularExpression(@"^[^0]+", ErrorMessage = "Escolha a escolaridade.")]
            [UIHint("EscolaridadeDropDown")]
            [DisplayName("Escolaridade:")]
            public long? escolaridade_id { get; set; }

            [DisplayName("Bairro Comercial:")]
            public string bairro_comerc { get; set; }

            [DisplayName("Bairro Residencial:")]
            public string bairro_resid { get; set; }

            [DisplayName("Celularl:")]
            public string celular { get; set; }

            [DisplayName("Cep Comercial:")]
            public string cep_comerc { get; set; }

            [DisplayName("Cep Residencial:")]
            public string cep_resid { get; set; }

            [RegularExpression(@"^[^0]+", ErrorMessage = "Escolha a Cidade Comercial")]
            [UIHint("MunicipioDropDown")]
            [DisplayName("Cidade Comercial:")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            public long cidade_comerc { get; set; }


            [RegularExpression(@"^[^0]+", ErrorMessage = "Escolha a Cidade Residencial")]
            [UIHint("MunicipioDropDown")]
            [DisplayName("Cidade Residencial:")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            public long cidade_resid { get; set; }

            [Required(ErrorMessage = "O cpf é necessário para o cadastro.")]
            [DisplayName("Cpf:")]
            public string cpf { get; set; }

            [DisplayName("Ctps:")]
            public string ctps { get; set; }

            [DisplayName("Data Expedição:")]
            public DateTime? data_expedicao { get; set; }

            [DisplayName("Endereço Comercial:")]
            public string endereco_comerc { get; set; }

            [DisplayName("Endereço Residencial:")]
            public string endereco_resid { get; set; }

            [DisplayName("Telefone Comercial:")]
            public string fone_comerc { get; set; }

            [DisplayName("Telefone Residencial:")]
            public string fone_resid { get; set; }

            [DisplayName("Telefone Referencia 1:")]
            public string fone_ref1{ get; set; }

            [DisplayName("Telefone Referencia 2:")]
            public string fone_ref2 { get; set; }

            [DisplayName("Limite:")]
            public float? limite { get; set; }

            [DisplayName("Nome da Mãe:")]
            public string nome_mae { get; set; }

            [DisplayName("Nome do Pai:")]
            public string nome_pai { get; set; }

            [DisplayName("Nome referencia 1:")]
            public string nome_ref1 { get; set; }

            [DisplayName("Nome referencia 2:")]
            public string nome_ref2 { get; set; }

            [DisplayName("Número do cartão:")]
            public string numcartao { get; set; }

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

            [RegularExpression(@"^[^0]+", ErrorMessage = "Escolha a Uf comercial")]
            [UIHint("UfDropDown")]
            [DisplayName("Uf Comercial:")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            public String uf_comerc { get; set; }

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