namespace ShopWatches.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Orders_Details = new HashSet<Orders_Details>();
        }

        public int ID { get; set; }

        public int? employeeID { get; set; }

        public int? customerID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? requested { get; set; }

        public float? totalMoney { get; set; }

        [StringLength(25)]
        public string statusOrder { get; set; }

        [StringLength(25)]
        public string statusPayment { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Employee Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders_Details> Orders_Details { get; set; }
    }
}
