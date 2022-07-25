using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RopayDvd.Models
{
    public partial class Producer
    {
        public Producer()
        {
            DvdTitles = new HashSet<DvdTitle>();
        }
        [Display(Name = "Producer No.")]
        public int ProducerNumber { get; set; }
        [Display(Name = "Producer Name")]
        public string ProducerName { get; set; }

        public virtual ICollection<DvdTitle> DvdTitles { get; set; }
    }
}
