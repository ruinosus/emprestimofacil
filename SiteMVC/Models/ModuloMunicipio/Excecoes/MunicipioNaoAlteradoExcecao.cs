using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloMunicipio.Constantes;

namespace SiteMVC.ModuloMunicipio.Excecoes
{
    /// <summary>
    /// Classe MunicipioNaoAlteradoExcecao
    /// </summary>
    public class MunicipioNaoAlteradoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public MunicipioNaoAlteradoExcecao()
            : base(MunicipioConstantes.MUNICIPIO_NAOALTERADO)
        { }
    }
}