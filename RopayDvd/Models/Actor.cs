using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RopayDvd.Models
{
    public partial class Actor
    {
        public Actor()
        {
            CastMembers = new HashSet<CastMember>();
        }
        [Display(Name ="Actor No.")]
        public int ActorNumber { get; set; }
        [Display(Name = "Last Name")]
        public string ActorLastName { get; set; }
        [Display(Name = "First Name")]
        public string ActorFirstName { get; set; }

        public virtual ICollection<CastMember> CastMembers { get; set; }
    }
}
