namespace CarRentalApp.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }      // Marka (Örn: Toyota)
        public string Model { get; set; }      // Model (Örn: Corolla)
        public int Year { get; set; }          // Yıl
        public decimal DailyPrice { get; set; }// Günlük Fiyat
        public bool IsAvailable { get; set; } = true; // Müsaitlik durumu
        public string ImagePath { get; set; }  // Araç görseli için URL/Yol
    }
}
