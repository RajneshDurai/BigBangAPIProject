using APIProjectBigBang.Model;
using Microsoft.AspNetCore.Mvc;

namespace APIProjectBigBang.Repository.RoomsCRUDRepository
{
    public interface IHotelCRUDRepository
    {
        public Task<List<Hotel>> GetRooms();
        public Task<Hotel> GetRoom(int id);
        public Task<List<Hotel>> PutRoom(int id, Hotel hotel);
        public  Task<List<Hotel>> PostRoom(Hotel hotel);

        public  Task<List<Hotel>> DeleteRoom(int id);

    }
}
