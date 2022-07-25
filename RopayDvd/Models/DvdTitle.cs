using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RopayDvd.Models
{
    public partial class DvdTitle
    {
        public DvdTitle()
        {
            CastMembers = new HashSet<CastMember>();
            DvdCopies = new HashSet<DvdCopy>();
        }
        [Display(Name = "DVD No.")]
        public int DvdNumber { get; set; }
        [Display(Name = "Category Name.")]
        public int CategoryNumber { get; set; }
        [Display(Name = "Studio Name.")]
        public int StudioNumber { get; set; }
        [Display(Name = "Producer Name.")]
        public int ProducerNumber { get; set; }
        [Display(Name = "DVD Title")]
        public string DvdTite { get; set; }
        [Display(Name = "Released Date")]
        [DataType(DataType.Date)]
        public DateTime DateReleased { get; set; }
        [Display(Name = "Standard Charge")]
        public decimal StandardCharge { get; set; }
        [Display(Name = "Penalty Charge")]
        public decimal PenaltyCharge { get; set; }
        [Display(Name = "Category Name.")]
        public virtual DvdCategory CategoryNumberNavigation { get; set; }
        [Display(Name = "Producer Name.")]
        public virtual Producer ProducerNumberNavigation { get; set; }
        [Display(Name = "Studio Name.")]
        public virtual Studio StudioNumberNavigation { get; set; }
        public virtual ICollection<CastMember> CastMembers { get; set; }
        public virtual ICollection<DvdCopy> DvdCopies { get; set; }
    }
}
