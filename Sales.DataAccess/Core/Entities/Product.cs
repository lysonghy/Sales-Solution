namespace Sales.DataAccess.Core.Entities
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
            OrderItems = new HashSet<OrderItem>();
        }

        public int ProductID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        [Column(TypeName = "money")]
        public decimal StandardPrice { get; set; }

        [Column(TypeName = "text")]
        public string Comment { get; set; }

        public bool OnlineFlag { get; set; }

        public int? ColorID { get; set; }

        public int? SizeID { get; set; }

        public int? ProductTypeID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public virtual ProductColor ProductColor { get; set; }

        public virtual ProductSize ProductSize { get; set; }

        public virtual ProductType ProductType { get; set; }
    }
}
