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
            Orders = new HashSet<Orders>();
        }

        [Key]
        public int IDEmp { get; set; }

        public int? roleID { get; set; }

        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Email incorrect format.")]
        [StringLength(150)]
        public string emailEmp { get; set; }

        [DataType(DataType.Password)]
        [StringLength(32)]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$", ErrorMessage = "Password at least 8 characters including 1 capital character, 1 letter, number and special characters.")]
        public string passwordEmp { get; set; }

        [RegularExpression(@"(?=^.{0,70}$)^[a-zA-Z-]+\s[a-zA-Z-]+$", ErrorMessage = "The name must be 2 words.")]
        [StringLength(50)]
        public string nameEmp { get; set; }

        [RegularExpression(@"((09|03|07|08|05)+([0-9]{8})\b)", ErrorMessage = "Numberphone incorrect format.")]
        [StringLength(15)]
        public string phoneEmp { get; set; }

        public int? IDcard { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "text")]
        public string addressEmp { get; set; }

        [Column(TypeName = "date")]
        public DateTime? birthdayEmp { get; set; }

        [StringLength(7)]
        public string genderEmp { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? created_at { get; set; }

        public virtual Role Role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
