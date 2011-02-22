using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.ComponentModel;
using System.Reflection;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;
using SiteMVCTelerik.ModuloBasico;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.Models.ModuloBasico.VOs;
using SiteMVCTelerik.Helpers;
using SiteMVCTelerik.ModuloPrestacaoConta.Processos;
using SiteMVCTelerik.ModuloBasico.Enums;

namespace SiteMVCTelerik.Models.ModuloBasico.VOs
{
    /// <summary>
    /// Summary description for ClasseAuxiliar
    /// </summary>
    public partial class ClasseAuxiliar
    {

        private static Usuario usuarioLogado;

        private static Area areaSelecionada;

        private static long lancamentoTipoIDSelecionado;

        private static Cliente clienteSelecionado;

        private static Emprestimo emprestimoSelecionado;

        private static DateTime dataSelecionada;

        private static bool isPrestacaoConta;

        /// <summary>
        /// Propriedade que representa um Usuario no sistema.
        /// </summary>
        public static Usuario UsuarioLogado
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["UsuarioLogado"] != null)
                    usuarioLogado = (Usuario)System.Web.HttpContext.Current.Session["UsuarioLogado"];
                else
                    usuarioLogado = null;

                return usuarioLogado;
            }
            private set { usuarioLogado = value; }
        }

        public static bool IsPrestacaoConta
        {
            get
            {

                IPrestacaoContaProcesso processo = PrestacaoContaProcesso.Instance;

                PrestacaoConta prestacao = new PrestacaoConta();

                prestacao.dataprestacao = DataSelecionada.Date;
                if (areaSelecionada == null)
                    return false;
                prestacao.area_id = areaSelecionada.ID;

                List<PrestacaoConta> lista = processo.Consultar(prestacao, TipoPesquisa.E);

                return lista.Count > 0;
            }
            private set { isPrestacaoConta = value; }
        }

        /// <summary>
        /// Propriedade que representa o tipo do lancamento id selecionado.
        /// </summary>
        public static long LancamentoTipoIDSelecionado
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["LancamentoTipoIDSelecionado"] != null)
                    lancamentoTipoIDSelecionado = (long)System.Web.HttpContext.Current.Session["LancamentoTipoIDSelecionado"];
                else
                    lancamentoTipoIDSelecionado = 0;

                return lancamentoTipoIDSelecionado;
            }
            private set { lancamentoTipoIDSelecionado = value; }
        }

        /// <summary>
        /// Propriedade que representa a area selecionada.
        /// </summary>
        public static Area AreaSelecionada
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["AreaSelecionada"] != null)
                    areaSelecionada = (Area)System.Web.HttpContext.Current.Session["AreaSelecionada"];
                else
                    areaSelecionada = null;

                return areaSelecionada;
            }
            private set { areaSelecionada = value; }
        }

        /// <summary>
        /// Propriedade que representa a data selecionada.
        /// </summary>
        public static DateTime DataSelecionada
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["DataSelecionada"] != null)
                    dataSelecionada = (DateTime)System.Web.HttpContext.Current.Session["DataSelecionada"];
                else
                    areaSelecionada = null;

                return dataSelecionada;
            }
            private set { dataSelecionada = value; }
        }

        /// <summary>
        /// Propriedade que representa um Cliente no sistema.
        /// </summary>
        public static Cliente ClienteSelecionado
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["ClienteSelecionado"] != null)
                    clienteSelecionado = (Cliente)System.Web.HttpContext.Current.Session["ClienteSelecionado"];
                else
                    clienteSelecionado = null;

                return clienteSelecionado;
            }
            private set { clienteSelecionado = value; }
        }

        public static Emprestimo EmprestimoSelecionado
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["EmprestimoSelecionado"] != null)
                    emprestimoSelecionado = (Emprestimo)System.Web.HttpContext.Current.Session["EmprestimoSelecionado"];
                else
                    emprestimoSelecionado = null;

                return emprestimoSelecionado;
            }
            private set { emprestimoSelecionado = value; }
        }


        /// <summary>
        /// Verifica se o Usuario está logado na aplicação.
        /// </summary>
        public static void ValidarUsuarioLogado()
        {
            if (UsuarioLogado == null)
                System.Web.HttpContext.Current.Response.Redirect(SiteConstantes.PAGINA_PRINCIPAL, false);

        }

        /// <summary>
        /// Método responsável por montar um combo com um Enum.
        /// </summary>
        /// <typeparam name="T">Enum a ser exibido no combo.</typeparam>
        /// <param name="cbo">combo para montatem</param>
        public static void CarregarComboEnum<T>(DropDownList cbo)
        {
            cbo.Items.Clear();

            Type objType = typeof(T);
            FieldInfo[] propriedades = objType.GetFields();

            foreach (FieldInfo objField in propriedades)
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])objField.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes.Length > 0)
                    cbo.Items.Add(new ListItem(attributes[0].Description, objField.GetRawConstantValue().ToString()));
            }
        }

        /// <summary>
        /// Método responsável por montar um combo com um Enum.
        /// </summary>
        /// <typeparam name="T">Enum a ser exibido no combo.</typeparam>
        /// <param name="cbo">combo para montatem</param>
        public static List<CheckBoxListInfo> CarregarCheckBoxEnum<T>(List<int> enumeradores)
        {
            var rolesList = new List<CheckBoxListInfo>();
            Type objType = typeof(T);
            FieldInfo[] propriedades = objType.GetFields();
            bool marcado = false;
            foreach (FieldInfo objField in propriedades)
            {

                DescriptionAttribute[] attributes = (DescriptionAttribute[])objField.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes.Length > 0)
                {

                    if (enumeradores != null)
                        for (int i = 0; i < enumeradores.Count; i++)
                        {
                            if (Convert.ToInt16(objField.GetRawConstantValue().ToString()) == (enumeradores[i]) && !marcado)
                                marcado = true;
                        }
                    rolesList.Add(new CheckBoxListInfo(objField.GetRawConstantValue().ToString(), attributes[0].Description, marcado));
                    marcado = false;
                }

            }

            return rolesList;
        }


        /// <summary>
        /// Método responsável por converter uma imagem em um array de bytes.
        /// </summary>
        /// <param name="imageIn">Imagem a ser convertida.</param>
        /// <returns>Array de Bytes que formam a imagem.</returns>
        public static byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();

            System.Drawing.Imaging.ImageCodecInfo[] info = ImageCodecInfo.GetImageEncoders();
            EncoderParameters encoderParameters;
            encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, 70L);
            imageIn.Save(ms, info[1], encoderParameters);

            return ms.ToArray();
        }

        /// <summary>
        /// Método responsável por converter uma imagem em um array de bytes.
        /// </summary>
        /// <param name="imageIn">Imagem a ser convertida.</param>
        /// <param name="file">Arquivo passado.</param>
        /// <returns>Array de Bytes que formam a imagem.</returns>
        public static byte[] ImageToByteArray(HttpPostedFile file, System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();

            if (file.ContentType == "image/jpg" || file.ContentType == "image/jpeg" || file.ContentType == "image/pjpeg")
            {

                System.Drawing.Imaging.ImageCodecInfo[] info = ImageCodecInfo.GetImageEncoders();
                EncoderParameters encoderParameters;
                encoderParameters = new EncoderParameters(1);
                encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, 70L);
                imageIn.Save(ms, info[1], encoderParameters);
            }

            return ms.ToArray();
        }

        /// <summary>
        /// Método responsável por converter um array de bytes em uma imagem.
        /// </summary>
        /// <param name="byteArrayIn">Array de bytes a ser convertido.</param>
        /// <returns>Imagem formada pelo array de bytes.</returns>
        public static System.Drawing.Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;

        }

    }
}