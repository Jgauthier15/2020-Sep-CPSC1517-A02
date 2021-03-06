﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespace
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace NorthwindSystem.Entities
{
    [Table("Region")]
    public class Region
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RegionID { get; set; }

        [Required(ErrorMessage ="Region description is required.")]
        [StringLength(50,ErrorMessage ="Region description is limited to 50 characters.")]
        public string RegionDescription { get; set; }
    }
}
