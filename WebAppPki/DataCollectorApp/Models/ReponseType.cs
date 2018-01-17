namespace DataCollectorApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReponseType")]
    public partial class ReponseType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int trID { get; set; }

        [StringLength(100)]
        public string trLibelle { get; set; }

        [Required]
        [StringLength(50)]
        public string trCreationUser { get; set; }

        public DateTime trCreationDate { get; set; }

        [StringLength(50)]
        public string trModificationUser { get; set; }

        public DateTime? trModificationDate { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] trRowversion { get; set; }

        public bool trStatut { get; set; }
    }
}
