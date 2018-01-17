namespace DataCollectorApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataCollectorContext : DbContext
    {
        public DataCollectorContext()
            : base("name=DataCollectorContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<CategorieIndicateur> CategorieIndicateur { get; set; }
        public virtual DbSet<CibleEnquete> CibleEnquete { get; set; }
        public virtual DbSet<CibleEnquetes> CibleEnquetes { get; set; }
        public virtual DbSet<Enquete> Enquete { get; set; }
        public virtual DbSet<Enquetes> Enquetes { get; set; }
        public virtual DbSet<FonctionCalcul> FonctionCalcul { get; set; }
        public virtual DbSet<Indicateur> Indicateur { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<ReponseEnquete> ReponseEnquete { get; set; }
        public virtual DbSet<ReponseEnqueteDetail> ReponseEnqueteDetail { get; set; }
        public virtual DbSet<ReponsePossible> ReponsePossible { get; set; }
        public virtual DbSet<ReponseType> ReponseType { get; set; }
        public virtual DbSet<RepresentationDonnees> RepresentationDonnees { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TypeRegroupement> TypeRegroupement { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategorieIndicateur>()
                .Property(e => e.caNom)
                .IsUnicode(false);

            modelBuilder.Entity<CategorieIndicateur>()
                .Property(e => e.caCreationUser)
                .IsUnicode(false);

            modelBuilder.Entity<CategorieIndicateur>()
                .Property(e => e.caModificationUser)
                .IsUnicode(false);

            modelBuilder.Entity<CategorieIndicateur>()
                .Property(e => e.caRowversion)
                .IsFixedLength();

            modelBuilder.Entity<CibleEnquete>()
                .Property(e => e.ceLibelle)
                .IsUnicode(false);

            modelBuilder.Entity<CibleEnquete>()
                .Property(e => e.ceCreationUser)
                .IsUnicode(false);

            modelBuilder.Entity<CibleEnquete>()
                .Property(e => e.ceModificationUser)
                .IsUnicode(false);

            modelBuilder.Entity<CibleEnquete>()
                .Property(e => e.ceRowversion)
                .IsFixedLength();

            modelBuilder.Entity<CibleEnquetes>()
                .HasMany(e => e.Enquetes)
                .WithOptional(e => e.CibleEnquetes)
                .HasForeignKey(e => e.Cible_ID);

            modelBuilder.Entity<Enquete>()
                .Property(e => e.enTitre)
                .IsUnicode(false);

            modelBuilder.Entity<Enquete>()
                .Property(e => e.enCampagne)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Enquete>()
                .Property(e => e.enCreationUser)
                .IsUnicode(false);

            modelBuilder.Entity<Enquete>()
                .Property(e => e.enModificationUser)
                .IsUnicode(false);

            modelBuilder.Entity<Enquete>()
                .Property(e => e.enRowversion)
                .IsFixedLength();

            modelBuilder.Entity<FonctionCalcul>()
                .Property(e => e.fcNom)
                .IsUnicode(false);

            modelBuilder.Entity<FonctionCalcul>()
                .Property(e => e.fcCreationUser)
                .IsUnicode(false);

            modelBuilder.Entity<FonctionCalcul>()
                .Property(e => e.fcModificationUser)
                .IsUnicode(false);

            modelBuilder.Entity<FonctionCalcul>()
                .Property(e => e.fcRowversion)
                .IsFixedLength();

            modelBuilder.Entity<Indicateur>()
                .Property(e => e.inNom)
                .IsUnicode(false);

            modelBuilder.Entity<Indicateur>()
                .Property(e => e.inCreationUser)
                .IsUnicode(false);

            modelBuilder.Entity<Indicateur>()
                .Property(e => e.inModificationUser)
                .IsUnicode(false);

            modelBuilder.Entity<Indicateur>()
                .Property(e => e.inRowversion)
                .IsFixedLength();

            modelBuilder.Entity<Question>()
                .Property(e => e.quIntitule)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.quCourteDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.quCreationUser)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.quModificationUser)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.quRowversion)
                .IsFixedLength();

            modelBuilder.Entity<ReponseEnquete>()
                .Property(e => e.reCreationUser)
                .IsUnicode(false);

            modelBuilder.Entity<ReponseEnquete>()
                .Property(e => e.reModificationUser)
                .IsUnicode(false);

            modelBuilder.Entity<ReponseEnquete>()
                .Property(e => e.reRowversion)
                .IsFixedLength();

            modelBuilder.Entity<ReponseEnqueteDetail>()
                .Property(e => e.rdValeurReponse)
                .IsUnicode(false);

            modelBuilder.Entity<ReponseEnqueteDetail>()
                .Property(e => e.rdCreationUser)
                .IsUnicode(false);

            modelBuilder.Entity<ReponseEnqueteDetail>()
                .Property(e => e.rdModificationUser)
                .IsUnicode(false);

            modelBuilder.Entity<ReponseEnqueteDetail>()
                .Property(e => e.rdRowversion)
                .IsFixedLength();

            modelBuilder.Entity<ReponsePossible>()
                .Property(e => e.rpLibelle)
                .IsUnicode(false);

            modelBuilder.Entity<ReponsePossible>()
                .Property(e => e.rpCreationUser)
                .IsUnicode(false);

            modelBuilder.Entity<ReponsePossible>()
                .Property(e => e.rpModificationUser)
                .IsUnicode(false);

            modelBuilder.Entity<ReponsePossible>()
                .Property(e => e.rpRowversion)
                .IsFixedLength();

            modelBuilder.Entity<ReponseType>()
                .Property(e => e.trLibelle)
                .IsUnicode(false);

            modelBuilder.Entity<ReponseType>()
                .Property(e => e.trCreationUser)
                .IsUnicode(false);

            modelBuilder.Entity<ReponseType>()
                .Property(e => e.trModificationUser)
                .IsUnicode(false);

            modelBuilder.Entity<ReponseType>()
                .Property(e => e.trRowversion)
                .IsFixedLength();

            modelBuilder.Entity<RepresentationDonnees>()
                .Property(e => e.reNom)
                .IsUnicode(false);

            modelBuilder.Entity<RepresentationDonnees>()
                .Property(e => e.reCreationUser)
                .IsUnicode(false);

            modelBuilder.Entity<RepresentationDonnees>()
                .Property(e => e.reModificationUser)
                .IsUnicode(false);

            modelBuilder.Entity<RepresentationDonnees>()
                .Property(e => e.reRowversion)
                .IsFixedLength();

            modelBuilder.Entity<TypeRegroupement>()
                .Property(e => e.rgNom)
                .IsUnicode(false);

            modelBuilder.Entity<TypeRegroupement>()
                .Property(e => e.rgCreationUser)
                .IsUnicode(false);

            modelBuilder.Entity<TypeRegroupement>()
                .Property(e => e.rgModificationUser)
                .IsUnicode(false);

            modelBuilder.Entity<TypeRegroupement>()
                .Property(e => e.rgRowversion)
                .IsFixedLength();
        }
    }
}
