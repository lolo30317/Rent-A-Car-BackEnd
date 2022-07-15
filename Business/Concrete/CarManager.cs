using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
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
    public class CarManager : ICarService
    {
        ICarDal _cardal;
        ICarImageService _carImageService;
        public CarManager(ICarDal cardal,ICarImageService carImageService)
        {
            _cardal = cardal;
            _carImageService = carImageService;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
           
            _cardal.Add(car);
            AddDefultCarImage(car.Description);
            return new SuccessResult(Messages.CarAdded);
        }

        
        public IResult Delete(Car car)
        {
            try
            {
                _cardal.Delete(car);
                return new SuccessResult(Messages.DeletedCar);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.CarNotDeleted);
            }
        }



        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==7)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_cardal.GetAll(),Messages.CarListed); 
        }

        public IDataResult<List<Car>> GetAllByBrandId(int brandid)
        {
            return new SuccessDataResult<List<Car>>(_cardal.GetAll(p => p.BrandId == brandid),Messages.CarsListedByBrandId); ;
        }

        public IDataResult<List<Car>> GetAllByColorId(int colorid)
        {
            return new SuccessDataResult<List<Car>>(_cardal.GetAll(p => p.ColorId == colorid), Messages.CarsListedByColorId);
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>( _cardal.GetAll(p=>p.DailyPrice>=min &&p.DailyPrice<=max));
        }

        public IDataResult<Car> GetCarByDesription(string description)
        {
            return new SuccessDataResult<Car>(_cardal.Get(c => c.Description.Equals(description)));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_cardal.GetCarsDetails(), Messages.CarsDetailsListed);
        }

        public IDataResult<List<Car>> GetFilteredCars(int brandid, int colorid)
        {
            return new SuccessDataResult<List<Car>>(_cardal.GetAll(p => p.BrandId == brandid && p.ColorId == colorid));
        }

        
        public IResult Update(Car car)
        {
           _cardal.Update(car);
            return new SuccessResult();
        }

        private IResult AddDefultCarImage(string description)
        {
            var car = GetCarByDesription(description).Data;
            var result = _carImageService.DefaultControl(car.Id);
            if (result.Success)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
