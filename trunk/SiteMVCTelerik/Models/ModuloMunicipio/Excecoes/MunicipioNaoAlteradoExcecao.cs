using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloMunicipio.Constantes;

namespace SiteMVCTelerik.ModuloMunicipio.Excecoes
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