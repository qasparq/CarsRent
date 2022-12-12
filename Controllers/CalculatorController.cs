using CarsRent.Data;
using CarsRent.Entities;
using CarsRent.Models;
using CarsRent.Repository;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarsRent.Controllers
{
    [Route("api[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new CarsRentDbContext());

        [HttpGet]
        public async Task<ActionResult<List<Car>>> getCars()
        {
            return Ok(unitOfWork.CarRepository.GetAll());
        }

        //asign a location to the car
        [HttpGet("{id}")]
        public ActionResult<List<CarRentDetails>> CarsToRent(int id, [FromQuery] InputData input)
        {
            var fuelPrice = 3.17f;
            var youngDriver = 1.2f;
            var cars = unitOfWork.CarRepository.GetAll().ToList();
            var location = unitOfWork.RentalPlaceRepository.GetById;
            var smallNumberCars = 1.15f;
            
            List<Car> carToRentDetails = new List<Car>();
            var car = unitOfWork.CarRepository.GetById(id);
            var rentPlace = unitOfWork.RentalPlaceRepository.GetRentalPlace(car.Id);

            var drivingExperiance = (DateTime.Today.Year - input.YearDrivingLicense);
            var rentDays = input.EndRent.Subtract(input.StartRent).Days;
            var carTypeCost = (float)car.CarType;

            var fuelCost = (input.Distance/car.Combustion) * fuelPrice;

            var totalPrice = (rentPlace.BasePrice * rentDays * carTypeCost) + fuelCost;
            var localCarCity = rentPlace.City;

            if (drivingExperiance < 5) totalPrice *= youngDriver;
            if (car.CarAvaible < 3) totalPrice *= smallNumberCars;

            CarRentDetails carRentDetails = new CarRentDetails
            {
                car = car,
                Location = rentPlace.City,
                EndPrice = totalPrice,
                FuelPrice = fuelCost,
            };

            return Ok(carRentDetails);

        }

        [HttpPost("addReservation")]
        public ActionResult AddReservation([FromQuery]ReservationDTO reservation)
        {
            var car = unitOfWork.CarRepository.GetById(reservation.CarId);
            var newReservation = new Reservation
            {
                Id = 0,
                Car = car,
                Email = reservation.Email,
            };

            unitOfWork.ReservationRepository.Insert(newReservation);
            unitOfWork.Save();

            return Ok(newReservation);
        }
    }
}
