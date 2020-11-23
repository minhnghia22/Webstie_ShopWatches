namespace ShopWatches.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Picture")]
    public partial class Picture
    {
        public int ID { get; set; }

        public int? productID { get; set; }

        [StringLength(255)]
        public string url { get; set; }

        [StringLength(150)]
        public string name { get; set; }

        public virtual Product Product { get; set; }
    }
}
