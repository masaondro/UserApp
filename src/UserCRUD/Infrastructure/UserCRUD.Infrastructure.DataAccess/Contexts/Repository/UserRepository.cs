using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCRUD.Application.AppData.Contexts.Users.Repositories;
using UserCRUD.Contracts.User;
using UserCRUD.Domain.User;
using UserCRUD.Infrastructure.Repository;

namespace UserCRUD.Infrastructure.DataAccess.Contexts.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public UserRepository(IRepository<User> advertRepository, IMapper mapper)
        {
            _repository = advertRepository;
            _mapper = mapper;
        }

        public Task<UserDto[]> GetAll(CancellationToken cancellationToken)
        {
            return _repository.GetAll().Where(s => s.RevokedBy == null)
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .ToArrayAsync(cancellationToken);
        }

        public Task<UserDto> Get(Guid id, CancellationToken cancellationToken)
        {
            return _repository.GetAll()
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<UserDto> Add(User entity, CancellationToken cancellationToken)
        {
            entity.CreatedOn = DateTime.UtcNow;
            await _repository.AddAsync(entity, cancellationToken);
            return _mapper.Map<UserDto>(entity);
        }

        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetAll().FirstOrDefaultAsync(x => x.Guid == id, cancellationToken);

            if (entity == null)
            {
                return;
            }

            await _repository.DeleteAsync(entity, cancellationToken);
        }
    }
}
