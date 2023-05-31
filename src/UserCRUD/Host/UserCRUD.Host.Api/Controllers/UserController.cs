using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UserCRUD.Application.AppData.Contexts.Users.Services;
using UserCRUD.Contracts;
using UserCRUD.Contracts.User;

namespace UserCRUD.Host.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с объявлениями.
    /// </summary>
    /// <response code="500">Произошла внутренняя ошибка.</response>
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        /// <summary>
        /// Инициализирует экземпляр <see cref="AdvertController"/>
        /// </summary>
        /// <param name="logger">Сервис логирования.</param>
        /// <param name="userService">Сервис для работы с пользователями.</param>
        public UserController(ILogger<UserController> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        /// <summary>
        /// Получить список польщователей.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <response code="200">Запрос выполнен успешно</response>
        /// <returns>Список моделей пользователей.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Запрос списка пользователей");
            var result = await _userService.GetAll(cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Получить пользователя по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <response code="200">Запрос выполнен успешно.</response>
        /// <response code="404">Объявление с указанным идентификатором не найдено.</response>
        /// <returns>Модель объявления.</returns>
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Запрос пользователя по идентификатору: {id}");
            var result = await _userService.Get(id, cancellationToken);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="dto">Модель создания пользователя.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <response code="201">Пользователь успешно создан.</response>
        /// <response code="400">Модель данных запроса невалидна.</response>
        /// <response code="422">Произошёл конфликт бизнес-логики.</response>
        /// <returns>Модель созданного объявления.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status422UnprocessableEntity)]
        // [Authorize]
        public async Task<IActionResult> Create([FromBody] UserDto dto, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Запрос на создание пользователя: {JsonConvert.SerializeObject(dto)}");
            var result = await _userService.Add(dto, cancellationToken);
            return CreatedAtAction(nameof(Create), new { result.Id });
        }

        /// <summary>
        /// Обновить пользователя.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="dto">Модель обновления пользователя.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <response code="200">Запрос выполнен успешно.</response>
        /// <response code="400">Модель данных запроса невалидна.</response>
        /// <response code="403">Доступ запрещён.</response>
        /// <response code="404">ПОльзователь с указанным идентификатором не найден.</response>
        /// <response code="422">Произошёл конфликт бизнес-логики.</response>
        /// <returns>Модель обновлённого объявления.</returns>
        [HttpPut("{id:Guid}")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Update(Guid id, [FromBody] UserDto dto, CancellationToken cancellationToken)
        {
            // TODO NotImplemented
            return await Task.Run(() => Ok(new UserDto()), cancellationToken);
        }

        

        /// <summary>
        /// Удалить пользователя по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <response code="204">Запрос выполнен успешно.</response>
        /// <response code="403">Доступ запрещён.</response>
        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DeleteById(Guid id, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Запрос на удаление объявления по идентификатору: {id}");
            await _userService.Delete(id, cancellationToken);
            return NoContent();
        }
    }
}
