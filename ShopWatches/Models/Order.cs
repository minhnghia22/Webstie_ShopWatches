namespace ShopWatches.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        public int ID { get; set; }

        public int? employeeID { get; set; }

        public int? customerID { get; set; }

        public TimeSpan? requested { get; set; }

        public float? totalMoney { get; set; }

        [StringLength(25)]
        public string statusOrder { get; set; }

        [StringLength(25)]
        public string statusPayment { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
