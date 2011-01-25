
using System;
namespace SiteMVC.ModuloBasico.Enums
{
    public enum TipoPesquisa
    {
        E = 0,
        Ou = 1
    }

    [Flags]//<-- Note the Flags attribute
    public enum DayOfWeek
    {
        Monday = 1,
        Tuesday = 2,
        Wednesday = 4,
        Thursday = 8,
        Friday = 16,
        Saturday = 32,
        Sunday = 64,
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
