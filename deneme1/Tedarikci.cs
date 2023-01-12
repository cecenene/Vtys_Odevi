namespace deneme1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tedarikci")]
    public partial class Tedarikci
    {
        public short id { get; set; }

        [Required]
        [StringLength(10)]
        public string tedarikciadi { get; set; }

        public double borcmiktari { get; set; }
    }
}
