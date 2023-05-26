using APIProjectBigBang.Data;
using APIProjectBigBang.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIProjectBigBang.Repository.RoomsCRUDRepository
{
    public class HotelCRUDRepository:IHotelCRUDRepository
    {
        private HotelContext _context;
        public HotelCRUDRepository(HotelContext context)
        {
            _context = context;
        }
        public async Task<List<Hotel>> GetRooms()
        {
            var item= await _context.Hotels.ToListAsync();
            if(item == null)
            {
                throw new ArgumentNullException("Table is empty");
            }
            return item;
        }
        public async Task<Hotel> GetRoom(int id)
        {
            var reqDetail = await _context.Hotels.FirstOrDefaultAsync(val => val.HotelId == id);
            if (reqDetail == null)
            {
                throw new ArithmeticException("Not available");
            }
            return reqDetail;
        }
        public async Task<List<Hotel>> PutRoom(int id, Hotel hotel)
        {
            var item = await _context.Hotels.FindAsync(id);
            if (item == null)
            {
                throw new ArgumentNullException("No id was found");
            }
            item.HotelName = hotel.HotelName;
            item.Location = hotel.Location;
            item.PhoneNumber= hotel.PhoneNumber;
            await _context.SaveChangesAsync();
            return await _context.Hotels.ToListAsync();

        }
        public async  Task<List<Hotel>> PostRoom(Hotel hotel)
        {
            var obj=await _context.Hotels.AddAsync(hotel);
            if (obj == null)
            {
                throw new ArithmeticException("Enter Something to insert");
            }
            await _context.SaveChangesAsync();
            return await _context.Hotels.ToListAsync();
        }
        public async Task<List<Hotel>> DeleteRoom(int id)
        {
            var obj = await _context.Hotels.FindAsync(id);
            if (obj == null)
            {
                throw new ArgumentNullException("Not Deleted");
            }
            _context.Hotels.Remove(obj);
            await _context.SaveChangesAsync();
            return await _context.Hotels.ToListAsync();
        }

     

    }
}
