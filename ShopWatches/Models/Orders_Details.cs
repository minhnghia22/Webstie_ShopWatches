namespace ShopWatches.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orders_Details
    {
        public int? ProductID { get; set; }

        public int? OrderID { get; set; }

        public float? price { get; set; }

        public int? quantities { get; set; }

        public int ID { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
