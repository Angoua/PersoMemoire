namespace DataCollectorApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CategorieIndicateur")]
    public partial class CategorieIndicateur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short caID { get; set; }

        [Required]
        [StringLength(50)]
        public string caNom { get; set; }

        [Required]
        [StringLength(50)]
        public string caCreationUser { get; set; }

        public DateTime caCreationDate { get; set; }

        [StringLength(50)]
        public string caModificationUser { get; set; }

        public DateTime? caModificationDate { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] caRowversion { get; set; }

        public bool caStatut { get; set; }
    }
}
