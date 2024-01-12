using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace RazorPagesCafe.Models
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            ContentsOfDishes = new HashSet<ContentsOfDish>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "id ингредиента")]
        public int IdIngredient { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Название ингредиента не может содержать более 50 символов.")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Калории")]
        public decimal Calories { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Единица измерения")]
        public string Unit { get; set; }

        [Display(Name = "Остаток")]
        public double Remainder { get; set; }

        public virtual ICollection<ContentsOfDish> ContentsOfDishes { get; set; }
    }
}
