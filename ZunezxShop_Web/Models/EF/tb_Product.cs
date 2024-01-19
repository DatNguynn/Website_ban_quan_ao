﻿namespace ZunezxShop_Web.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("tb_Product")]
    public class Tb_Product
    {
        public Tb_Product()
        {
            this.OrderDetail = new HashSet<Tb_OrderDetail>();
            this.ProductImage = new HashSet<tb_ProductImage>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        public string Title { get; set; }

        public int ProductCategoryId { get; set; }

        [StringLength(250)]
        public string Alias { get; set; }

        [StringLength(150)]
        public string ProductCode { get; set; }

        public string Description { get; set; }
        [AllowHtml]
        public string Detail { get; set; }

        [StringLength(500)]
        public string Image { get; set; }

        [Required(ErrorMessage = "Giá không được để trống")]
        public decimal OriginalPrice { get; set; }

        [Required(ErrorMessage = "Giá không được để trống")]
        public decimal Price { get; set; }

        public decimal? PriceSale { get; set; }

        [Required(ErrorMessage = "Số lượng không được để trống")]
        public int Quantity { get; set; }

        public bool IsHome { get; set; }

        public bool IsSale { get; set; }

        public bool IsFeature { get; set; }

        public bool IsHot { get; set; }

        public bool IsActive { get; set; }

        [StringLength(250)]
        public string SeoTitle { get; set; }

        public string SeoDescription { get; set; }

        [StringLength(250)]
        public string SeoKeywords { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(150)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(150)]
        public string ModifiedBy { get; set; }

        public virtual ICollection<Tb_OrderDetail> OrderDetail { get; set; }

        public virtual Tb_ProductCategory ProductCategory { get; set; }

        public virtual ICollection<tb_ProductImage> ProductImage { get; set; }
    }
}
