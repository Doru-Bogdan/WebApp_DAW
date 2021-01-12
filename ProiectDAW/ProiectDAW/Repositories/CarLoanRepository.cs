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
    public class CarLoanRepository: GenericRepository<CarLoan>, ICarLoanRepository
    {
        public CarLoanRepository(DAWAppContext context): base(context)
        {
        }
    }
}
