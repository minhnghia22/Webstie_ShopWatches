namespace ShopWatches.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        public int IDEmp { get; set; }

        public int? roleID { get; set; }

        [StringLength(150)]
        public string emailEmp { get; set; }

        [StringLength(32)]
        public string passwordEmp { get; set; }

        [StringLength(50)]
        public string nameEmp { get; set; }

        [StringLength(15)]
        public string phoneEmp { get; set; }

        public int? IDcard { get; set; }

        [Column(TypeName = "text")]
        public string addressEmp { get; set; }

        [Column(TypeName = "date")]
        public DateTime? birthdayEmp { get; set; }

        [StringLength(5)]
        public string genderEmp { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? created_at { get; set; }

        public virtual Role Role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
