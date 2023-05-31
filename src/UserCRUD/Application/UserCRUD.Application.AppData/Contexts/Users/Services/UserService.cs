using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCRUD.Application.AppData.Contexts.Users.Repositories;
using UserCRUD.Contracts.User;
using UserCRUD.Domain.User;

namespace UserCRUD.Application.AppData.Contexts.Users.Services
{
    /// <inheritdoc />
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public Task<UserDto[]> GetAll(CancellationToken cancellationToken)
        {
            return _userRepository.GetAll(cancellationToken);
        }

        /// <inheritdoc />
        public Task<UserDto> Get(Guid id, CancellationToken cancellationToken)
        {
            return _userRepository.Get(id, cancellationToken);
        }

        /// <inheritdoc />
        public Task<UserDto> Add(UserDto dto, CancellationToken cancellationToken)
        {
            User entity = _mapper.Map<User>(dto);
            return _userRepository.Add(entity, cancellationToken);
        }

        /// <inheritdoc />
        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            await _userRepository.Delete(id, cancellationToken);
        }

    }
}
