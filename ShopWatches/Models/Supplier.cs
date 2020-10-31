namespace ShopWatches.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public int IDSup { get; set; }

        [StringLength(50)]
        public string nameSup { get; set; }

        [StringLength(50)]
        public string phoneSup { get; set; }

        [StringLength(150)]
        public string emailSup { get; set; }

        [Column(TypeName = "text")]
        public string addressSup { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
