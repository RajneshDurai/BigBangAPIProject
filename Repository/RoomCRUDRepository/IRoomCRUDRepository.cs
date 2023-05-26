using APIProjectBigBang.Model;
using Microsoft.AspNetCore.Mvc;

namespace APIProjectBigBang.Repository.RoomsCRUDRepository
{
    public interface IRoomCRUDRepository
    {
        public Task<List<Room>> GetRooms();
        public Task<Room> GetRoom(int id);
        public Task<List<Room>> PutRoom(int id, Room room);
        public  Task<List<Room>> PostRoom(Room room);

        public  Task<List<Room>> DeleteRoom(int id);

    }
}
