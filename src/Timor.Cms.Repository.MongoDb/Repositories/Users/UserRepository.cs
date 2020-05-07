using System.Threading.Tasks;
using AutoMapper;
using Timor.Cms.Infrastructure.Dependency;
using Timor.Cms.PersistModels.MongoDb.Users;

namespace Timor.Cms.Repository.MongoDb.Repositories.Users
{
    public class UserRepository : ITransient
    {
        private readonly IMongoDbRepository<User> _userRepository;
        private readonly IMapper _mapper;


        public UserRepository(IMongoDbRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<string> CreateUser(Domains.Users.User userDomain)
        {
            var user = _mapper.Map<User>(userDomain);

            await _userRepository.InsertAsync(user);

            return user.Id.ToString();
        }

        public async Task<Domains.Users.User> FindUserByUserName(string userName)
        {
            userName = userName.ToUpperInvariant();

            var user = await _userRepository.FindFirstOrDefaultAsync(u =>
                u.NormalizedUserName == userName);

            return _mapper.Map<Domains.Users.User>(user);
        }

        public async Task<Domains.Users.User> FindUserByEmail(string email)
        {
            email = email.ToUpperInvariant();

            var user = await _userRepository.FindFirstOrDefaultAsync(u =>
                u.NormalizedEmail == email);

            return _mapper.Map<Domains.Users.User>(user);
        }

        public async Task<Domains.Users.User> FindUserByPhoneNumber(string phoneNumber)
        {
            var user = await _userRepository.FindFirstOrDefaultAsync(u =>
                u.PhoneNumber == phoneNumber);

            return _mapper.Map<Domains.Users.User>(user);
        }
    }
}