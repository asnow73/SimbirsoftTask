using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SimbirsoftTask.Models
{
    public class Role
    {
        // ID роли
        public virtual int Id { get; set; }
        // Название роли
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [RegularExpression(@"[A-Za-zА-Яа-я]+", ErrorMessage = "Имя должно содержать только буквы")]
        public virtual string Name { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}