using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimbirsoftTask.Models
{
    public class User
    {
        // ID пользователя
        public virtual int Id { get; set; }
        // Email пользователя
        public virtual string Email { get; set; }
        // Пароль пользователя
        public virtual string Password { get; set; }
        // Имя пользователя
        public virtual string Name { get; set; }
        // Фамилия пользователя
        public virtual string Surname { get; set; }
        // День рождения пользователя
        public virtual DateTime Birthday { get; set; }
    }
}