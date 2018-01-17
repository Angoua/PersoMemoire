namespace DataCollectorApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReponseEnquete")]
    public partial class ReponseEnquete
    {
        [Key]
        public Guid reID { get; set; }

        public Guid reEntiteID { get; set; }

        public long reEnqueteID { get; set; }

        [Required]
        [StringLength(50)]
        public string reCreationUser { get; set; }

        public DateTime reCreationDate { get; set; }

        [StringLength(50)]
        public string reModificationUser { get; set; }

        public DateTime? reModificationDate { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] reRowversion { get; set; }

        public bool reStatut { get; set; }
    }
}
