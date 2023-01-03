namespace deneme1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Musteri")]
    public partial class Musteri
    {
        public short id { get; set; }

        [Required]
        [StringLength(10)]
        public string isim { get; set; }

        [Required]
        [StringLength(10)]
        public string soyisim { get; set; }

        public double? bakiye { get; set; }
    }
}
