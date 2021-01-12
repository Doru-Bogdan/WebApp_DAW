using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Entities
{
    public class UserDetails: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public DateTime BirthDate { get; set; }
        
        public virtual User User { get; set; }
    }
}
