using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RopayDvd.Models
{
    public partial class CastMember
    {
        [Display(Name = "DVD No.")]
        public int DvdNumber { get; set; }
        [Display(Name = "Actor No.")]
        public int ActorNumber { get; set; }
        [Display(Name = "Actor Name")]
        public virtual Actor ActorNumberNavigation { get; set; }
        [Display(Name = "DVD Title")]
        public virtual DvdTitle DvdNumberNavigation { get; set; }
    }
}
