namespace CarsRent.Entities
{
    public record InputData
    {
        public int Distance { get; set; }
        public int YearDrivingLicense { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
