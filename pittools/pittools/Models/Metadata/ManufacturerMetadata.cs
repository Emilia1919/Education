﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pittools.Models.Metadata
{
    public class ManufacturerMetadata
    {
        [Required(ErrorMessage = "Наименование обязательно")]
        [Display(Name = "Наименование")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Наименование отображаемое в URL")]
        [RegularExpression("[a-z0-9_]+", ErrorMessage = "Только маленькие латинские буквы, цифры и подчёркивание")]
        [StringLength(50)]
        public string ShortName { get; set; }
    }
}