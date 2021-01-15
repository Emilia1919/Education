using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using CompareAttribute = System.Web.Mvc.CompareAttribute;

namespace _21century.Models
{
    public class ContentManager
    {
        [Display(Name = "Логин")]
        [Required(ErrorMessage = "Логин обязательно")]
        [RegularExpression("[a-z0-9_]+", ErrorMessage = "Только маленькие латинские буквы, цифры или подчёркивание")]
        public string Login { get; set; }

        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Пароль обязательно")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Минимальная длина 6 символов")]
        public string Password { get; set; }

        [Display(Name = "Повторить пароль")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Повторить пароль обязательно")]
        [Compare("Password", ErrorMessage = "Повторный пароль не совпадает с первым")]
        public string Repeat { get; set; }

        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
    }
}