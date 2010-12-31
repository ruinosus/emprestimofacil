using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using Negocios.ModuloMunicipio.Constantes;

namespace Negocios.ModuloMunicipio.Excecoes
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