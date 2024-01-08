using System;
using System.Collections.Generic;

namespace Student_Management.Models;

public partial class Cartier
{
    public int Id { get; set; }

    public string Libelle { get; set; } = null!;

    public virtual ICollection<BorderCartier> BorderCartiers { get; } = new List<BorderCartier>();

    public virtual ICollection<Student> Students { get; } = new List<Student>();

    public virtual ICollection<PointDeRecherche> PointDeRecherches { get; } = new List<PointDeRecherche>();
}
