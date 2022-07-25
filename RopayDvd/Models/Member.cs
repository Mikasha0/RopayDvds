using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RopayDvd.Models
{
    public partial class Member
    {
        public Member()
        {
            Loans = new HashSet<Loan>();
        }
        [Display(Name = "Member No.")]
        public long MemberNumber { get; set; }
        [Display(Name = "Member Category No.")]
        public int MembershipCategoryNumber { get; set; }
        [Display(Name = "Last Name")]
        public string MemberLastName { get; set; }
        [Display(Name = "First Name")]
        public string MemberFirstName { get; set; }
        [Display(Name = "Address")]
        public string MemberAddress { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? MemberDateOfBirth { get; set; }

        public virtual MembershipCategory MembershipCategoryNumberNavigation { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
    }
}
