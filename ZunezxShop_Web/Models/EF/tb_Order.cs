namespace ZunezxShop_Web.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("tb_Order")]
    public class Tb_Order
    {
        public Tb_Order()
        {
            this.OrderDetail = new HashSet<Tb_OrderDetail>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(150)]
        [Required(ErrorMessage = "Tên không được để trống")]
        public string CustomerName { get; set; }

        [StringLength(12)]
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string Phone { get; set; }

        [StringLength(500)]
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        public string Address { get; set; }

        public decimal? TotalAmount { get; set; }

        public int? Quantity { get; set; }

        public int TypePayment { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(150)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(150)]
        public string ModifiedBy { get; set; }

        public virtual ICollection<Tb_OrderDetail> OrderDetail { get; set; }
    }
}
