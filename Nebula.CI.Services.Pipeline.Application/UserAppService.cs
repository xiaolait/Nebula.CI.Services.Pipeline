using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;
using Volo.Abp.Users;

namespace Nebula.CI.Services.Pipeline.Application
{
    public class UserAppService : IUserAppService
    {
        private readonly ICurrentUser _currentUser;
        private readonly IRepository<User, int> _userRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public UserAppService(ICurrentUser currentUser, IRepository<User, int> userRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _currentUser = currentUser;
            _userRepository = userRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        public async Task<int> GetUserId()
        {
            var identityId = _currentUser.FindClaimValue("sub");
            var user = await _userRepository.Where(s => s.IdentityId == identityId).FirstOrDefaultAsync();
            if (user != null) return user.Id;

            using (var uow = _unitOfWorkManager.Begin(requiresNew: true, isTransactional: true))
            {
                user = await _userRepository.InsertAsync(new User(identityId));
                await uow.CompleteAsync();
            }

            return user.Id;
        }
    }
}