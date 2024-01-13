using System;
using System.Collections.Generic;

namespace RazorPagesCafe;

public partial class Visitor
{
    public int IdVisitor { get; set; }

    public string Name { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public DateOnly DOfB { get; set; }

    public int? Bonuses { get; set; }

    public virtual ICollection<Orderr> Orderrs { get; set; } = new List<Orderr>();
}
