using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentaldal;

        public RentalManager(IRentalDal rentaldal)
        {
            _rentaldal = rentaldal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            _rentaldal.Add(rental);
            return new SuccessResult();
        }

        public IResult Delete(Rental rental)
        {
            _rentaldal.Delete(rental);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentaldal.GetAll());
        }
        [CacheAspect]
        public IDataResult<Rental> GetById(int Id)
        {
            return new SuccessDataResult<Rental>(_rentaldal.Get(r => r.Id == Id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalsDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentaldal.GetRentalDetails());
        }

        public IResult Update(Rental rental)
        {
            _rentaldal.Update(rental);
            return new SuccessResult();
        }
    }
}
