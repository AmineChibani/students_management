using System;
using System.Collections.Generic;

namespace Student_Management.Models;

public partial class PointDeRecherche
{
    public int Id { get; set; }

    public string Neighborhood { get; set; } = null!;

    public double Lattitude { get; set; }

    public double Longitude { get; set; }

    public virtual ICollection<Cartier> IdCartiers { get; } = new List<Cartier>();
}
