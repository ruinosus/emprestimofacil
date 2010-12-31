using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloBasico.Singleton;
using RegraNegocio.ModuloCliente.Repositorios;
using RegraNegocio.ModuloCliente.Processos;
using RegraNegocio.ModuloCliente.Fabricas;
using RegraNegocio.ModuloBasico.Enums;
using RegraNegocio.ModuloCliente.Excecoes;
using RegraNegocio.ModuloBasico.VOs;

namespace RegraNegocio.ModuloCliente.Processos
{
    /// <summary>
    /// Classe ClienteProcesso
    /// </summary>
    public class ClienteProcesso : Singleton<ClienteProcesso>, IClienteProcesso
    {
        #region Atributos
        private IClienteRepositorio clienteRepositorio = null;
        #endregion

        #region Construtor
        public ClienteProcesso()
        {
            clienteRepositorio = ClienteFabrica.IClienteInstance;
        }

        #endregion


        #region Métodos da Interface

        public void Incluir(Cliente cliente)
        {
            this.clienteRepositorio.Incluir(cliente);

        }

        public void Excluir(Cliente cliente)
        {

            try
            {
                if (cliente.ID == 0)
                    throw new ClienteNaoExcluidoExcecao();

                List<Cliente> resultado = clienteRepositorio.Consultar(cliente, TipoPesquisa.E);

                if (resultado == null || resultado.Count <= 0 || resultado.Count > 1)
                    throw new ClienteNaoExcluidoExcecao();

                this.Excluir(cliente);
            }
            catch (Exception e)
            {

                throw e;
            }
            //this.clienteRepositorio.Excluir(cliente);
        }

        public void Alterar(Cliente cliente)
        {
            this.clienteRepositorio.Alterar(cliente);
        }

        public List<Cliente> Consultar(Cliente cliente, TipoPesquisa tipoPesquisa)
        {
            List<Cliente> clienteList = this.clienteRepositorio.Consultar(cliente,tipoPesquisa);           

            return clienteList;
        }

        public List<Cliente> Consultar()
        {
            List<Cliente> clienteList = this.clienteRepositorio.Consultar();

            return clienteList;
        }

     
        public void Confirmar()
        {
            this.clienteRepositorio.Confirmar();
        }

        #endregion
    }
}