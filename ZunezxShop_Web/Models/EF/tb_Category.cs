namespace ZunezxShop_Web.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("tb_Category")]
    public class Tb_Category
    {
        public Tb_Category()
        {
            this.News = new HashSet<Tb_News>();
            this.Post = new HashSet<Tb_Post>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        public string Title { get; set; }
        public string Alias { get; set; }

        public string Description { get; set; }

        public int? Position { get; set; }

        [StringLength(250)]
        public string SeoTitle { get; set; }

        public string SeoDescription { get; set; }

        [StringLength(250)]
        public string SeoKeywords { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(150)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(150)]
        public string ModifiedBy { get; set; }

        public virtual ICollection<Tb_News> News { get; set; }

        public virtual ICollection<Tb_Post> Post { get; set; }

    }
}
