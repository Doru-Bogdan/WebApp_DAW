using DAW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.IServices
{
    public interface IVehicleService
    {
        List<Vehicle> GetAll();
        Vehicle GetById(int id);
        bool Insert(Vehicle course);
        bool Update(Vehicle course);
        bool Delete(int id);
    }
}
