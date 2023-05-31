using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCRUD.Contracts.User;
using UserCRUD.Domain.User;

namespace UserCRUD.Application.AppData.Contexts.Users.Repositories
{
    /// <summary>
    /// Репозиторий для работы с пользователями.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Получить список пользователей.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Список пользователей.</returns>
        Task<UserDto[]> GetAll(CancellationToken cancellationToken);

        /// <summary>
        /// Получить пользователя по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Модель пользователя.</returns>
        Task<UserDto> Get(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавить пользователя.
        /// </summary>
        /// <param name="entity">Пользователь.</param>
        /// <param name="cancellation">Токен отмены операции.</param>
        /// <returns>Модель добавленного объявления.</returns>
        Task<UserDto> Add(User entity, CancellationToken cancellation);

        /// <summary>
        /// Удалить пользователя.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns></returns>
        Task Delete(Guid id, CancellationToken cancellationToken);
    }
}
