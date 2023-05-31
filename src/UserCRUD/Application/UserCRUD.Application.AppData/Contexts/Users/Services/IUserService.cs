using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCRUD.Contracts.User;

namespace UserCRUD.Application.AppData.Contexts.Users.Services
{
    /// <summary>
    /// Сервис для работы с пользователями.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Получить список пользователей.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Список пользователей.</returns>
        Task<UserDto[]> GetAll(CancellationToken cancellationToken);

        /// <summary>
        /// Получить пользователю по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Модель пользователя.</returns>
        Task<UserDto> Get(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Создает пользователя.
        /// </summary>
        /// <param name="dto">Модель создания пользователя.</param>
        /// <param name="cancellation">Токен отмены операции.</param>
        /// <returns>Модель созданного пользователя.</returns>
        Task<UserDto> Add(UserDto dto, CancellationToken cancellation);

        /// <summary>
        /// Удалить пользователя.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns></returns>
        Task Delete(Guid id, CancellationToken cancellationToken);
    }
}
