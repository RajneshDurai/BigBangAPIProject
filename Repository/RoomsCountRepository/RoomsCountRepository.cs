using APIProjectBigBang.Data;
using APIProjectBigBang.Model;
using Microsoft.EntityFrameworkCore;

namespace APIProjectBigBang.Repository.RoomsCountRepository
{
    public class RoomsCountRepository:IRoomsCountRepository
    {
        private HotelContext _context;
        public RoomsCountRepository(HotelContext context)
        {
            _context = context;
        }

        public async Task<int> GetCount(string HotelName)
        {
            var ans =await (from h in _context.Hotels
                      join r in _context.Rooms on h.HotelId equals r.HotelId
                      where h.HotelName == HotelName && r.RoomAvailableinRoomType == "Available"
                      select  h).ToListAsync();
            if (ans.Count == null ) {
                throw new Exception("No Rooms are Available");
            }
            return ans.Count;
        }
        public async Task<List<GetCountsTable>> GetCounts()
        {
            var ans = (from h in _context.Hotels
                      join r in _context.Rooms on h.HotelId equals r.HotelId
                      where r.RoomAvailableinRoomType == "Available"
                      select new GetCountsTable()
                      {
                          HotelName = h.HotelName,
                          Count = _context.Rooms.Count(s=>s.RoomAvailableinRoomType=="Available")
                      }).ToListAsync();
            return await ans;          
        }

    }
}
