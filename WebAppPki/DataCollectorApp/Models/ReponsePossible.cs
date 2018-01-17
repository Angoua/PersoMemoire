namespace DataCollectorApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReponsePossible")]
    public partial class ReponsePossible
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int rpID { get; set; }

        [StringLength(50)]
        public string rpLibelle { get; set; }

        [Required]
        [StringLength(50)]
        public string rpCreationUser { get; set; }

        public DateTime rpCreationDate { get; set; }

        [StringLength(50)]
        public string rpModificationUser { get; set; }

        public DateTime? rpModificationDate { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] rpRowversion { get; set; }

        public bool? rpStatut { get; set; }
    }
}
