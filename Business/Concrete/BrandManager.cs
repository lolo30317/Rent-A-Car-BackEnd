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
    public class BrandManager : IBrandService
    {
        IBrandDal _branddal;

        public BrandManager(IBrandDal branddal)
        {
            _branddal = branddal;
        }
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            _branddal.Add(brand);
            return new SuccessResult();
        }
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Delete(Brand brand)
        {
            _branddal.Delete(brand);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<List<Brand>> GetAll()
        {
           return new SuccessDataResult<List<Brand>>(_branddal.GetAll());
        }

        [CacheAspect]
        public IDataResult<List<Brand>> GetBrandById(int id)
        {
            return new SuccessDataResult<List<Brand>>(_branddal.GetAll(b => b.BrandId == id));
        }

        public IDataResult<List<Brand>> GetBrandList(string BrandName)
        {
            return new SuccessDataResult<List<Brand>>(_branddal.GetAll(b => b.BrandName == BrandName));
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            _branddal.Update(brand);
            return new SuccessResult();
        }

        
    }
}
