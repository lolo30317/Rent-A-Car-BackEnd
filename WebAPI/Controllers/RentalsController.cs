using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalservice;

        public RentalsController(IRentalService rentalservice)
        {
            _rentalservice = rentalservice;
        }

        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            var result = _rentalservice.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetRentalsDetails")]

        public IActionResult GetRentalsDetails()
        {
            var result = _rentalservice.GetRentalsDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetById")]

        public IActionResult GetById(int id)
        {
            var result = _rentalservice.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]

        public IActionResult Add(Rental rental)
        {
            var result = _rentalservice.Update(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]

        public IActionResult Delete(Rental rental)
        {
            var result = _rentalservice.Delete(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]

        public IActionResult Update(Rental rental)
        {
            var result = _rentalservice.Update(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
