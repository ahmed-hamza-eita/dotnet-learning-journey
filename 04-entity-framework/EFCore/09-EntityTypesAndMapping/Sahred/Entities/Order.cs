using System;
using System.Collections.Generic;

namespace Sahred.Entities;

public partial class Order
{
    public int Id { get; set; }

    public DateTime OrderDate { get; set; }

    public string CustomerEmail { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
