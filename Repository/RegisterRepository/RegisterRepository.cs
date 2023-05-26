using APIProjectBigBang.Authorization;
using APIProjectBigBang.Data;

namespace APIProjectBigBang.Repository.RegisterRepository
{
    public class RegisterRepository:IRegisterRepository
    {
        private HotelContext _context;
        public RegisterRepository(HotelContext context)
        {
            _context = context;
        }
        public async Task<Register> PostUser(Register user)
        {
            _context.Register.Add(user);
           await _context.SaveChangesAsync();
            return user;
        

        }

    }
}
