using APIProjectBigBang.Model;
using Microsoft.AspNetCore.Mvc;

namespace APIProjectBigBang.Repository.RoomsCountRepository
{
    public interface IRoomsCountRepository
    {
        public Task<int> GetCount(string HotelName);
        public Task<List<GetCountsTable>> GetCounts();

    }
}
