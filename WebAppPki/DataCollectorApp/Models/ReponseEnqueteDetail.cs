namespace DataCollectorApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReponseEnqueteDetail")]
    public partial class ReponseEnqueteDetail
    {
        [Key]
        public Guid rdID { get; set; }

        public long rdReponseEnqueteID { get; set; }

        public long rdQuestionID { get; set; }

        [Required]
        [StringLength(100)]
        public string rdValeurReponse { get; set; }

        public int rdReponseTypeID { get; set; }

        public bool rdIsValid { get; set; }

        [Required]
        [StringLength(50)]
        public string rdCreationUser { get; set; }

        public DateTime rdCreationDate { get; set; }

        [StringLength(50)]
        public string rdModificationUser { get; set; }

        public DateTime? rdModificationDate { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] rdRowversion { get; set; }

        public bool rdStatut { get; set; }
    }
}
