using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesCafe;

public partial class Ingredient
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Display(Name = "id ингредиента")]
    public int IdIngredient { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "Название ингредиента не может содержать более 50 символов.")]
    [Display(Name = "Название")]
    public string Name { get; set; } = null!;

    [Display(Name = "Калории")]
    public decimal Calories { get; set; }

    [Required]
    [StringLength(10)]
    [Display(Name = "Единица измерения")]
    public string Unit { get; set; } = null!;

    [Display(Name = "Остаток")]
    public int Remainder { get; set; }

    public virtual ICollection<ContentsOfDish> ContentsOfDishes { get; set; } = new List<ContentsOfDish>();
}
