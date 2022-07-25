using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RopayDvd.Models
{
    public partial class Studio
    {
        public Studio()
        {
            DvdTitles = new HashSet<DvdTitle>();
        }
        [Display(Name = "Studio No.")]
        public int StudioNumber { get; set; }
        [Display(Name = "Studio Name")]
        public string StudioName { get; set; }

        public virtual ICollection<DvdTitle> DvdTitles { get; set; }
    }
}
