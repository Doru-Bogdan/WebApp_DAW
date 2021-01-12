using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Entities
{
    public class Vehicle: BaseEntity
    {
        public int CarBrandId { get; set; }
        public string VehicleName { get; set; }
        public float EngineCapacity { get; set; }
        public int EnginePower { get; set; }
        public int TrunkSpace { get; set; }

        public virtual CarBrand CarBrand { get; set; }
        public virtual List<CarLoan> CarLoans { get; set; }
    }
}
