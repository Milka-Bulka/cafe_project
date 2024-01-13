using System;
using System.Collections.Generic;

namespace RazorPagesCafe;

public partial class Menu
{
    public string MenuView { get; set; } = null!;

    public DateTime TimeOfAction { get; set; }

    public virtual ICollection<Dish> Dishes { get; set; } = new List<Dish>();
}
