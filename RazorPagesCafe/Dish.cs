using System;
using System.Collections.Generic;

namespace RazorPagesCafe;

public partial class Dish
{
    public int IdPosition { get; set; }

    public string Name { get; set; } = null!;

    public int QuantityInOrder { get; set; }

    public int CookingCourse { get; set; }

    public string MenuView { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Calories { get; set; }

    public decimal Amount { get; set; }

    public virtual ICollection<ContentsOfDish> ContentsOfDishes { get; set; } = new List<ContentsOfDish>();

    public virtual Menu MenuViewNavigation { get; set; } = null!;
}
