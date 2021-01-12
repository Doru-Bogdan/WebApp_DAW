using DAW.Data;
using DAW.Entities;
using DAW.Repositories;
using ProiectDAW.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Repositories
{
    public class VehicleRepository: GenericRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(DAWAppContext context): base(context)
        {
        }
    }
}
