using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RopayDvd.Models
{
    public partial class MembershipCategory
    {
        public MembershipCategory()
        {
            Members = new HashSet<Member>();
        }
        [Display(Name = "Membership Category No.")]
        public int MembershipCategoryNumber { get; set; }
        [Display(Name = "Description")]
        public string MembershipCategoryDescription { get; set; }
        [Display(Name = "Total Loans")]
        public int MembershipCategoryTotalLoans { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}
