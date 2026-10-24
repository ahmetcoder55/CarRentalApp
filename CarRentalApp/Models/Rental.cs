namespace CarRentalApp.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; } // İlişkisel tablo (Navigation Property)

        public string CustomerName { get; set; } // Müşteri Ad Soyad
        public DateTime StartDate { get; set; }  // Başlangıç Tarihi
        public DateTime EndDate { get; set; }    // Bitiş Tarihi
        public decimal TotalPrice { get; set; }  // Toplam Tutar
    }
}
