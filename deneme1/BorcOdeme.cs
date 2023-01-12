namespace deneme1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BorcOdeme")]
    public partial class BorcOdeme
    {
        public short id { get; set; }

        [Required]
        [StringLength(10)]
        public string tedarikciadi { get; set; }

        [Column(TypeName = "date")]
        public DateTime odemetarihi { get; set; }

        public double miktar { get; set; }
    }
}
