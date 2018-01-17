namespace DataCollectorApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Question")]
    public partial class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long quID { get; set; }

        [Required]
        [StringLength(500)]
        public string quIntitule { get; set; }

        [Required]
        [StringLength(200)]
        public string quCourteDescription { get; set; }

        public short quTypeReponseID { get; set; }

        public long quEnqueteID { get; set; }

        [Required]
        [StringLength(50)]
        public string quCreationUser { get; set; }

        public DateTime? quCreationDate { get; set; }

        [StringLength(50)]
        public string quModificationUser { get; set; }

        public DateTime? quModificationDate { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] quRowversion { get; set; }

        public bool quStatut { get; set; }
    }
}
