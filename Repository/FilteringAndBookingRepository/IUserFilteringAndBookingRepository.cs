using APIProjectBigBang.Model;
using Microsoft.AspNetCore.Mvc;

namespace APIProjectBigBang.Repository.FilteringAndBookingRepository
{
    public interface IUserFilteringAndBookingRepository
    {
        public Task<List<Hotel>> GetHotels();
        public  Task<List<Hotel>> GetHotelLocation(string loc);
        public  Task<List<GetHotelPriceTable>> GetHotelPrice(double price);
        public Task<List<GetBookingTable>> GetBooking(string HotelName, string RoomType);


    }
}
