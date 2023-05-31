using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCRUD.Contracts.User
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class UserDto
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Уникальный Логин
        /// </summary>
        [Required(ErrorMessage = "Поле логин быть установлено")]
        [RegularExpression ("^[a-zA-Z0-9]+$ ", ErrorMessage = "Логин содержит запрещенные символы")]
        public string Login { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        [Required(ErrorMessage = "Поле пароль быть установлено")]
        [RegularExpression("^[a-zA-Z0-9]+$ ", ErrorMessage = "Пароль содержит запрещенные символы")]
        public string Password { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        [Required(ErrorMessage = "Поле имя быть установлено")]
        [RegularExpression("^[а-яА-ЯёЁa-zA-Z]+$", ErrorMessage = "Имя содержит запрещенные символы")]
        public string Name { get; set; }
        /// <summary>
        /// Пол
        /// </summary>
        [Required(ErrorMessage = "Поле гендер быть установлено")]
        [Range(0, 2, ErrorMessage = "Недопустимый гендер")]
        public int Gender { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// Указание - является ли пользователь админом
        /// </summary>
        public bool Admin { get; set; }
        /// <summary>
        /// Дата создания пользователя
        /// </summary>
        [Required(ErrorMessage = "Дата создания должна быть установлена")]
        public DateTime CreatedOn { get; set; }
        /// <summary>
        /// Логин Пользователя, от имени которого этот пользователь создан
        /// </summary>
        [Required(ErrorMessage = "Создатель должен быть установлен")]
        public string CreatedBy { get; set; }
        /// <summary>
        /// Дата изменения пользователя
        /// </summary>
        public DateTime ModifiedOn { get; set; }
        /// <summary>
        /// Логин Пользователя, от имени которого этот пользователь изменён
        /// </summary>
        public string ModifiedBy { get; set; }
        /// <summary>
        /// Дата удаления пользователя
        /// </summary>
        public DateTime RevokedOn { get; set; }
        /// <summary>
        /// Логин Пользователя, от имени которого этот пользователь удален
        /// </summary>
        public string RevokedBy { get; set; }
    }
}
