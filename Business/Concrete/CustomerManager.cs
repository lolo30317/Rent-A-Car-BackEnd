using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerdal;

        public CustomerManager(ICustomerDal customerdal)
        {
            _customerdal = customerdal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            _customerdal.Add(customer);
            return new SuccessResult();
        }

        public IResult Delete(Customer customer)
        {
            _customerdal.Delete(customer);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<Customer>> GetAll()
        {
           return new SuccessDataResult<List<Customer>>(_customerdal.GetAll());
        }
        [CacheAspect]
        public IDataResult<Customer> GetById(int id)
        {
           return new SuccessDataResult<Customer>(_customerdal.Get(c=>c.UserId==id));
        }

        public IResult Update(Customer customer)
        {
            _customerdal.Update(customer);
            return new SuccessResult();
        }
    }
}
