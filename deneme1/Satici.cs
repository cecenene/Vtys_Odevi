namespace deneme1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Satici")]
    public partial class Satici
    {
        public short id { get; set; }

        [Required]
        [StringLength(10)]
        public string kullaniciad { get; set; }

        public short sifre { get; set; }
    }
}
