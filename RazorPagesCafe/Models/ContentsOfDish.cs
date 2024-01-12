using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace RazorPagesCafe.Models
{
    public partial class ContentsOfDish
    {
        [Display(Name = "id ингредиента")]
        public int IdIngredient { get; set; }

        [Display(Name = "id позиции")]
        public int IdPosition { get; set; }

        [Display(Name = "количество")]
        public double Quantity { get; set; }

        [Display(Name = "Id ингредиента")]
        public virtual Ingredient IdIngredientNavigation { get; set; }

        [Display(Name = "Id позиции")]
        public virtual Dish IdPositionNavigation { get; set; }
    }
}
