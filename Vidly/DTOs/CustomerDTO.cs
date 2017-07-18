using System;
using System.ComponentModel.DataAnnotations;
using Vidly.CustomValdiations;

namespace Vidly.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        //[Min18ToAMember]
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }
        public byte MembershipTypeId { get; set; }
    }
}