using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Entities
{
    public class CarBrand: BaseEntity
    {
        public string BrandName { get; set; }

        public virtual List<Vehicle> Vehicles { get; set; }
    }
}
