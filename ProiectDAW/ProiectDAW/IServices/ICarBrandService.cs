using DAW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.IServices
{
    public interface ICarBrandService
    {
        List<CarBrand> GetAll();
        CarBrand GetById(int id);
        bool Insert(CarBrand course);
        bool Update(CarBrand course);
        bool Delete(int id);
    }
}
