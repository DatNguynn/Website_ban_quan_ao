namespace ZunezxShop_Web.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("tb_SystemSetting")]
    public class Tb_SystemSetting
    {
        [Key]
        [StringLength(50)]
        public string SettingKey { get; set; }

        public string SettingValue { get; set; }

        [StringLength(500)]
        public string SettingDescription { get; set; }
    }
}
