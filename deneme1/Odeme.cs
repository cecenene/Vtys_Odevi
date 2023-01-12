namespace deneme1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Odeme")]
    public partial class Odeme
    {
        public short id { get; set; }

        [Required]
        [StringLength(10)]
        public string saticiadi { get; set; }

        [Required]
        [StringLength(10)]
        public string musteriadi { get; set; }

        [Column(TypeName = "date")]
        public DateTime odemetarihi { get; set; }

        public double odememiktari { get; set; }
    }
}
