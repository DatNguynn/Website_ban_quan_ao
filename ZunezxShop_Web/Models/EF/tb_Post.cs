namespace ZunezxShop_Web.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("tb_Post")]
    public class Tb_Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        public string Title { get; set; }

        public int CategoryId { get; set; }

        public string Alias { get; set; }

        public string Description { get; set; }

        [AllowHtml]
        public string Detail { get; set; }

        [StringLength(500)]
        public string Image { get; set; }

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

        public bool IsActive { get; set; }

        public virtual Tb_Category Category { get; set; }
    }
}
