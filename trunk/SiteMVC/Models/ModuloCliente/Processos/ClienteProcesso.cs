using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloBasico.Singleton;
using SiteMVC.ModuloCliente.Repositorios;
using SiteMVC.ModuloCliente.Processos;
using SiteMVC.ModuloCliente.Fabricas;
using SiteMVC.ModuloBasico.Enums;
using SiteMVC.ModuloCliente.Excecoes;
using SiteMVC.Models.ModuloBasico.VOs;
using SiteMVC.ModuloParcela.Processos;

namespace SiteMVC.ModuloCliente.Processos
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

                this.clienteRepositorio.Excluir(cliente);
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
            List<Cliente> clienteList = this.clienteRepositorio.Consultar(cliente, tipoPesquisa);

            return clienteList;
        }


        public List<Cliente> ConsultarClientesDevedores()
        {
            List<Cliente> clientesPadrao = this.Consultar();
            IParcelaProcesso parcelaProcesso = ParcelaProcesso.Instance;

            List<Parcela> parcelas = parcelaProcesso.Consultar();

            var resultado = from p in parcelas
                      where p.statusparcela_id == 2
                      join c in clientesPadrao on p.emprestimo.cliente_id equals c.ID
                      group p by p.emprestimo.cliente into cc
                      select new
                      {
                          Cliente = cc.Key,
                          ValorTotal = cc.Sum(p=>p.valor)
                      };
            List<Cliente> clientes = new List<Cliente>();
            Cliente clienteTeste;
            foreach (var item in resultado)
            {
                clienteTeste = new Cliente();
                clienteTeste = item.Cliente;
                clienteTeste.ValorDevedor = item.ValorTotal;
                clientes.Add(clienteTeste);
            }
            
            return clientes;
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