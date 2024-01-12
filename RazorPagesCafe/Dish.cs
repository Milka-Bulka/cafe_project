using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesCafe;

public partial class Dish
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Display(Name = "id позиции")]
    public int IdPosition { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "Название не может содержать более 50 символов.")]
    [Display(Name = "Название блюда")]
    public string Name { get; set; } = null!;

    [Display(Name = "Количество в заказе")]
    public int QuantityInOrder { get; set; }

    [Display(Name = "Курс приготовления")]
    public int CookingCourse { get; set; }

    [Required]
    [StringLength(20)]
    [Display(Name = "Вид меню")]
    public string MenuView { get; set; } = null!;

    [Required]
    [Column(TypeName = "varchar(200)")]
    [Display(Name = "Описание")]
    public string Description { get; set; } = null!;

    [Display(Name = "Калории")]
    public decimal Calories { get; set; }

    [DataType(DataType.Currency)]
    [Column(TypeName = "money")]
    [Display(Name = "Стоимость")]
    public decimal Amount { get; set; }

    public virtual ICollection<ContentsOfDish> ContentsOfDishes { get; set; } = new List<ContentsOfDish>();

    public virtual Menu MenuViewNavigation { get; set; } = null!;
}
