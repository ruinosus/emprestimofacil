using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloMunicipio.Constantes;

namespace SiteMVC.ModuloMunicipio.Excecoes
{
    /// <summary>
    /// Classe MunicipioNaoExcluidoExcecao
    /// </summary>
    public class MunicipioNaoExcluidoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public MunicipioNaoExcluidoExcecao()
            : base(MunicipioConstantes.MUNICIPIO_NAOEXCLUIDO)
        { }
    }
}