using CarsRent.Data;
using CarsRent.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarsRent.Controllers
{
    [Route("CarRent")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly DataContext _context;
        public CalculatorController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Car>>> getCars()
        {
            return Ok(_context.Cars.ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Car>>> getCarRent(int id, [FromQuery] InputData Data)
        {
            var fuelPrice = 4.17f;
            var today = DateTime.Now.Year;
            var car = await _context.Cars.FindAsync(id);
            var placeholder = "";
            if (today - Data.YearDrivingLicense < 3 && car.CarType == DataContext.CarTypE.Premium)
            {
                 return BadRequest("Nie możesz wypożyczyć tego samochodu");
            }
            placeholder += "Cena paliwa: " + fuelPrice + "\r\n";
            placeholder += "Twoje auto: " + car.Name + "\r\n";
                     
            var IloscDni = Data.End.Subtract(Data.Start).Days; // mm/dd/yyyy
            placeholder += "Samochod wypożyczony na: " + IloscDni + " dni. \r\n";

            var BasePrice = car.BasePrice;
            placeholder += "Cena podstawowa samochodu: " + BasePrice + "\r\n";

            var daysCost = IloscDni * BasePrice;
            placeholder += "Koszt wypozyczenia - same dni "+ daysCost + "\r\n";

            float carTypeCost = daysCost * ((float)car.CarType)/10;
            placeholder += "Koszt koncowy: " + carTypeCost + "\r\n";



            if (today - Data.YearDrivingLicense < 5)
            {
                carTypeCost = carTypeCost * 1.2f; 
                placeholder += "Klient posiada prawo jazdy mniej 5 lat dlatego placi 20% wiecej: " + Math.Round(carTypeCost, 2) + "\r\n";
            }

            if(car.CarAvaible < 3)
            {
                carTypeCost = carTypeCost * 1.15f;
                placeholder += "W wypozyczalni znajduje sie mniej niz 3 samochody: " + carTypeCost + "\r\n";
            }

            //spalanie
            var combustion = (car.Combustion * Data.Distance)/100;
            //cena za trase
            var routePrice = combustion * fuelPrice;

            placeholder += "Koszty za paliwo: " + Math.Round(routePrice, 2) + "\r\n";
            var endCost = carTypeCost + routePrice;
            placeholder += "Całkowity koszt wynajmu samochodu netto: " + Math.Round(endCost, 2) + "\r\n";
            placeholder += "Całkowity koszt wynajmu samochodu brutto: " + Math.Round(endCost * 1.23f, 2) + "\r\n";

            return Ok(placeholder);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<List<Car>>> AddCar(Car car)
        {
            _context.Cars.Add(car);
            return Ok(_context.Cars);
        }
    } 
}
