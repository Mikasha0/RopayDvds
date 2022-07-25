using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RopayDvd.Models
{
    public partial class DvdCopy
    {
        public DvdCopy()
        {
            Loans = new HashSet<Loan>();
        }
        [Display(Name = "Copy No.")]
        public long CopyNumber { get; set; }
        [Display(Name = "DVD Title")]
        public int? DvdNumber { get; set; }
        [Display(Name = "Purchased Date")]
        [DataType(DataType.Date)]
        public DateTime DatePurchased { get; set; }
        [Display(Name = "DVD Title")]
        public virtual DvdTitle DvdNumberNavigation { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
    }
}
