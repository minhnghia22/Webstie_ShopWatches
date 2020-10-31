namespace ShopWatches.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [Column(TypeName = "text")]
        public string descrption { get; set; }
    }
}
