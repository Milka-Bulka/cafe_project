using System;
using System.Collections.Generic;

namespace RazorPagesCafe;

public partial class Ingredient
{
    public int IdIngredient { get; set; }

    public string Name { get; set; } = null!;

    public decimal Calories { get; set; }

    public string Unit { get; set; } = null!;

    public int Remainder { get; set; }

    public virtual ICollection<ContentsOfDish> ContentsOfDishes { get; set; } = new List<ContentsOfDish>();
}
