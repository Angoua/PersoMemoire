namespace DataCollectorApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FonctionCalcul")]
    public partial class FonctionCalcul
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short fcID { get; set; }

        [Required]
        [StringLength(50)]
        public string fcNom { get; set; }

        [Required]
        [StringLength(50)]
        public string fcCreationUser { get; set; }

        public DateTime fcCreationDate { get; set; }

        [StringLength(50)]
        public string fcModificationUser { get; set; }

        public DateTime? fcModificationDate { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] fcRowversion { get; set; }

        public bool fcStatut { get; set; }
    }
}
