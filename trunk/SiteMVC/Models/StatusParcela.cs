using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SiteMVC.Models
{
    [MetadataType(typeof(StatusParcelaMetadata))]
    public partial class StatusParcela
    {

        internal class StatusParcelaMetadata
        {

            [Required]
            // insert other metadata here
            public string FirstName { get; set; }

            // and if you don't want metadata for lastname, you can leave it out
        }
    }

}