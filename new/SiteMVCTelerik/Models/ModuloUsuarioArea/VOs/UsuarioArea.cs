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

    [MetadataType(typeof(UsuarioAreaMetadata))]
    public partial class UsuarioArea
    {

        internal class UsuarioAreaMetadata
        {

            [RegularExpression(@"^[^0]+", ErrorMessage = "Escolha a Area.")]
            [UIHint("AreaDropDown")]
            [DisplayName("Area:")]
            public long area_id { get; set; }

            [RegularExpression(@"^[^0]+", ErrorMessage = "Escolha o usuário.")]
            [UIHint("UsuarioDropDown")]
            [DisplayName("Usuário:")]
            public long usuario_id { get; set; }

        }
    }



}