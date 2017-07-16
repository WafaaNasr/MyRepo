using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerViewModel
    {
        //Ienumberable is enough bec in View we won't leverage the List functionalities (Add, Remove, find...)
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }// In Most cases Customer VM will vary from the actual POCO Model in this case we will take just the needed props
    }
}