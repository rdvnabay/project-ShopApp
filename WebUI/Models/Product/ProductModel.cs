using ShopAppDemo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopAppDemo.WebUI.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        //[Required]
        //[StringLength(maximumLength:60,ErrorMessage ="Minumum 10 Maksimum 60 karaker giriniz",MinimumLength =10)]
        public string Name { get; set; }

        //[Required]
        public string Image { get; set; }

        [Required(ErrorMessage ="Lütfen bir fiyat belirtiniz")]
        [Range(1,10000)]
        public double? Price { get; set; }

        [Required]
        [StringLength(maximumLength:100, ErrorMessage ="Minumum 20 Maksimum 100 karaker giriniz",MinimumLength = 20)]
        public string Description { get; set; }

        public List<Category> SelectedCategories { get; set; }
        public List<Category> Categories { get; set; }
    }
}
