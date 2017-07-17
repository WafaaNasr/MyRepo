using System;
using System.ComponentModel.DataAnnotations;
using Vidly.CustomValdiations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Customer's Name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Date Of Birth")]
        [Min18ToAMember]
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }

        //NB: When Using the Foreign key with different datatype ex: int MembershipType entity framework won't consider it as the foriegn key and will generate new One with underscore in the database for applying the 1-m relation
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}