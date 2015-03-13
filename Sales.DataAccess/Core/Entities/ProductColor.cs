namespace Sales.DataAccess.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductColor")]
    public partial class ProductColor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductColor()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public int ColorID { get; set; }

        [Required]
        [StringLength(50)]
        public string Color { get; set; }

        [Column(TypeName = "text")]
        public string Comment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
