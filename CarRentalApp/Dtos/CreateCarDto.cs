namespace CarRentalApp.Dtos
{
    public record CreateCarDto
    {
        public string Brand { get; init; }
        public string Model { get; init; }
        public int Year { get; init; }
        public decimal DailyPrice { get; init; }
        public string ImagePath { get; init; }
    }
}
