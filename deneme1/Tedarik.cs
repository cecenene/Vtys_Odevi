namespace deneme1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tedarik")]
    public partial class Tedarik
    {
        public short id { get; set; }

        [Required]
        [StringLength(10)]
        public string tedarikciadi { get; set; }

        public string tur { get; set; }

        public double miktar { get; set; }

        public double alisfiyat { get; set; }

        public long? irsaliyenumarasi { get; set; }
    }
}
