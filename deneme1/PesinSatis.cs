namespace deneme1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PesinSatis
    {
        public short id { get; set; }

        [Required]
        [StringLength(10)]
        public string saticiadi { get; set; }

        public short urunid { get; set; }

        public int miktar { get; set; }

        [Required]
        [StringLength(10)]
        public string musteriadi { get; set; }
    }
}
