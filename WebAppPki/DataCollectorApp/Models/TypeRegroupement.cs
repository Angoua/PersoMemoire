namespace DataCollectorApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TypeRegroupement")]
    public partial class TypeRegroupement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short rgID { get; set; }

        [Required]
        [StringLength(50)]
        public string rgNom { get; set; }

        [Required]
        [StringLength(50)]
        public string rgCreationUser { get; set; }

        public DateTime rgCreationDate { get; set; }

        [StringLength(50)]
        public string rgModificationUser { get; set; }

        public DateTime? rgModificationDate { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] rgRowversion { get; set; }

        public bool rgStatut { get; set; }
    }
}
