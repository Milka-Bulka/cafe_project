using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesCafe;

public partial class Menu
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Required]
    [StringLength(20)]
    [Display(Name = "Вид меню")]
    public string MenuView { get; set; } = null!;

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "Время действия до")]
    public DateTime TimeOfAction { get; set; }

    public virtual ICollection<Dish> Dishes { get; set; } = new List<Dish>();
}
