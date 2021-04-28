using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pittools.Models.Metadata
{
    public class ProductMetadata
    {
        [Required(ErrorMessage = "Наименование обязательно")]
        [Display(Name = "Наименование")]
        [StringLength(50, ErrorMessage = "Не более 50 символов")]
        public string Name { get; set; }

        [Display(Name = "Наименование отображаемое в URL")]
        [RegularExpression("[a-z0-9_]+", ErrorMessage = "Только маленькие латинские буквы, цифры и подчёркивание")]
        public string ShortName { get; set; }

        [Required(ErrorMessage = "Цена обязательно")]
        [Display(Name = "Цена")]
        public string Price { get; set; }

        [Required(ErrorMessage = "Производитель обязательно")]
        [Display(Name = "Производитель")]
        public string ManufacturerID { get; set; }
    }
}