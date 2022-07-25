using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RopayDvd.Models
{
    public partial class Loan
    {
        [Display(Name = "Loan No.")]
        public long LoanNumber { get; set; }
        [Display(Name = "Loan Type")]
        public int LoanTypeNumber { get; set; }
        [Display(Name = "Copy No.")]
        public long CopyNumber { get; set; }
        [Display(Name = "Member Name")]
        public long MemberNumber { get; set; }
        [Display(Name = "Loan Date")]
        [DataType(DataType.Date)]
        public DateTime DateOut { get; set; }
        [Display(Name = "Due Date")]
        [DataType(DataType.Date)]
        public DateTime DateDue { get; set; }
        [Display(Name = "Returned Date")]
        [DataType(DataType.Date)]
        public DateTime? DateReturned { get; set; }
        [Display(Name = "Copy No.")]
        public virtual DvdCopy CopyNumberNavigation { get; set; }
        [Display(Name = "Loan Type")]
        public virtual LoanType LoanTypeNumberNavigation { get; set; }
        [Display(Name = "Member Name")]
        public virtual Member MemberNumberNavigation { get; set; }
    }
}
