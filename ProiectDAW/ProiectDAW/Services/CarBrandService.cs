using DAW.Entities;
using ProiectDAW.IRepositories;
using ProiectDAW.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Services
{
    public class CarBrandService: ICarBrandService
    {
        private readonly ICarBrandRepository _repository;
        public CarBrandService(ICarBrandRepository repository)
        {
            this._repository = repository;
        }

        public bool Delete(int id)
        {
            var student = _repository.FindById(id);
            _repository.Delete(student);
            return _repository.SaveChanges();
        }

        public List<CarBrand> GetAll()
        {
            return _repository.GetAllActive();
        }

        public CarBrand GetById(int id)
        {
            return _repository.FindById(id);
        }

        public bool Insert(CarBrand carBrand)
        {
            _repository.Create(carBrand);
            return _repository.SaveChanges();
        }

        public bool Update(CarBrand carBrand)
        {
            _repository.Update(carBrand);
            return _repository.SaveChanges();
        }
    }
}
