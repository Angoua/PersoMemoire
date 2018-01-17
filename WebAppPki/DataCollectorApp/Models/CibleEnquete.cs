namespace DataCollectorApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CibleEnquete")]
    public partial class CibleEnquete
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short ceID { get; set; }

        [StringLength(50)]
        public string ceLibelle { get; set; }

        [Required]
        [StringLength(50)]
        public string ceCreationUser { get; set; }

        public DateTime? ceCreationDate { get; set; }

        [StringLength(50)]
        public string ceModificationUser { get; set; }

        public DateTime? ceModificationDate { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] ceRowversion { get; set; }

        public bool ceStatut { get; set; }
    }
}
