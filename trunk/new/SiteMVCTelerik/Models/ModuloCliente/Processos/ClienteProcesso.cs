using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloBasico.Singleton;
using SiteMVCTelerik.ModuloCliente.Repositorios;
using SiteMVCTelerik.ModuloCliente.Processos;
using SiteMVCTelerik.ModuloCliente.Fabricas;
using SiteMVCTelerik.ModuloBasico.Enums;
using SiteMVCTelerik.ModuloCliente.Excecoes;
using SiteMVCTelerik.Models.ModuloBasico.VOs;
using SiteMVCTelerik.ModuloParcela.Processos;

namespace SiteMVCTelerik.ModuloCliente.Processos
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
                if (cliente.id == 0)
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
            Cliente ccc = new Cliente();
            ccc.area_id = ClasseAuxiliar.AreaSelecionada.id;
            List<Cliente> clientesPadrao = this.Consultar(ccc,TipoPesquisa.E);
            IParcelaProcesso parcelaProcesso = ParcelaProcesso.Instance;

            List<Parcela> parcelas = parcelaProcesso.Consultar();

            var resultado = from p in parcelas
                      where p.statusparcela_id == 2
                      join c in clientesPadrao on p.emprestimo.cliente_id equals c.id
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