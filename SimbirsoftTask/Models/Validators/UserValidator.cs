using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SimbirsoftTask.Models;
using SimbirsoftTask.Models.Repository;

namespace SimbirsoftTask.Models.Validators
{
    public class UserEmailUniqAttribute : ValidationAttribute
    {       
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                SqlRepository repo = new SqlRepository();
                User user = repo.GetUserByEmail((string)value);
                if (user == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}