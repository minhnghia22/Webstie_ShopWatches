namespace ShopWatches.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Cart = new HashSet<Cart>();
            Orders = new HashSet<Orders>();
        }

        [Key]
        public int IDCtm { get; set; }

        [StringLength(150)]
        public string emailCtm { get; set; }

        [StringLength(32)]
        public string passwordCtm { get; set; }

        [StringLength(70)]
        public string nameCtm { get; set; }

        [StringLength(15)]
        public string phoneCtm { get; set; }

        [Column(TypeName = "text")]
        public string addressCtm { get; set; }

        [Column(TypeName = "date")]
        public DateTime? birthdayCtm { get; set; }

        [StringLength(7)]
        public string genderCtm { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? created_at { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Cart { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
