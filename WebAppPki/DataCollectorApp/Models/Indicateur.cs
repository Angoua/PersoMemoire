namespace DataCollectorApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Indicateur")]
    public partial class Indicateur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int inID { get; set; }

        [Required]
        [StringLength(50)]
        public string inNom { get; set; }

        public long inEnqueteID { get; set; }

        public long inQuestionID { get; set; }

        public short inFonctionCalculD { get; set; }

        public short inTypeRegroupementID { get; set; }

        public short inRepresentationDonneeID { get; set; }

        public short inCategorieIndicateurID { get; set; }

        [Required]
        [StringLength(50)]
        public string inCreationUser { get; set; }

        public DateTime inCreationDate { get; set; }

        [StringLength(50)]
        public string inModificationUser { get; set; }

        public DateTime? inModificationDate { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] inRowversion { get; set; }

        public bool? inStatut { get; set; }
    }
}
