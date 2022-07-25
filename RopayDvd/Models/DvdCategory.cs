using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RopayDvd.Models
{
    public partial class DvdCategory
    {
        public DvdCategory()
        {
            DvdTitles = new HashSet<DvdTitle>();
        }
        [Display(Name = "Category No.")]
        public int CategoryNumber { get; set; }
        [Display(Name = "Category Description")]
        public string CategoryDescription { get; set; }
        [Display(Name = "Age Restricted")]
        public bool AgeRestricted { get; set; }

        public virtual ICollection<DvdTitle> DvdTitles { get; set; }
    }
}
