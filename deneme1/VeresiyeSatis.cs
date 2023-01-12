namespace deneme1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VeresiyeSatis
    {
        public short id { get; set; }

        [Required]
        [StringLength(10)]
        public string saticiadi { get; set; }

        public short urunid { get; set; }

        [Column(TypeName = "date")]
        public DateTime satistarihi { get; set; }

        public double miktar { get; set; }

        [Required]
        [StringLength(10)]
        public string musteriadi { get; set; }

        public double? tutar { get; set; }

        public double? borcbakiyesi { get; set; }
    }
}
