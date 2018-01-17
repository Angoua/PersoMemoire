namespace DataCollectorApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RepresentationDonnees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short reID { get; set; }

        [Required]
        [StringLength(50)]
        public string reNom { get; set; }

        [Required]
        [StringLength(50)]
        public string reCreationUser { get; set; }

        public DateTime? reCreationDate { get; set; }

        [StringLength(50)]
        public string reModificationUser { get; set; }

        public DateTime? reModificationDate { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] reRowversion { get; set; }

        public bool reStatut { get; set; }
    }
}
