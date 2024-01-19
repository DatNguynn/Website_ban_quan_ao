namespace ZunezxShop_Web.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("tb_OrderDetail")]
    public class Tb_OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public decimal? Price { get; set; }

        public int? Quantity { get; set; }

        public virtual Tb_Order Order { get; set; }

        public virtual Tb_Product Product { get; set; }
    }
}
