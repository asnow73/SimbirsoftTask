using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

using SimbirsoftTask.Models.Validators;

namespace SimbirsoftTask.Models
{
    public class User
    {
        // ID пользователя
        public virtual int Id { get; set; }
        // Email пользователя
        [Required(ErrorMessage = "Поле должно быть установлено")]        
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        //[Remote("CheckUserEmail", "Account", ErrorMessage = "Пользователь с таким email уже существует")]
        [UserEmailUniq(ErrorMessage = "Пользователь с таким email уже существует")]
        [DataType(DataType.EmailAddress)]        
        public virtual string Email { get; set; }
        // Пароль пользователя
        public virtual string Password { get; set; }
        // Имя пользователя
        [RegularExpression(@"[A-Za-zА-Яа-я]+", ErrorMessage = "Имя должно содержать только буквы")]
        public virtual string Name { get; set; }
        // Фамилия пользователя
        [RegularExpression(@"[A-Za-zА-Яа-я]+", ErrorMessage = "Имя должно содержать только буквы")]
        public virtual string Surname { get; set; }
        // День рождения пользователя
        [DataType(DataType.Date)]
        public virtual DateTime Birthday { get; set; }

        public int? RoleId { get; set; }
        public Role Role { get; set; }
    }
}