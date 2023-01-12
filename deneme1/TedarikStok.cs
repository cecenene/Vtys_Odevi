namespace deneme1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TedarikStok")]
    public partial class TedarikStok
    {
        public short id { get; set; }

        [Required]
        [StringLength(10)]
        public string tedarikciadi { get; set; }

        [Required]
        [StringLength(10)]
        public string urun { get; set; }

        [StringLength(10)]
        public string miktar { get; set; }
    }
}
