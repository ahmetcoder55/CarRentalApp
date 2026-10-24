namespace CarRentalApp.Dtos
{
    public record CarDto
    {
        public int Id { get; init; }
        public string Brand { get; init; }
        public string Model { get; init; }
        public int Year { get; init; }
        public decimal DailyPrice { get; init; }
        public bool IsAvailable { get; init; }
        public string ImagePath { get; init; }
    }
}
