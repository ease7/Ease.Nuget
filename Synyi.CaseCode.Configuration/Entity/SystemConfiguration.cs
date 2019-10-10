using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Synyi.CaseCode.Configuration.Entity
{
    /// <summary>
    /// 系统配置项
    /// </summary>
    public class SystemConfiguration
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Column("key")]
        [StringLength(255)]
        public string Key { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("value")]
        public string Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("description")]
        [StringLength(255)]
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("category")]
        [StringLength(255)]
        public string Category { get; set; }
    }
}
