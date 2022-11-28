namespace CarsRent.Entities
{
    public record InputData
    {
        public int Distance { get; set; }
        public int YearDrivingLicense { get; set; }
        public DateTime StartRent { get; set; }
        public DateTime EndRent { get; set; }
    }
}
