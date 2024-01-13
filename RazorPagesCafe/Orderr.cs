using System;
using System.Collections.Generic;

namespace RazorPagesCafe;

public partial class Orderr
{
    public int IdOrder { get; set; }

    public int IdTable { get; set; }

    public int IdVisitor { get; set; }

    public int NumberOfVisitor { get; set; }

    public DateTime OrderTime { get; set; }

    public decimal TotalAmount { get; set; }

    public virtual ContentsOfOrder? ContentsOfOrder { get; set; }

    public virtual Visitor IdVisitorNavigation { get; set; } = null!;
}
