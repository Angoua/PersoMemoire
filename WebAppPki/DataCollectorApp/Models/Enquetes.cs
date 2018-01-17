namespace DataCollectorApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Enquetes
    {
        [Key]
        public long EnqueteID { get; set; }

        public string Titre { get; set; }

        public string Campagne { get; set; }

        public DateTime DateDebut { get; set; }

        public DateTime DateFin { get; set; }

        public bool IsNew { get; set; }

        public bool EstDesactive { get; set; }

        public string CreationUtilisateur { get; set; }

        public DateTime CreationDate { get; set; }

        public string ModificationUtilisateur { get; set; }

        public DateTime ModificationDate { get; set; }

        public byte[] RowVersion { get; set; }

        public short? Cible_ID { get; set; }

        public virtual CibleEnquetes CibleEnquetes { get; set; }
    }
}
