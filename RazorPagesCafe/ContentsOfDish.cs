using System;
using System.Collections.Generic;

namespace RazorPagesCafe;

public partial class ContentsOfDish
{
    public int IdIngredient { get; set; }

    public int IdPosition { get; set; }

    public double Quantity { get; set; }

    public virtual Ingredient IdIngredientNavigation { get; set; } = null!;

    public virtual Dish IdPositionNavigation { get; set; } = null!;
}
