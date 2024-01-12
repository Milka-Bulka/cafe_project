using System;
using System.Collections.Generic;

namespace RazorPagesCafe;

public partial class ContentsOfOrder
{
    public int IdOrder { get; set; }

    public string Comment { get; set; } = null!;

    public int IdPosition { get; set; }

    public virtual Orderr IdOrderNavigation { get; set; } = null!;

    public virtual Dish IdPositionNavigation { get; set; } = null!;
}
