namespace APIProjectBigBang.Repository.FilteringAndBookingRepository
{
    public class GetHotelPriceTable
    {
        public string HotelName { get; set; }
        public string Location { get; set; } = string.Empty;
        public double Price { get; set; }
        public string RoomType { get; set; } = string.Empty;
    }
}
