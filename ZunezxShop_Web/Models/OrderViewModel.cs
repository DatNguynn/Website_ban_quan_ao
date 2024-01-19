using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZunezxShop_Web.Models
{
    public class OrderViewModel
    {
        [StringLength(150)]
        [Required(ErrorMessage = "Tên không được để trống")]
        public string CustomerName { get; set; }

        [StringLength(12)]
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string Phone { get; set; }

        [StringLength(500)]
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        public string Address { get; set; }

        public int TypePayment { get; set; }
    }
}