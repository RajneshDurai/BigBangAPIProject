using APIProjectBigBang.Data;
using APIProjectBigBang.Model;
using Microsoft.CodeAnalysis;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace APIProjectBigBang.Repository.FilteringAndBookingRepository
{
    public class UserFilteringAndBookingRepository:IUserFilteringAndBookingRepository
    {
        private HotelContext _hotelContext;
        public UserFilteringAndBookingRepository(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }
        public async Task<List<Hotel>> GetHotels()
        {
            var items=await _hotelContext.Hotels.ToListAsync();
            if (items == null)
            {
                throw new ArgumentException("Empty Table");
            }
            return items;
        }
        //FILTER BASED ON LOCATION
        public async Task<List<Hotel>> GetHotelLocation( string loc)
        {
            var obj=await(from h in _hotelContext.Hotels where h.Location == loc select h).ToListAsync();
            if(obj==null)
            {
                throw new ArgumentException("There is no hotel in the Given Location");
            }
            return obj;
        }
        //FILTER BASED ON PRICE
        public async Task<List<GetHotelPriceTable>> GetHotelPrice(double price)
        {
            var obj =await (from h in _hotelContext.Hotels
                      join r in _hotelContext.Rooms on h.HotelId equals r.HotelId
                      where r.Price == price
                      select new GetHotelPriceTable()
                      {
                          HotelName = h.HotelName,
                          Location = h.Location,
                          Price = r.Price,
                          RoomType = r.RoomType
                      }).ToListAsync();
            if (obj==null)
            {
                throw new ArgumentNullException("No Hotels were available on that price you given");
            }
            return obj;
        }

        //BOOKING BY HOTELNAME
        public async Task<List<GetBookingTable>> GetBooking(string HotelName,string RoomType)
        {
            var avai=await _hotelContext.Hotels.FirstOrDefaultAsync(s=>s.HotelName==HotelName && s.RoomsAvailable=="Available");
            if (avai != null)
            {
                var book =await (from h in _hotelContext.Hotels
                           join r in _hotelContext.Rooms
                         on h.HotelId equals r.HotelId
                           where r.RoomAvailableinRoomType == "Available" && r.RoomType ==RoomType
                           select new GetBookingTable()
                           {
                               HotelName=h.HotelName,
                               Status = "Booked",
                               Price=r.Price
                           }).ToListAsync();
                return book;
            }
            else
            {
                throw new ArgumentNullException("Rooms are not available in the hotel you selected.. Look for someother Hotel");
            }   
                     
        }

    }
}
