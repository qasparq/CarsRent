﻿namespace CarsRent.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public Car Car { get; set; }
        public string Email { get; set; }
    }
}
