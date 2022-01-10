using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASPAppliFinale.Models
{
    public class BDContext : DbContext
    {
        public DbSet<Proprio> Proprios { get; set; }
        public DbSet<Annonce> Annonces { get; set; }
        public DbSet<Marque> Marques { get; set; }
        public DbSet<Modele> Modeles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proprio>().HasKey(a => a.IDProprio);
            modelBuilder.Entity<Annonce>().HasKey(a => a.IDAnnonce);
            modelBuilder.Entity<Marque>().HasKey(a => a.IDMarque);
            modelBuilder.Entity<Modele>().HasKey(a => a.IDModel);

            modelBuilder.Entity<Proprio>()
                .Map(m =>
                {
                    m.Properties(p => new { p.IDProprio, p.PNom, p.PPrenom, p.PNumTel, p.PMail, p.PMdp });
                    m.ToTable("TProprio");
                });
            modelBuilder.Entity<Annonce>()
                .Map(m =>
                {
                    m.Properties(p => new { p.IDAnnonce, p.IDProprio, p.IDModel, p.AAnnee, p.AKilometrage, p.ACouleur, p.APrix, p.AStatut });
                    m.ToTable("TAnnonce");
                });
            modelBuilder.Entity<Marque>()
                .Map(m =>
                {
                    m.Properties(p => new { p.IDMarque, p.MNom });
                    m.ToTable("TMarque");
                });
            modelBuilder.Entity<Modele>()
                .Map(m =>
                {
                    m.Properties(p => new { p.IDModel, p.IDMarque, p.MNom });
                    m.ToTable("TModel");
                });

            modelBuilder.Entity<Proprio>().HasMany(a => a.Annonces).WithRequired(b => b.Proprio).HasForeignKey<int>(c => c.IDProprio);
            modelBuilder.Entity<Annonce>().HasRequired(a => a.Proprio).WithMany(b => b.Annonces).HasForeignKey<int>(c => c.IDProprio);
            modelBuilder.Entity<Annonce>().HasRequired(a => a.Modele).WithMany(b => b.Annonces).HasForeignKey<int>(c => c.IDModel);
            modelBuilder.Entity<Marque>().HasMany(a => a.Modeles).WithRequired(b => b.Marque).HasForeignKey<int>(c => c.IDMarque);
            modelBuilder.Entity<Modele>().HasMany(a => a.Annonces).WithRequired(b => b.Modele).HasForeignKey<int>(c => c.IDModel);
            modelBuilder.Entity<Modele>().HasRequired(a => a.Marque).WithMany(b => b.Modeles).HasForeignKey<int>(c => c.IDMarque);

            modelBuilder.Entity<Proprio>().Property(m => m.PMail).IsRequired();
            modelBuilder.Entity<Proprio>().Property(m => m.PMdp).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}