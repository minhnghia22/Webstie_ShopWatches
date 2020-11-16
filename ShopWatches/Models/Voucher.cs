namespace ShopWatches.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Voucher")]
    public partial class Voucher
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string code { get; set; }

        public int? status { get; set; }

        [Column(TypeName = "date")]
        public DateTime? exprityDate { get; set; }

        public float? value { get; set; }
    }
}
