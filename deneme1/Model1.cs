using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace deneme1
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }

        public virtual DbSet<Musteri> Musteri { get; set; }
        public virtual DbSet<Urun> Urun { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Musteri>()
                .Property(e => e.isim)
                .IsFixedLength();

            modelBuilder.Entity<Musteri>()
                .Property(e => e.soyisim)
                .IsFixedLength();

            modelBuilder.Entity<Urun>()
                .Property(e => e.tur)
                .IsUnicode(false);
        }
    }
}
