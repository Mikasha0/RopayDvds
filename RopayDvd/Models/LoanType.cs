using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RopayDvd.Models
{
    public partial class LoanType
    {
        public LoanType()
        {
            Loans = new HashSet<Loan>();
        }
        [Display(Name = "Loan Type No.")]
        public int LoanTypeNumber { get; set; }
        [Display(Name = "Loan Type")]
        public string LoanTypeName { get; set; }
        [Display(Name = "Loan Duration")]
        public int LoanDuration { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }
    }
}
