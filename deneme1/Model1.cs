using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace deneme1
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model111")
        {
        }

        public virtual DbSet<BorcOdeme> BorcOdeme { get; set; }
        public virtual DbSet<Musteri> Musteri { get; set; }
        public virtual DbSet<Odeme> Odeme { get; set; }
        public virtual DbSet<PesinSatis> PesinSatis { get; set; }
        public virtual DbSet<Satici> Satici { get; set; }
        public virtual DbSet<Tedarik> Tedarik { get; set; }
        public virtual DbSet<Tedarikci> Tedarikci { get; set; }
        public virtual DbSet<Urun> Urun { get; set; }
        public virtual DbSet<VeresiyeSatis> VeresiyeSatis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BorcOdeme>()
                .Property(e => e.tedarikciadi)
                .IsFixedLength();

            modelBuilder.Entity<Musteri>()
                .Property(e => e.musteriadi)
                .IsFixedLength();

            modelBuilder.Entity<Odeme>()
                .Property(e => e.saticiadi)
                .IsFixedLength();

            modelBuilder.Entity<Odeme>()
                .Property(e => e.musteriadi)
                .IsFixedLength();

            modelBuilder.Entity<PesinSatis>()
                .Property(e => e.saticiadi)
                .IsFixedLength();

            modelBuilder.Entity<PesinSatis>()
                .Property(e => e.musteriadi)
                .IsFixedLength();

            modelBuilder.Entity<Satici>()
                .Property(e => e.kullaniciad)
                .IsFixedLength();

            modelBuilder.Entity<Tedarik>()
                .Property(e => e.tedarikciadi)
                .IsFixedLength();

            modelBuilder.Entity<Tedarikci>()
                .Property(e => e.tedarikciadi)
                .IsFixedLength();

            modelBuilder.Entity<Urun>()
                .Property(e => e.tur)
                .IsUnicode(false);

            modelBuilder.Entity<VeresiyeSatis>()
                .Property(e => e.saticiadi)
                .IsFixedLength();

            modelBuilder.Entity<VeresiyeSatis>()
                .Property(e => e.musteriadi)
                .IsFixedLength();
        }
    }
}
