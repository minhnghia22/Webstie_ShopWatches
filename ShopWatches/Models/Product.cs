namespace ShopWatches.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Pictures = new HashSet<Picture>();
        }

        public int ID { get; set; }

        public int? SupplierID { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public float? price { get; set; }

        public int? quantities { get; set; }

        [StringLength(50)]
        public string status { get; set; }

        [StringLength(10)]
        public string warrantyTime { get; set; }

        [StringLength(50)]
        public string originName { get; set; }

        [StringLength(255)]
        public string img { get; set; }

        [Column(TypeName = "text")]
        public string detail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Picture> Pictures { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
