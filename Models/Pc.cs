using System;
using System.Collections.Generic;

namespace Student_Management.Models;

public partial class Pc
{
    public int PcId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public int Price { get; set; }
}
