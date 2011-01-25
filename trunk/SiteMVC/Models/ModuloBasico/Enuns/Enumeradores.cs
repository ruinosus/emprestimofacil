
using System;
using System.ComponentModel;
namespace SiteMVC.ModuloBasico.Enums
{
    public enum TipoPesquisa
    {
        E = 0,
        Ou = 1
    }


    public enum DiasUteis
    {
        [Description("Segunda-feira")]
        Segunda = 1,
        [Description("Terça-feira")]
        Terca = 2,
        [Description("Quarta-feira")]
        Quarta = 3,
        [Description("Quinta-feira")]
        Quinta = 4,
        [Description("Sexta-feira")]
        Sexta = 5,
        [Description("Sabado")]
        Sabado = 6,
        [Description("Domingo")]
        Domingo = 7,
    }

    //public static class Enum<T>
    //{
    //    public static T ParseToEnumFlag(NameValueCollection source, string formKey)
    //    {
    //        //MVC 'helpfully' parses the checkbox into a comma-delimited list. We pull that out and sum the values after parsing it back into the enum.
    //        return (T)Enum.ToObject(typeof(T), source.Get(formKey).ToIEnumerable<int>(',').Sum());
    //    }
    //}



}
