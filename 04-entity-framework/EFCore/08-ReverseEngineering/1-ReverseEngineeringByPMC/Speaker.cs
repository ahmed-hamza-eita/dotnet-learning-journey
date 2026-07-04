using System;
using System.Collections.Generic;

namespace _1_ReverseEngineeringByPMC;

public partial class Speaker
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
