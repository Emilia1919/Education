using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace _21century.Models.Metadata
{
    public class ProductMetadata
    {
        [Required(ErrorMessage = "Наименование обязательно")]
        [Display(Name = "Наименование")]
        [StringLength(50, ErrorMessage = "Не более 50 символов")]
        public string Name { get; set; }

        [Display(Name = "Наименование отображаемое в URL")]
        [RegularExpression("[a-z0-9]+", ErrorMessage = "Только маленькие латинские буквы, цифры и подчеркивание")]
        public string ShortName { get; set; }

        [Required(ErrorMessage = "Цена обязательно")]
        [Display(Name = "Цена")]
        public string Price { get; set; }

        [Required(ErrorMessage = "Тип покрытия обязательно")]
        [Display(Name = "Тип покрытия")]
        public string Сoverage_type { get; set; }

        [Required(ErrorMessage = "Текстура покрытия обязательно")]
        [Display(Name = "Текстура покрытия")]
        public string Coverage_texture { get; set; }

        [Required(ErrorMessage = "Цвет покрытия обязательно")]
        [Display(Name = "Цвет покрытия")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Производитель обязательно")]
        [Display(Name = "Производитель")]
        public string ManufacturerID { get; set; }
    }
}