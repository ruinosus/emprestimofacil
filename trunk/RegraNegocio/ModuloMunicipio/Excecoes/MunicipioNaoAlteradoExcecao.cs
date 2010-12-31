using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloMunicipio.Constantes;

namespace RegraNegocio.ModuloMunicipio.Excecoes
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