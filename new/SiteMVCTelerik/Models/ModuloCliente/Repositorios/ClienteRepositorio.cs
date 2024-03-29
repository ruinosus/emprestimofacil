using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;

using SiteMVCTelerik.ModuloCliente.Excecoes;
using SiteMVCTelerik.ModuloBasico.Enums;
using SiteMVCTelerik.Models.ModuloBasico.VOs;

namespace SiteMVCTelerik.ModuloCliente.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        #region Atributos

        emprestimoEntities db;

        #endregion

        #region M�todos da Interface

        public List<Cliente> Consultar()
        {
            return db.cliente.ToList();
        }

        public List<Cliente> Consultar(Cliente cliente, TipoPesquisa tipoPesquisa)
        {
            List<Cliente> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (cliente.id != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.id == cliente.id
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }
                        else
                        {

                            if (cliente.area_id != 0)
                            {

                                resultado = ((from c in resultado
                                              where
                                              c.area_id == cliente.area_id
                                              select c).ToList());

                                resultado = resultado.Distinct().ToList();
                            }


                        }

                        break;
                    }
                #endregion
                #region Case Ou
                case TipoPesquisa.Ou:
                    {
                        if (cliente.id != 0)
                        {
                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.id == cliente.id
                                                select c).ToList());
                            resultado = resultado.Distinct().ToList();
                        }

                        if (cliente.area_id != 0)
                        {
                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.area_id == cliente.area_id
                                                select c).ToList());
                            resultado = resultado.Distinct().ToList();
                        }


                        break;
                    }
                #endregion
                default:
                    break;
            }

            return resultado;
        }

        //public List<Cliente> ConsultarClientesDevedores()
        //{
        //    List<Cliente> resultado = Consultar();

        //   var clienteList = from c in resultado
                             

        //    return resultado;
        //}

        public void Incluir(Cliente cliente)
        {
            try
            {
                db.AddTocliente(cliente);
            }
            catch (Exception)
            {

                throw new ClienteNaoIncluidoExcecao();
            }
        }

        public void Excluir(Cliente cliente)
        {
            try
            {
                Cliente clienteAux = new Cliente();
                clienteAux.id = cliente.id;


                List<Cliente> resultado = this.Consultar(clienteAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new ClienteNaoExcluidoExcecao();

                clienteAux = resultado[0];

                db.DeleteObject(clienteAux);

            }
            catch (Exception)
            {

                throw new ClienteNaoExcluidoExcecao();
            }
        }

        public void Alterar(Cliente cliente)
        {
            try
            {
                Cliente clienteAux = new Cliente();
                clienteAux.id = cliente.id;


                List<Cliente> resultado = this.Consultar(clienteAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new ClienteNaoAlteradoExcecao();

                clienteAux = resultado[0];
                clienteAux.area_id = cliente.area_id;
                clienteAux.bairro_comerc = cliente.bairro_comerc;
                clienteAux.bairro_resid = cliente.bairro_resid;
                clienteAux.celular = cliente.celular;
                clienteAux.cep_comerc = cliente.cep_comerc;
                clienteAux.cep_resid = cliente.cep_resid;
                clienteAux.cidade_comerc = cliente.cidade_comerc;
                clienteAux.cidade_resid = cliente.cidade_resid;
                clienteAux.cpf = cliente.cpf;
                clienteAux.ctps = cliente.ctps;
                clienteAux.data_expedicao = cliente.data_expedicao;
                clienteAux.endereco_comerc = cliente.endereco_comerc;
                clienteAux.endereco_resid = cliente.endereco_resid;
                clienteAux.escolaridade_id = cliente.escolaridade_id;
                clienteAux.estadoscivistipo_id = cliente.estadoscivistipo_id;
                clienteAux.fone_comerc = cliente.fone_comerc;
                clienteAux.fone_ref1 = cliente.fone_ref1;
                clienteAux.fone_ref2 = cliente.fone_ref2;
                clienteAux.fone_resid = cliente.fone_resid;
                clienteAux.id = cliente.id;
                clienteAux.limite = cliente.limite;
                clienteAux.nome = cliente.nome;
                clienteAux.nome_mae = cliente.nome_mae;
                clienteAux.nome_pai = cliente.nome_pai;
                clienteAux.nome_ref1 = cliente.nome_ref1;
                clienteAux.nome_ref2 = cliente.nome_ref2;
                clienteAux.numcartao = cliente.numcartao;
                clienteAux.orgaosexpedidoresnome_id = cliente.orgaosexpedidoresnome_id;
                clienteAux.rg = cliente.rg;
                clienteAux.secao = cliente.secao;
                clienteAux.sexo = cliente.sexo;
                clienteAux.titulo_eleitor = cliente.titulo_eleitor;
                clienteAux.uf_comerc = cliente.uf_comerc;
                clienteAux.uf_resid = cliente.uf_resid;
                clienteAux.zona = cliente.zona;
                clienteAux.observacao = cliente.observacao;

                Confirmar();
            }
            catch (Exception)
            {

                throw new ClienteNaoAlteradoExcecao();
            }
        }

        public void Confirmar()
        {
            db.SaveChanges();
        }

        #endregion

        #region Construtor
        public ClienteRepositorio()
        {
            
            db = new emprestimoEntities();

        }
        #endregion


    }
}