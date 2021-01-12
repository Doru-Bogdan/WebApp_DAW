using DAW.Entities;
using ProiectDAW.IRepositories;
using ProiectDAW.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Services
{
    public class VehicleService: IVehicleService
    {
        private readonly IVehicleRepository _repository;
        public VehicleService(IVehicleRepository repository)
        {
            this._repository = repository;
        }

        public bool Delete(int id)
        {
            var student = _repository.FindById(id);
            _repository.Delete(student);
            return _repository.SaveChanges();
        }

        public List<Vehicle> GetAll()
        {
            return _repository.GetAllActive();
        }

        public Vehicle GetById(int id)
        {
            return _repository.FindById(id);
        }

        public bool Insert(Vehicle vehicle)
        {
            _repository.Create(vehicle);
            return _repository.SaveChanges();
        }

        public bool Update(Vehicle vehicle)
        {
            _repository.Update(vehicle);
            return _repository.SaveChanges();
        }
    }
}
