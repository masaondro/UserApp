using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCRUD.Domain.User
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User
    {
        /// <summary>
        /// Уникальный идентификатор пользователя
        /// </summary>
        public Guid Guid { get; set; }
        /// <summary>
        /// Уникальный Логин
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Пол
        /// </summary>
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
        public DateTime CreatedOn { get; set; }
        /// <summary>
        /// Логин Пользователя, от имени которого этот пользователь создан
        /// </summary>
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
