using System;
using System.Collections.Generic;

namespace Student_Management.Models;

public partial class AdType
{
    public int Id { get; set; }

    public string Libelle { get; set; } = null!;

    public virtual ICollection<Campaign> Campaigns { get; } = new List<Campaign>();
}
