using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetAllByBrandId(int brandid);
        IDataResult<List<Car>> GetAllByColorId(int colorid);
        IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<Car>> GetFilteredCars(int brandid, int colorid);
        IDataResult<Car> GetCarByDesription(string description);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        
    }
}
