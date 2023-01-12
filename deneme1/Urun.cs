namespace deneme1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Urun")]
    public partial class Urun
    {
        public short id { get; set; }

        public double alis_fiyat { get; set; }

        public double satis_fiyat { get; set; }

        [Required]
        [StringLength(10)]
        public string tur { get; set; }

        public double? kar_marji { get; set; }

        public long? barkod { get; set; }

        public long? irsaliyeno { get; set; }

        public short? miktar { get; set; }

        public double? karlilik { get; set; }
    }
}
