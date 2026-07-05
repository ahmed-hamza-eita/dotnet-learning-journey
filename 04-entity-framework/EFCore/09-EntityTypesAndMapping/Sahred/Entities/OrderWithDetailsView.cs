using System;
using System.Collections.Generic;

namespace Sahred.Entities;

public partial class OrderWithDetailsView
{
    public int OrderId { get; set; }

    public DateTime OrderDate { get; set; }

    public string CustomerEmail { get; set; } = null!;

    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal UnitPrice { get; set; }

    public int Quantity { get; set; }
}
