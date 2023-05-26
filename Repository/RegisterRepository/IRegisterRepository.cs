using APIProjectBigBang.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIProjectBigBang.Repository.RegisterRepository
{
    public interface IRegisterRepository
    {
        public Task<Register> PostUser(Register user);

    }
}
