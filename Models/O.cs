using System;
using System.Collections.Generic;

namespace Student_Management.Models;

public partial class O
{
    public int Id { get; set; }

    public string Libelle { get; set; } = null!;

    public virtual ICollection<Campaign> IdCampaigns { get; } = new List<Campaign>();
}
