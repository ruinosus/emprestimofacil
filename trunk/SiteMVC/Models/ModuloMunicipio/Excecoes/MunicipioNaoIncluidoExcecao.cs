using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloMunicipio.Constantes;

namespace SiteMVC.ModuloMunicipio.Excecoes
{
    /// <summary>
    /// Classe MunicipioNaoIncluidoExcecao
    /// </summary>
    public class MunicipioNaoIncluidoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public MunicipioNaoIncluidoExcecao()
            : base(MunicipioConstantes.MUNICIPIO_NAOINCLUIDO)
        { }
    }
}