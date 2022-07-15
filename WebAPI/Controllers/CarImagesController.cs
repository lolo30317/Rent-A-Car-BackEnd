using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
       
        public class CarImagesController : ControllerBase
        {
            ICarImageService _carImageservice;

            public CarImagesController(ICarImageService carImageservice)
            {
                _carImageservice = carImageservice;
            }

            [HttpGet("getall")]

            public IActionResult GetAll()
            {
                var result = _carImageservice.GetAll();
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }

            [HttpGet("GetAllByCarId")]

            public IActionResult GetAllByCarId(int carId)
            {
                var result = _carImageservice.GetById(carId);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }


            [HttpPost("upload")]
            public IActionResult Upload([FromForm] IFormFile file, [FromForm] CarImage carImage)
            {
                var result = _carImageservice.Add(file, carImage);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }

            [HttpPost("delete")]
            public IActionResult Delete(CarImage carImage)
            {
                var result = _carImageservice.Delete(carImage);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }

            [HttpPost("update")]
            public IActionResult Update([FromForm] IFormFile file, [FromForm] CarImage carImage)
            {
                var result = _carImageservice.Update(file, carImage);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
        }
    
}
