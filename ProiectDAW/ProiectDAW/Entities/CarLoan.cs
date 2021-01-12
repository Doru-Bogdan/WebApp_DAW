using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Entities
{
    public class CarLoan: BaseEntity
    {
        public int UserId { get; set; }
        public int VehicleId { get; set; }
        public DateTime StartLoanDate { get; set; }
        public DateTime EndLoanDate { get; set; }

        public virtual User User { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
