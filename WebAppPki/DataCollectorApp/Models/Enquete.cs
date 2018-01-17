namespace DataCollectorApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Enquete")]
    public partial class Enquete
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long enID { get; set; }

        [Display(Name ="Titre")]
        [StringLength(100)]
        public string enTitre { get; set; }

        [Required]
        [Display(Name = "Campagne")]
        [StringLength(9)]
        public string enCampagne { get; set; }

        [Display(Name = "Date Début")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString ="{0:d}")]
        public DateTime enDateDebut { get; set; }


        [Display(Name = "Date fin")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime enDateFin { get; set; }

        public short enCibleEnqueteID { get; set; }

        [Required]
        [StringLength(50)]
        public string enCreationUser { get; set; }

        public DateTime enCreationDate { get; set; }

        public DateTime? enModificationDate { get; set; }

        [StringLength(50)]
        public string enModificationUser { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] enRowversion { get; set; }

        public bool enStatut { get; set; }
    }
}
