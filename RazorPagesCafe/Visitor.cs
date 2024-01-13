using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesCafe;

public partial class Visitor
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "Id посетителя")]
    public int IdVisitor { get; set; }

    [RegularExpression(@"^[А-Я]+[а-я]*$")]
    [Required]
    [Display(Name = "Имя")]
    [StringLength(30, ErrorMessage = "Имя не может содержать более 30 символов.")]
    public string Name { get; set; } = null!;

    [RegularExpression(@"^((\+7|7|8)+([0-9]){10})$")]
    [Display(Name = "Телефон")]
    public string Telephone { get; set; } = null!;

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "Дата рождения")]
    public DateOnly DOfB { get; set; }

    [Display(Name = "Бонусы")]
    public int? Bonuses { get; set; }

    public virtual ICollection<Orderr> Orderrs { get; set; } = new List<Orderr>();
}
