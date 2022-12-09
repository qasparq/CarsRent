using CarsRent.Data;
using CarsRent.Entities;
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

        //[HttpGet("{id}")]
        //public async Task<ActionResult<List<Car>>> getCarRent(int id, [FromQuery] InputData Data)
        //{
        //    var fuelPrice = 4.17f;
        //    var today = DateTime.Now.Year;
        //    var car = await _context.Cars.FindAsync(id);
        //    var placeholder = "";
        //    if (today - Data.YearDrivingLicense < 3 && car.CarType == CarsRentDbContext.CarTypE.Premium)
        //    {
        //         return BadRequest("Nie możesz wypożyczyć tego samochodu");
        //    }
        //    placeholder += "Cena paliwa: " + fuelPrice + "\r\n";
        //    placeholder += "Twoje auto: " + car.Name + "\r\n";

        //    var IloscDni = Data.End.Subtract(Data.Start).Days; // mm/dd/yyyy
        //    placeholder += "Samochod wypożyczony na: " + IloscDni + " dni. \r\n";

        //    //var BasePrice = Rental.BasePrice;
        //    //placeholder += "Cena podstawowa samochodu: " + BasePrice + "\r\n";

        //    var daysCost = IloscDni /** BasePrice*/;
        //    placeholder += "Koszt wypozyczenia - same dni "+ daysCost + "\r\n";

        //    float carTypeCost = daysCost * ((float)car.CarType)/10;
        //    placeholder += "Koszt koncowy: " + carTypeCost + "\r\n";



        //    if (today - Data.YearDrivingLicense < 5)
        //    {
        //        carTypeCost = carTypeCost * 1.2f; 
        //        placeholder += "Klient posiada prawo jazdy mniej 5 lat dlatego placi 20% wiecej: " + Math.Round(carTypeCost, 2) + "\r\n";
        //    }

        //    if(car.CarAvaible < 3)
        //    {
        //        carTypeCost = carTypeCost * 1.15f;
        //        placeholder += "W wypozyczalni znajduje sie mniej niz 3 samochody: " + carTypeCost + "\r\n";
        //    }

        //    //spalanie
        //    var combustion = (car.Combustion * Data.Distance)/100;
        //    //cena za trase
        //    var routePrice = combustion * fuelPrice;

        //    placeholder += "Koszty za paliwo: " + Math.Round(routePrice, 2) + "\r\n";
        //    var endCost = carTypeCost + routePrice;
        //    placeholder += "Całkowity koszt wynajmu samochodu netto: " + Math.Round(endCost, 2) + "\r\n";
        //    placeholder += "Całkowity koszt wynajmu samochodu brutto: " + Math.Round(endCost * 1.23f, 2) + "\r\n";

        //    return Ok(placeholder);
        //}

        //[HttpPost("Add")]
        //public async Task<ActionResult<List<Car>>> AddCar(Car car)
        //{
        //    _context.Cars.Add(car);

        //    _context.SaveChanges();

        //    return Ok(_context.Cars);
        //}
        //} 
    }
}
