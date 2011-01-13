using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;

using SiteMVC.ModuloUsuario.Excecoes;
using SiteMVC.ModuloBasico.Enums;
using SiteMVC.Models.ModuloBasico.VOs;

namespace SiteMVC.ModuloUsuario.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        #region Atributos

        EmprestimoEntities db;

        #endregion

        #region Métodos da Interface

        public List<Usuario> Consultar()
        {
            return db.UsuarioSet.ToList();
        }

        public List<Usuario> Consultar(Usuario usuario, TipoPesquisa tipoPesquisa)
        {
            List<Usuario> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (usuario.ID != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.ID == usuario.ID
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(usuario.login) &&
                           !string.IsNullOrEmpty(usuario.senha))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.login.Equals(usuario.login) &&
                                          c.senha.Equals(usuario.senha)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        
                        break;
                    }
                #endregion
                #region Case Ou
                case TipoPesquisa.Ou:
                    {
                        if (usuario.ID != 0)
                        {
                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.ID == usuario.ID
                                                select c).ToList());
                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(usuario.login) &&
                           !string.IsNullOrEmpty(usuario.senha))
                        {

                            resultado.AddRange((from c in resultado
                                          where
                                          c.login.Equals(usuario.login) &&
                                          c.senha.Equals(usuario.senha)
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

        public void Incluir(Usuario usuario)
        {
            try
            {
                db.AddToUsuarioSet(usuario);
            }
            catch (Exception)
            {

                throw new UsuarioNaoIncluidoExcecao();
            }
        }

        public void Excluir(Usuario usuario)
        {
            try
            {
                Usuario usuarioAux = new Usuario();
                usuarioAux.ID = usuario.ID;


                List<Usuario> resultado = this.Consultar(usuarioAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new UsuarioNaoExcluidoExcecao();

                usuarioAux = resultado[0];

                db.DeleteObject(usuarioAux);

            }
            catch (Exception)
            {

                throw new UsuarioNaoExcluidoExcecao();
            }
        }

        public void Alterar(Usuario usuario)
        {
            try
            {
                Usuario usuarioAux = new Usuario();
                usuarioAux.ID = usuario.ID;


                List<Usuario> resultado = this.Consultar(usuarioAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new UsuarioNaoAlteradoExcecao();

                usuarioAux = resultado[0];
                usuarioAux.area_id = usuario.area_id;
                usuarioAux.bairro_resid = usuario.bairro_resid;
                usuarioAux.celular = usuario.celular;
                usuarioAux.cep_resid = usuario.cep_resid;
                usuarioAux.cidade_resid = usuario.cidade_resid;
                usuarioAux.cpf = usuario.cpf;
                usuarioAux.ctps = usuario.ctps;
                usuarioAux.data_expedicao = usuario.data_expedicao;
                usuarioAux.endereco_resid = usuario.endereco_resid;
                usuarioAux.escolaridade_id = usuario.escolaridade_id;
                usuarioAux.estadoscivistipo_id = usuario.estadoscivistipo_id;
                usuarioAux.ID = usuario.ID;
                usuarioAux.login = usuario.login;
                usuarioAux.nome = usuario.nome;
                usuarioAux.nome_mae = usuario.nome_mae;
                usuarioAux.nome_pai = usuario.nome_pai;
                usuarioAux.orgaosexpedidoresnome_id = usuario.orgaosexpedidoresnome_id;
                usuarioAux.rg = usuario.rg;
                usuarioAux.secao = usuario.secao;
                usuarioAux.senha = usuario.senha;
                usuarioAux.sexo = usuario.sexo;
                usuarioAux.situacao = usuario.situacao;
                usuarioAux.timeCreated = usuario.timeCreated;
                usuarioAux.titulo_eleitor = usuario.titulo_eleitor;
                usuarioAux.uf_resid = usuario.uf_resid;
                usuarioAux.usuariotipo_id = usuario.usuariotipo_id;
                usuarioAux.zona = usuario.zona;
      

                Confirmar();
            }
            catch (Exception)
            {

                throw new UsuarioNaoAlteradoExcecao();
            }
        }

        public void Confirmar()
        {
            db.SaveChanges();
        }

        #endregion

        #region Construtor
        public UsuarioRepositorio()
        {
            db = new EmprestimoEntities();
        }
        #endregion


    }
}