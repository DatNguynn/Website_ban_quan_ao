using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Web.Mvc;

namespace ZunezxShop_Web.Models.EF
{
    [Table("tb_Adv")]
    public class Tb_Adv
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage ="Tiêu đề không được để trống")]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        [AllowHtml]
        public string Detail { get; set; }

        public int? Type { get; set; }

        public string Alias { get; set; }
        
        public bool IsActive { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(150)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(150)]
        public string ModifiedBy { get; set; }
    }
}
